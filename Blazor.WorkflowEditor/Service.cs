using System.Activities;
using System.Collections.ObjectModel;
using Blazor.Diagrams;
using Blazor.Diagrams.Core;
using Blazor.Diagrams.Core.Anchors;
using Blazor.Diagrams.Core.Controls;
using Blazor.Diagrams.Core.Controls.Default;
using Blazor.Diagrams.Core.Models;
using Blazor.Diagrams.Core.Models.Base;
using Blazor.Diagrams.Core.Positions;
using Blazor.WorkflowEditor.Activity;
using Blazor.WorkflowEditor.Activity.Flow;
using System.Reflection;
using Microsoft.AspNetCore.Components.Web;

namespace Blazor.WorkflowEditor {

    public partial class Service : IDisposable {
        private class ActivityPairType {
            public Type Type;
            public PairAttribute PairAttribute;
            public ActivityPairType(Type type, PairAttribute pairAttribute) {
                Type = type;
                PairAttribute = pairAttribute;
            }
        }

        private ActivityBuilder activityBuilder = default!;
        private readonly BlazorDiagram designer = default!;
        private readonly Action updateState = default!;
        private readonly List<ActivityDesignerPair> items = new();
        private readonly List<ActivityDesignerPair> selectedItems = new();
        private readonly List<(ActivityDesignerPair, ActivityDesignerPair)> selectedLinks = new();
        private readonly Dictionary<Type, ActivityPairType> typePairAttributes = new();

        /// <summary>True while links are added/removed from the model, to avoid reacting to our own changes.</summary>
        private bool suppressLinkSync;

        /// <summary>
        /// Ports the user picked while drawing a connection. A graph link is rebuilt from the workflow model
        /// on every change, so the choice of anchor has to be remembered here, otherwise the rebuilt link
        /// would jump back to the default left/right ports.
        /// </summary>
        private readonly Dictionary<(ActivityDesignerPair from, ActivityDesignerPair to), (PortAlignment source, PortAlignment target)> linkPorts = new();

        /// <summary>Validation messages per activity (key = the model object that produced the error).</summary>
        private readonly Dictionary<object, List<string>> validationErrors = new();

        /// <summary>Elements that hold validation messages, in themselves or in a nested element.</summary>
        private readonly HashSet<object> elementsWithErrors = new(ReferenceEqualityComparer.Instance);

        private bool isDirty;

        /// <summary>Set when the ports have to be measured again after the next render.</summary>
        private bool portGeometryDirty;

        /// <summary>Set when an opened path was laid out before the diagram viewport was measured.</summary>
        private bool pendingInitialLayout;

        public IEnumerable<ActivityDesignerPair> Items => items;
        public IEnumerable<ActivityDesignerPair> SelectedItems => selectedItems;
        public IEnumerable<(ActivityDesignerPair source, ActivityDesignerPair target)> SelectedLinks => selectedLinks;

        public ObservableCollection<PathItem> Path = new();
        public ObservableCollection<Variable> Variables { get; set; } = new();

        public Diagrams.Core.Geometry.Rectangle? DiagramContainer => this.designer.Container;

        /// <summary>The visible part of the diagram in world coordinates (takes pan and zoom into account).</summary>
        public readonly record struct Viewport(double Left, double Top, double Width, double Height);

        /// <summary>Null until the diagram container has been measured.</summary>
        public Viewport? VisibleViewport {
            get {
                var container = designer.Container;
                if (container == null || container.Width <= 0 || container.Height <= 0)
                    return null;

                var zoom = designer.Zoom <= 0 ? 1 : designer.Zoom;
                return new Viewport(-designer.Pan.X / zoom, -designer.Pan.Y / zoom,
                    container.Width / zoom, container.Height / zoom);
            }
        }

        public int LinkCount => designer.Links.Count;

        public ToolBoxItem? DraggedToolboxItem { get; set; }

        /// <summary>
        /// Node that should receive the next dropped activity (for example an If branch region).
        /// Null means the currently opened container. Cleared after the next add.
        /// </summary>
        public DefaultNode? DropTarget { get; set; }

        /// <summary>
        /// Slot that should receive the next dropped activity (the branch region of an activity that holds one
        /// Activity per branch). Cleared after the next add. Takes precedence over <see cref="DropTarget"/>.
        /// </summary>
        public IActivityHolder? DropSlot { get; set; }

        /// <summary>
        /// Index a new element takes in the column of the opened stack container (Sequence) when it is dropped
        /// at the current pointer place. Null while no stack is opened or the pointer is over another surface.
        /// Set while an activity is dragged over the canvas, so the column can show where the element lands.
        /// </summary>
        public int? DropInsertIndex { get; private set; }

        /// <summary>True while the user drags a card inside the column of the opened stack container.</summary>
        public bool IsReordering { get; private set; }

        /// <summary>Gap of the column that shows where the dragged card lands, while the drag changes the order.</summary>
        public int? ReorderGapIndex { get; private set; }

        /// <summary>
        /// Card the user drags inside the inline list of a card (a container shown on a surface), or null.
        /// </summary>
        public DefaultNode? DraggedInlineChild { get; private set; }

        /// <summary>Card of the opened stack container the user drags, or null.</summary>
        private DefaultNode? draggedStackChild;

        /// <summary>Index the dragged card takes in the column, once it is taken out of it.</summary>
        private int? reorderIndex;

        /// <summary>Raised when the workflow model changed (used to re-run validation).</summary>
        public event Action? ModelChanged;

        /// <summary>Raised when the unsaved-changes flag changes.</summary>
        public event Action? DirtyChanged;

        /// <summary>True when the schema contains changes that are not saved to XAML yet.</summary>
        public bool IsDirty => isDirty;

        /// <summary>The graph container currently opened in the editor, if any (Flowchart, StateMachine).</summary>
        public IGraphContainer? OpenedGraph => currentGraphContainer;

        /// <summary>The ordered container currently opened in the editor, if any (Sequence).</summary>
        public IStackContainer? OpenedStack => Path.LastOrDefault()?.Reference?.Node as IStackContainer;

        /// <summary>Number of children of the opened ordered container, or 0.</summary>
        public int StackCount => OpenedStack?.Count ?? 0;

        /// <summary>True while the ActivityBuilder root is open in the editor.</summary>
        public bool IsRootPath => Path.Count == 1 && Path[0].Reference.Node is DynamicActivityNode;

        /// <summary>True while the work surface of the editor shows the workflow root.</summary>
        public bool IsRootCanvas => Path.Count == 0 || IsRootPath;

        /// <summary>
        /// What the start cue of the current canvas asks for, or null when the canvas draws no cue: it either
        /// shows a start element (the cue is then drawn on the card of that element) or it is a container that
        /// already holds elements.
        /// </summary>
        public string? StartHint {
            get {
                if (StartTargetNode != null)
                    return null;

                if (IsRootCanvas)
                    return "Drop the first activity here";

                if (Path.LastOrDefault()?.Reference?.Node is not { } container)
                    return "Drop the first activity here";

                //A container that holds nothing asks for its first element exactly like the empty root does; a
                //Flowchart also asks for the start node while it is not chosen yet.
                return container.EmptyHint ?? container switch {
                    FlowchartNode { Count: 0 } => "Add a node to create the flowchart start",
                    FlowchartNode => "Choose the start node in Flowchart properties",
                    _ => null
                };
            }
        }

        /// <summary>The element the current canvas starts with: the root implementation, the start element of a
        /// graph container, or the first element of an ordered container.</summary>
        public DefaultNode? StartTargetNode {
            get {
                if (IsRootPath && activityBuilder?.Implementation is { } implementation)
                    return items.FirstOrDefault(p => ReferenceEquals(p.Activity, implementation))?.Node;

                if (Path.LastOrDefault()?.Reference?.Node is not { } container)
                    return null;

                if (container is FlowchartNode flowchart && flowchart.StartElement is { } element)
                    return items.FirstOrDefault(p => ReferenceEquals(p.Element, element))?.Node;

                //The first element of an ordered container is where its execution starts.
                if (container is IStackContainer stack)
                    return stackChildren(stack).FirstOrDefault()?.Node;

                return null;
            }
        }

        public Service(BlazorDiagram designer, Action updateState) {
            this.designer = designer;

            this.designer.SelectionChanged += selectionChanged;
            this.designer.PointerDoubleClick += pointerDoubleClick;
            this.designer.PointerDown += pointerDown;
            this.designer.PointerMove += pointerMove;
            this.designer.PointerUp += pointerUp;
            this.designer.PanChanged += panChanged;
            this.designer.ZoomChanged += zoomChanged;
            this.designer.KeyDown += keyDown;
            this.designer.ContainerChanged += onContainerChanged;
            this.designer.Links.Added += linksAdded;
            this.designer.Links.Removed += linksRemoved;

            this.updateState = updateState;
        }


        public void Dispose() {
            this.designer.SelectionChanged -= selectionChanged;
            this.designer.PointerDoubleClick -= pointerDoubleClick;

            this.designer.PointerDown -= pointerDown;
            this.designer.PointerMove -= pointerMove;
            this.designer.PointerUp -= pointerUp;

            this.designer.PanChanged -= panChanged;
            this.designer.ZoomChanged -= zoomChanged;
            this.designer.KeyDown -= keyDown;
            this.designer.ContainerChanged -= onContainerChanged;
            this.designer.Links.Added -= linksAdded;
            this.designer.Links.Removed -= linksRemoved;

            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// True when the ports have to be measured again before the next frame is painted.
        /// </summary>
        public bool PortGeometryDirty => portGeometryDirty;

        /// <summary>
        /// Asks for a port re-measurement. The measure itself is deferred to <see cref="RefreshPortGeometry"/>
        /// because the library reads the port rectangles from the DOM: doing it right away would capture the
        /// layout of the *previous* frame (the nodes were just re-arranged) and the port would stay at a stale
        /// position, which is what makes links look detached from the node borders.
        /// </summary>
        private void requestPortGeometryRefresh() {
            if (portGeometryDirty)
                return;

            portGeometryDirty = true;
            updateState();
        }

        /// <summary>
        /// Recomputes the port rectangles and the link routes of every displayed node. Ports are placed from
        /// the node box (see <see cref="DefaultNode.UpdatePortGeometry"/>) instead of the DOM measurement of
        /// the library, so a node that was moved, expanded or resized keeps its links attached.
        /// </summary>
        public void RefreshPortGeometry() {
            portGeometryDirty = false;

            foreach (var item in items.Where(i => i.Node != null)) {
                //A card of the column of an ordered container has no ports and no connections to refresh.
                if (item.Node.IsStackChild || !IsDisplayed(item.Node))
                    continue;

                item.Node.UpdatePortGeometry();
            }

            foreach (var item in items.Where(i => i.Node != null)) {
                if (!item.Node.IsStackChild)
                    item.Node.RefreshLinks();
            }

            //A card that grew (an expanded node, a branch holding an activity) is laid out again so it does not
            //overlap the next one; the layout only moves nodes it placed itself.
            Path.LastOrDefault()?.Reference?.Node.RelayoutChildren();

            updateState();
        }

        private void onContainerChanged() {
            CompletePendingInitialLayout();
            requestPortGeometryRefresh();
        }

        /// <summary>Re-measures the ports and rebuilds the link routes after the node card changed its size.</summary>
        private void onNodeSizeChanged(NodeModel model) {
            if (model is not DefaultNode)
                return;

            requestPortGeometryRefresh();
        }

        /// <summary>Delete removes the selected connections or the selected nodes.</summary>
        private void keyDown(Blazor.Diagrams.Core.Events.KeyboardEventArgs e) {
            //Alt with the arrows moves the selected card inside the column of an opened ordered container.
            if (e.AltKey && e.Key is "ArrowUp" or "ArrowDown") {
                if (selectedItems.Count == 1
                    && MoveInStack(selectedItems[0].Node, e.Key == "ArrowUp" ? -1 : 1))
                    return;
            }

            if (e.Key is not ("Delete" or "Backspace"))
                return;

            if (selectedLinks.Count > 0) {
                foreach (var (source, target) in selectedLinks.ToList()) {
                    if (currentGraphContainer is { } graph && graph.TryDisconnect(source, target))
                        graph.Refresh();
                }

                selectedLinks.Clear();
                notifyModelChanged();
                return;
            }

            if (selectedItems.Count == 0)
                return;

            foreach (var item in selectedItems.ToList())
                Delete(item.Node);

            selectedItems.Clear();
            notifyModelChanged();
        }

        public void Delete(Activity.DefaultNode node) {
            var item = getById(node.Id);
            if (item is null)
                return;

            RemoveAllLinks(node);
            selectedLinks.RemoveAll(l => l.Item1 == item || l.Item2 == item);

            designer.Nodes.Remove(node);

            //A branch child belongs to the card that renders it, not to the opened container.
            if (node.EmbeddedOwner is { } owner)
                owner.RemoveElement(item.Element);
            else
                Path.LastOrDefault()?.Reference?.Node?.RemoveElement(item.Element);

            removeEmbeddedDescendants(node);

            selectedItems.Remove(item);
            items.Remove(item);
            notifyModelChanged();
            updateState();
        }

        /// <summary>
        /// Add by activity type
        /// </summary>
        public (bool hasAdded, ActivityDesignerPair result) AddActivity(Type activityType, params Type[] types) =>
            addActivity(activityType, null, types);

        /// <summary>Adds an activity at its drop position before the diagram renders the new node.</summary>
        public (bool hasAdded, ActivityDesignerPair result) AddActivity(
            Type activityType,
            Diagrams.Core.Geometry.Point initialPosition,
            params Type[] types) =>
            addActivity(activityType, initialPosition, types);

        private (bool hasAdded, ActivityDesignerPair result) addActivity(
            Type activityType,
            Diagrams.Core.Geometry.Point? initialPosition,
            Type[] types) {
            object? activityObject;
            if (types != null && types.Length > 0) {
                activityObject = Activator.CreateInstance(activityType.MakeGenericType(types));
            } else {
                activityObject = Activator.CreateInstance(activityType);
            }

            if (activityObject == null)
                return (false, default!);

            var entry = Path.LastOrDefault();
            var openContainer = entry?.Reference?.Node;
            var elementType = activityObject.GetType();

            //A slot (a branch region of a card) holds a single activity, so the drop goes straight into it
            //instead of through AddChild on the opened container.
            var slot = DropSlot;
            DropSlot = null;
            if (slot != null) {
                if (activityObject is not System.Activities.Activity activity)
                    return (false, default!);

                //The child is rendered by the card that holds the branch, not as a node of the diagram.
                var attached = addElement(activity, addNode: false, initialPosition);
                slot.Attach(attached);
                attached.Node.IsEmbedded = true;
                attached.Node.EmbeddedOwner = slot.Owner;
                createEmbeddedChildren(attached.Node, new HashSet<DefaultNode>());

                notifyModelChanged();
                return (true, attached);
            }

            var target = DropTarget ?? openContainer;

            //The target must accept the element (keeps non-activity elements such as State or FlowDecision
            //out of containers that only accept Activity children).
            if (target == null || !target.CanAdd(elementType.IsGenericType ? elementType.GetGenericTypeDefinition() : elementType))
                return (false, default!);

            // A drop target that is not the opened container adds the child inline (the branch region
            // shows the child, so no separate node is placed on the diagram).
            var inline = DropTarget != null && !ReferenceEquals(DropTarget, openContainer);
            DropTarget = null;

            var result = addElement(activityObject, addNode: !inline, initialPosition);

            //A child of a card that is not the opened container is drawn inside that card, exactly like a branch
            //child, so it gets no node on the surface.
            if (inline) {
                result.Node.IsEmbedded = true;
                result.Node.EmbeddedOwner = target;
                createEmbeddedChildren(result.Node, new HashSet<DefaultNode>());
            }

            //A drop into an ordered container lands at the index of the drop point; anywhere else the child is
            //appended (containers) or takes the branch it was dropped on (region targets).
            if (target is IStackContainer stack) {
                var index = DropInsertIndex ?? stack.Count;
                resetStackInteraction();
                stack.InsertChild(index, result);
            } else {
                target.AddChild(result);
            }

            notifyModelChanged();

            return (true, result);
        }

        public ActivityBuilder GetActivityBuilder() {
            return this.activityBuilder;
        }

        /// <summary>Requests a UI refresh from a node (for example when a branch child is cleared).</summary>
        public void NotifyStateChanged() {
            notifyModelChanged();
            updateState();
        }

        /// <summary>Marks the schema as changed and lets listeners re-run validation.</summary>
        private void notifyModelChanged() {
            ModelChanged?.Invoke();
            if (isDirty)
                return;

            isDirty = true;
            DirtyChanged?.Invoke();
        }

        /// <summary>Clears the unsaved-changes flag (after saving or after loading a schema).</summary>
        public void MarkSaved() {
            if (!isDirty)
                return;

            isDirty = false;
            DirtyChanged?.Invoke();
        }

        /// <summary>Replaces the per-activity validation messages with the last validation results.</summary>
        public void SetValidationErrors(System.Activities.Activity? implementation, IEnumerable<System.Activities.Validation.ValidationError> errors) {
            validationErrors.Clear();
            foreach (var error in errors) {
                if (error.Source == null)
                    continue;

                if (!validationErrors.TryGetValue(error.Source, out var list))
                    validationErrors[error.Source] = list = new List<string>();

                var message = string.IsNullOrWhiteSpace(error.PropertyName) ? error.Message : $"{error.PropertyName}: {error.Message}";
                if (!list.Contains(message))
                    list.Add(message);
            }

            elementsWithErrors.Clear();
            if (implementation != null)
                markElementsWithErrors(implementation, new HashSet<object>(ReferenceEqualityComparer.Instance));

            updateState();
        }

        /// <summary>
        /// Marks the elements that hold a validation error, in themselves or in a nested element. A card
        /// without nodes for its content (a container that is not opened, for example) shows an error this
        /// way, so a broken element can always be reached from the outside.
        /// </summary>
        private bool markElementsWithErrors(object element, HashSet<object> visited) {
            if (!visited.Add(element))
                return elementsWithErrors.Contains(element);

            var hasErrors = ErrorCount(element) > 0;
            foreach (var child in ModelTree.Children(element))
                if (markElementsWithErrors(child, visited))
                    hasErrors = true;

            if (hasErrors)
                elementsWithErrors.Add(element);

            return hasErrors;
        }

        /// <summary>Validation messages of one model element (an activity, a State, a FlowNode, ...).</summary>
        public IReadOnlyList<string> ErrorsFor(object? element) =>
            element != null && validationErrors.TryGetValue(element, out var list) ? list : Array.Empty<string>();

        public int ErrorCount(object? element) => ErrorsFor(element).Count;

        /// <summary>Whether the element itself or anything inside it has validation messages.</summary>
        public bool HasErrorsInTree(object? element) =>
            element != null && elementsWithErrors.Contains(element);

        public void SetActivityBuilder(ActivityBuilder activityBuilder) {
            resetStackInteraction();
            designer.Nodes.Clear();
            designer.Links.Clear();
            items.Clear();
            selectedItems.Clear();
            selectedLinks.Clear();
            Path.Clear();
            Variables.Clear();
            this.activityBuilder = activityBuilder;

            var da = new DynamicActivity {
                Implementation = () => activityBuilder.Implementation,
                DisplayName = "ActivityBuilder"
            };
            activityBuilder.Properties.ToList().ForEach(p => da.Properties.Add(p));
            activityBuilder.Constraints.ToList().ForEach(p => da.Constraints.Add(p));
            activityBuilder.Attributes.ToList().ForEach(p => da.Attributes.Add(p));
            var pair = addActivity(da);

            Path.Clear();
            Path.Add(new(pair));
            updatePath();
            MarkSaved();
            ModelChanged?.Invoke();
        }

        /// <summary>Sets the single implementation activity of the current ActivityBuilder.</summary>
        internal void SetRootImplementation(System.Activities.Activity? activity) {
            activityBuilder.Implementation = activity;
        }

        /// <summary>
        /// Completes the initial layout once the browser has measured the diagram viewport. This avoids
        /// leaving a new root activity at the world origin when the editor was initialized before layout.
        /// </summary>
        public void CompletePendingInitialLayout() {
            if (!pendingInitialLayout || VisibleViewport == null)
                return;

            pendingInitialLayout = false;
            updatePath();
            requestPortGeometryRefresh();
        }

        public void Open(Activity.DefaultNode node) {
            var item = getById(node.Id);
            if (item is null)
                return;

            //A card can be opened from the card that draws it, so the containers between the surface that is
            //shown and that card become part of the path as well: the breadcrumb then leads back through them.
            var owners = new List<ActivityDesignerPair>();
            for (var owner = item.Node.EmbeddedOwner; owner != null; owner = owner.EmbeddedOwner) {
                if (getById(owner.Id) is { } ownerItem && !Path.Any(p => ReferenceEquals(p.Reference, ownerItem)))
                    owners.Add(ownerItem);
            }

            owners.Reverse();
            foreach (var owner in owners)
                Path.Add(new PathItem(owner));

            Path.Add(new PathItem(item));
            updatePath();

        }

        public void OpenPath(PathItem pathItem) {
            if (Path.Contains(pathItem) == false)
                return;

            while (Path.Last() != pathItem)
                Path.RemoveAt(Path.Count - 1);

            updatePath();
        }

        public bool CheckAddActivity(Type activityType) {
            if (activityType == null)
                return false;

            var elementType = activityType.IsGenericType ? activityType.GetGenericTypeDefinition() : activityType;

            //A branch region of a card takes a single activity of any kind.
            if (DropSlot != null)
                return typeof(System.Activities.Activity).IsAssignableFrom(elementType);

            //The container that is opened takes the element itself.
            var openContainer = Path.LastOrDefault()?.Reference?.Node;
            if (openContainer is { IsContainer: true } && openContainer.CanAdd(elementType))
                return true;

            //A card of the surface takes it as well: a branch region on the card, or the list an ordered
            //container draws inside itself. A card rendered inside a branch is opened before anything is
            //added to it.
            return items.Any(item => takesChildren(item.Node, elementType));
        }

        /// <summary>Whether the card accepts the element itself, as a branch or as the children of its list.</summary>
        private static bool takesChildren(DefaultNode node, Type elementType) =>
            (node.IsContainer && node.CanAdd(elementType)) || node.Slots.Count > 0;

        /// <summary>Whether a node is currently shown on the diagram.</summary>
        public bool IsDisplayed(DefaultNode node) => designer.Nodes.Contains(node);

        /// <summary>The graph container currently opened in the editor, if any (Flowchart, StateMachine).</summary>
        private IGraphContainer? currentGraphContainer => Path.LastOrDefault()?.Reference?.Node as IGraphContainer;

        private ActivityDesignerPair? findPair(NodeModel? node) =>
            node == null ? null : items.FirstOrDefault(p => ReferenceEquals(p.Node, node));

        /// <summary>
        /// Node at the end of a link anchor. Handles both port anchors (used while the user draws a link)
        /// and node anchors (used for links created from the model).
        /// </summary>
        private static NodeModel? nodeOf(Anchor? anchor) => anchor?.Model switch {
            NodeModel node => node,
            PortModel port => port.Parent,
            _ => null
        };

        internal void RemoveAllLinks(DefaultNode node) {
            foreach (var link in designer.Links.OfType<LinkModel>().Where(l => nodeOf(l.Source) == node || nodeOf(l.Target) == node).ToList())
                removeLink(link);
        }

        internal LinkModel LinkFromTo(ActivityDesignerPair from, ActivityDesignerPair to, string? label = null) {
            //Port anchors: the ports are placed on the node border and the library rebuilds the link geometry
            //afterwards, so the line follows the node. They are also what OrthogonalRouter needs in order to
            //build right-angled (Workflow Foundation style) routes.
            var sourcePort = from.Node.OutcomingPort;
            var targetPort = to.Node.IncomingPort;
            if (linkPorts.TryGetValue((from, to), out var chosen)) {
                sourcePort = PortOf(from.Node, chosen.source, expectedOutgoing: true);
                targetPort = PortOf(to.Node, chosen.target, expectedOutgoing: false);
            }

            var linkModel = new LinkModel(
                new SinglePortAnchor(sourcePort),
                new SinglePortAnchor(targetPort)) {
                TargetMarker = LinkMarker.Arrow
            };

            if (!string.IsNullOrWhiteSpace(label))
                linkModel.AddLabel(label);

            addLink(linkModel);

            //A small × next to the hovered link removes the connection: removing the link raises
            //Links.Removed, which translates it into TryDisconnect of the open container.
            designer.Controls.AddFor(linkModel, ControlsType.OnHover)
                .Add(new RemoveControl(new LinkPathPositionProvider(0.6, 0, -16)));

            return linkModel;
        }

        /// <summary>Adds a link without re-entering the user link handlers (the model is already up to date).</summary>
        private void addLink(LinkModel link) {
            suppressLinkSync = true;
            try { designer.Links.Add(link); } finally { suppressLinkSync = false; }
        }

        /// <summary>Removes a link without re-entering the user link handlers.</summary>
        private void removeLink(LinkModel link) {
            suppressLinkSync = true;
            try { designer.Links.Remove(link); } finally { suppressLinkSync = false; }
        }

        /// <summary>A link added to the diagram: either an ongoing drag link or a completed one.</summary>
        private void linksAdded(BaseLinkModel model) {
            if (suppressLinkSync || model is not LinkModel link)
                return;

            if (!link.IsAttached) {
                //Ongoing drag link: it still has a floating end, so wait until the user attaches a target.
                link.TargetAttached += linkTargetAttached;
                return;
            }

            applyOrDropLink(link);
        }

        private void linkTargetAttached(BaseLinkModel model) {
            model.TargetAttached -= linkTargetAttached;
            applyOrDropLink(model);
        }

        /// <summary>Translates a finished link into a model connection of the open graph container.</summary>
        private void applyOrDropLink(BaseLinkModel model) {
            if (suppressLinkSync || model is not LinkModel link)
                return;

            var from = findPair(nodeOf(link.Source));
            var to = findPair(nodeOf(link.Target));
            if (from != null && to != null && currentGraphContainer is { } graph && graph.TryConnect(from, to)) {
                //Keep the anchors the user dropped on: the link is rebuilt from the model afterwards.
                linkPorts[(from, to)] = (PortAlignmentOf(link.Source, from.Node.OutcomingPort.Alignment),
                    PortAlignmentOf(link.Target, to.Node.IncomingPort.Alignment));
                graph.Refresh();
                notifyModelChanged();
                return;
            }

            //Not a valid connection for the current container: drop the drawn link.
            removeLink(link);
            updateState();
        }

        /// <summary>A link removed by the user: remove the matching model connection.</summary>
        private void linksRemoved(BaseLinkModel model) {
            if (suppressLinkSync || model is not LinkModel link)
                return;

            var from = findPair(nodeOf(link.Source));
            var to = findPair(nodeOf(link.Target));
            if (from != null && to != null && currentGraphContainer is { } graph && graph.TryDisconnect(from, to)) {
                linkPorts.Remove((from, to));
                graph.Refresh();
                notifyModelChanged();
            }
        }

        /// <summary>Alignment of the port a link end is anchored on, or the fallback one.</summary>
        private static PortAlignment PortAlignmentOf(Anchor? anchor, PortAlignment fallback) =>
            anchor is SinglePortAnchor { Port: { } port } ? port.Alignment : fallback;

        /// <summary>
        /// Port to anchor a link end on: the one the user picked while drawing, when it still exists and still
        /// has the right direction, otherwise the default incoming/outgoing port of the node.
        /// </summary>
        private static PortModel PortOf(DefaultNode node, PortAlignment? preferred, bool expectedOutgoing) {
            if (preferred is { } alignment) {
                var chosen = node.Ports.FirstOrDefault(p => p.Alignment == alignment
                    && (expectedOutgoing ? p is GraphOutPort : p is GraphInPort));
                if (chosen != null)
                    return chosen;
            }

            return expectedOutgoing ? node.OutcomingPort : node.IncomingPort;
        }

        public ActivityDesignerPair? FindPair(object element) => this.items.FirstOrDefault(p => ReferenceEquals(p.Element, element));
        internal ActivityDesignerPair GetPair(System.Activities.Activity source) => this.items.First(p => p.Activity == source);
        internal ActivityDesignerPair GetPair(DefaultNode node) => this.items.First(p => p.Node == node);

        /// <summary>Control component registered for the node, used to render a branch child inside its owner card.</summary>
        public Type? GetControlType(DefaultNode node) => designer.GetComponent(node);

        /// <summary>
        /// Selects a node from the UI. A branch child is rendered inside another card instead of the diagram,
        /// so the diagram selection never picks it up.
        /// </summary>
        public void Select(DefaultNode node) {
            var item = getById(node.Id);
            if (item is null)
                return;

            designer.SelectModel(node, true);

            if (!item.Node.IsEmbedded)
                clearEmbeddedSelection();

            if (!selectedItems.Contains(item))
                selectedItems.Add(item);

            updateState();
        }

        /// <summary>Clears the selection of the branch children, which the diagram does not track.</summary>
        private void clearEmbeddedSelection() {
            foreach (var item in selectedItems.Where(i => i.Node.IsEmbedded).ToList()) {
                designer.UnselectModel(item.Node);
                selectedItems.Remove(item);
            }
        }

        private ActivityDesignerPair? getById(string id) => this.items.FirstOrDefault(p => p.Node.Id == id);

        private void selectionChanged(Diagrams.Core.Models.Base.SelectableModel obj) {
            if (obj is NodeModel) {
                var item = getById(obj.Id);
                if (item == null)
                    return;

                if (obj.Selected) {
                    //A node of the diagram takes the selection over from a branch child rendered inside a card.
                    if (!item.Node.IsEmbedded)
                        clearEmbeddedSelection();

                    if (!selectedItems.Contains(item))
                        selectedItems.Add(item);
                } else
                    selectedItems.Remove(item);

                updateState();
            } else
                if (obj is LinkModel link) {
                    var sourceNode = nodeOf(link.Source);
                    var targetNode = nodeOf(link.Target);
                    if (sourceNode == null || targetNode == null)
                        return;

                    var source = getById(sourceNode.Id);
                    var target = getById(targetNode.Id);

                    if (source == null || target == null)
                        return;

                    if (obj.Selected) {
                        selectedLinks.Add((source, target));
                    } else {
                        selectedLinks.Remove((source, target));
                    }
                }
        }

        private void pointerDoubleClick(Model? arg1, Diagrams.Core.Events.PointerEventArgs arg2) {
            if (arg1 is null)
                return;

            var item = getById(arg1.Id);
            if (item == null || item.Node.IsContainer == false)
                return;

            Open(item.Node);
        }

        private void pointerUp(Model? model, Diagrams.Core.Events.PointerEventArgs arg) {
            //A click anywhere else takes the selection over from a branch child rendered inside a card. The
            //click that selects such a child runs after this handler, so the order is not a problem.
            clearEmbeddedSelection();

            //A released card of the column takes the place the drag showed, instead of keeping the pixels it
            //was dropped on.
            if (draggedStackChild is { } dragged && OpenedStack is { } stack) {
                finishReorder(stack, dragged);
                return;
            }

            if (model is null)
                return;

            if (arg.ClientX > 50 || arg.ClientY > 50) {
                if (model is DefaultNode node) {
                    node.UpdateViewState();
                    updateState();
                }
            }
        }
        private void pointerDown(Model? model, Diagrams.Core.Events.PointerEventArgs arg) {
            //Only a card of the column of the opened ordered container can be dragged to another index.
            draggedStackChild = model is DefaultNode { IsStackChild: true } node && OpenedStack != null
                ? node
                : null;
            reorderIndex = null;
            ReorderGapIndex = null;
            IsReordering = false;
        }

        private void pointerMove(Model? model, Diagrams.Core.Events.PointerEventArgs arg) {
            //The library reports every move over the canvas, so the state of the drag is only followed while a
            //button is down: a press that ended outside the canvas must not leave a card reordering.
            if (arg.Buttons == 0)
                return;

            if (draggedStackChild is { } dragged && OpenedStack is { } stack)
                updateReorder(stack, dragged);
        }

        /// <summary>
        /// Reads the place the dragged card would take from the order of the column: the card lands before the
        /// first card whose middle is below its own middle. The column shows that place while the drag changes
        /// the order, and the order is applied when the card is released.
        /// </summary>
        private void updateReorder(IStackContainer stack, DefaultNode dragged) {
            var others = stackChildren(stack).Where(p => !ReferenceEquals(p.Node, dragged)).ToList();
            var index = placementAmong(others, dragged.CenterPosition.Y);

            var gap = index < others.Count
                ? stack.IndexOf(others[index].Element)
                : others.Count > 0
                    ? stack.IndexOf(others[others.Count - 1].Element) + 1
                    : 0;

            var reordering = index != stack.IndexOf(dragged.Element);
            if (reorderIndex == index && ReorderGapIndex == gap && IsReordering == reordering)
                return;

            reorderIndex = index;
            ReorderGapIndex = gap;
            IsReordering = reordering;
            updateState();
        }

        /// <summary>
        /// Index a card of the column takes from the place it was dragged to. Null when the opened container is
        /// not an ordered one or the card does not belong to it.
        /// </summary>
        public int? StackPlacementFor(DefaultNode dragged) {
            if (OpenedStack is not { } stack || !dragged.IsStackChild)
                return null;

            var others = stackChildren(stack).Where(p => !ReferenceEquals(p.Node, dragged)).ToList();
            return placementAmong(others, dragged.CenterPosition.Y);
        }

        /// <summary>
        /// Place an element takes among the other cards of the column: the number of cards whose middle is above
        /// the given position, which is where the element goes once it is taken out of the column.
        /// </summary>
        private static int placementAmong(IReadOnlyList<ActivityDesignerPair> others, double y) {
            var index = 0;
            while (index < others.Count && y > others[index].Node.CenterPosition.Y)
                index++;

            return index;
        }

        /// <summary>Applies the order the user dragged a card to, and puts the column back in place.</summary>
        private void finishReorder(IStackContainer stack, DefaultNode dragged) {
            var from = stack.IndexOf(dragged.Element);
            var to = reorderIndex;
            resetStackInteraction();

            if (to is { } index && from >= 0 && index != from)
                stack.MoveChild(from, index);

            stack.LayoutChildren();
            updateState();
        }

        /// <summary>Forgets the drags and the drop place of an ordered container, which the next interaction sets again.</summary>
        private void resetStackInteraction() {
            draggedStackChild = null;
            DraggedInlineChild = null;
            reorderIndex = null;
            ReorderGapIndex = null;
            IsReordering = false;
            DropInsertIndex = null;
        }

        /// <summary>The displayed children of a stack container, in model order.</summary>
        private IEnumerable<ActivityDesignerPair> stackChildren(IStackContainer stack) =>
            items.Where(p => p.Node.IsStackChild && stack.IndexOf(p.Element) >= 0)
                .OrderBy(p => stack.IndexOf(p.Element));

        /// <summary>Index of a card in the column of the opened ordered container, or -1.</summary>
        public int StackIndexOf(DefaultNode node) => OpenedStack?.IndexOf(node.Element) ?? -1;

        /// <summary>
        /// Place a new element dropped at the given diagram point takes in the opened stack container: before the
        /// first card whose middle is below the point, or at the end of the column. Null when no ordered
        /// container is opened, which is also how the column learns that the caret has to disappear.
        /// </summary>
        public void UpdateDropInsertIndex(Diagrams.Core.Geometry.Point position) {
            //A card that owns the drop (a branch region, or the list a container draws inside itself) decides the
            //place itself, so the surface must not overwrite it with a place of its own.
            if (DropTarget != null || DropSlot != null)
                return;

            var index = OpenedStack is { } stack
                ? stackChildren(stack).Count(p => position.Y >= p.Node.CenterPosition.Y)
                : (int?)null;

            if (DropInsertIndex == index)
                return;

            DropInsertIndex = index;
            updateState();
        }

        /// <summary>Shows the place a dropped element takes in the list of an ordered container.</summary>
        public void SetDropInsertIndex(int index) {
            if (DropInsertIndex == index)
                return;

            DropInsertIndex = index;
            updateState();
        }

        /// <summary>Forgets the place the column showed for a drop, once the drag or the drop is over.</summary>
        public void ClearDropInsertIndex() {
            if (DropInsertIndex is null)
                return;

            DropInsertIndex = null;
            updateState();
        }

        /// <summary>Whether the column draws the place of a new element above the given card.</summary>
        public bool StackCaretAbove(DefaultNode node) {
            if (DropTarget != null || DropSlot != null)
                return false;

            var index = StackIndexOf(node);
            if (index < 0)
                return false;

            return DropInsertIndex == index || (IsReordering && ReorderGapIndex == index);
        }

        /// <summary>Whether the column draws the place of a new element below the given card.</summary>
        public bool StackCaretBelow(DefaultNode node) {
            if (DropTarget != null || DropSlot != null)
                return false;

            var index = StackIndexOf(node);
            if (index < 0 || index != StackCount - 1)
                return false;

            return DropInsertIndex == StackCount || (IsReordering && ReorderGapIndex == StackCount);
        }

        /// <summary>Moves a card of an ordered container one place up or down.</summary>
        public bool MoveInStack(DefaultNode node, int delta) {
            if (stackOf(node) is not { } stack)
                return false;

            var index = stack.IndexOf(node.Element);
            if (index < 0)
                return false;

            var target = index + delta;
            if (target < 0 || target >= stack.Count)
                return false;

            stack.MoveChild(index, target);
            updateState();
            return true;
        }

        /// <summary>
        /// Ordered container a card belongs to: the card that draws it inside itself (the list of a container
        /// shown on a surface), or the container that is opened and draws it in its column.
        /// </summary>
        private IStackContainer? stackOf(DefaultNode node) {
            if (node.EmbeddedOwner is IStackContainer owner)
                return owner;

            return node.IsStackChild ? Path.LastOrDefault()?.Reference?.Node as IStackContainer : null;
        }

        /// <summary>Starts dragging a card inside the inline list of a card.</summary>
        public void StartInlineDrag(DefaultNode node) {
            DraggedInlineChild = node;
            DropTarget = null;
            DropSlot = null;
        }

        /// <summary>Ends a drag inside an inline list, whether or not the card was dropped on a place.</summary>
        public void EndInlineDrag() {
            if (DraggedInlineChild is null)
                return;

            //The place a *dropped* element takes is kept: an activity dragged from the toolbox still lands where
            //the list pointed when its drop runs after this.
            DraggedInlineChild = null;
        }

        /// <summary>
        /// Makes a card the drop target and shows the place a dropped element takes in its inline list: the gap
        /// before the child at the given index. Used by the card that draws the list, and by its gaps.
        /// </summary>
        public void SetInlineDropTarget(DefaultNode owner, int index) {
            DropTarget = owner;
            DropSlot = null;
            SetDropInsertIndex(index);
        }

        /// <summary>
        /// Moves a card of an inline list to the place a drop showed. The gap index counts the children of the
        /// list as they are now, so the card is taken out of the list first.
        /// </summary>
        public bool MoveInlineChild(DefaultNode dragged, int gapIndex) {
            if (stackOf(dragged) is not { } stack)
                return false;

            var from = stack.IndexOf(dragged.Element);
            if (from < 0)
                return false;

            var target = gapIndex > from ? gapIndex - 1 : gapIndex;
            if (target == from)
                return false;

            stack.MoveChild(from, target);
            updateState();
            return true;
        }

        private void zoomChanged() {
            //this.Path.Last().Reference.Node.
            //throw new NotImplementedException();
        }

        private void panChanged() {
            //throw new NotImplementedException();
        }

        private void updatePath() {
            //TODO: for variable try use
            //System.Activities.ScopeUtils.GetLocals(this Activity activity)

            this.designer.Nodes.Clear();
            this.designer.Links.Clear();

            this.selectedItems.Clear();
            this.selectedLinks.Clear();
            resetStackInteraction();

            //Keep only the pairs of the opened path; children are recreated by LoadChilds
            items.RemoveAll(p => !Path.Any(x => x.Reference == p));

            //A node reached through the path is a node of the opened container again, not a card in a branch.
            foreach (var pair in items) {
                if (!pair.Node.IsEmbedded || !Path.Any(x => ReferenceEquals(x.Reference, pair)))
                    continue;

                pair.Node.IsEmbedded = false;
                pair.Node.EmbeddedOwner = null;
            }

            Variables.Clear();
            foreach (var item in Path.SelectMany(p => p.Node.GetVariables()))
                Variables.Add(item);

            Path.Last().Reference.Node.LoadElements(addElement);
            ensureEmbeddedChildren();

            pendingInitialLayout = VisibleViewport == null;
            updateState();
        }

        /// <summary>
        /// Creates the nodes of the activities the branches hold. A branch child is rendered inside its owner
        /// card instead of the diagram, but it still needs a node for its control, its selection and its
        /// validation badge.
        /// </summary>
        private void ensureEmbeddedChildren() {
            var visited = new HashSet<DefaultNode>();
            foreach (var item in items.ToList())
                createEmbeddedChildren(item.Node, visited);
        }

        private void createEmbeddedChildren(DefaultNode owner, HashSet<DefaultNode> visited) {
            if (!visited.Add(owner))
                return;

            //Containers hold several children on their own surface, so they expose no slots.
            foreach (var slot in owner.Slots) {
                if (slot.Held is not { } held)
                    continue;

                var pair = FindPair(held);
                if (pair is null) {
                    pair = addElement(held, addNode: false);
                    pair.Node.IsEmbedded = true;
                    pair.Node.EmbeddedOwner = owner;
                }

                //A branch may hold another branch holder, whose own branches are rendered the same way.
                createEmbeddedChildren(pair.Node, visited);
            }

            //Only a card that is actually drawn (on the surface or inside another card) renders the elements it
            //holds; an opened container shows them as nodes of the surface instead.
            if (!owner.IsEmbedded && !IsDisplayed(owner))
                return;

            foreach (var element in owner.InlineChildren) {
                var pair = FindPair(element);
                if (pair is null) {
                    pair = addElement(element, addNode: false);
                    pair.Node.IsEmbedded = true;
                    pair.Node.EmbeddedOwner = owner;
                }

                createEmbeddedChildren(pair.Node, visited);
            }
        }

        /// <summary>Drops the nodes rendered inside a removed node, which are not part of the diagram.</summary>
        private void removeEmbeddedDescendants(DefaultNode node) {
            foreach (var pair in items.Where(p => ReferenceEquals(p.Node.EmbeddedOwner, node)).ToList()) {
                removeEmbeddedDescendants(pair.Node);
                selectedItems.Remove(pair);
                items.Remove(pair);
            }
        }

        private void discoverPairs() {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies()) {
                Type[] types;
                try {
                    types = assembly.GetTypes();
                } catch (ReflectionTypeLoadException ex) {
                    types = ex.Types.OfType<Type>().ToArray();
                } catch (Exception) {
                    continue;
                }

                foreach (var type in types) {
                    if (type.GetCustomAttributes(typeof(PairAttribute), true).FirstOrDefault() is not PairAttribute attr)
                        continue;

                    if (!typePairAttributes.ContainsKey(attr.Activity))
                        typePairAttributes.Add(attr.Activity, new ActivityPairType(type, attr));
                }
            }
        }

        private ActivityDesignerPair addActivity(System.Activities.Activity activity) => addElement(activity);

        private ActivityDesignerPair addElement(object activity) => addElement(activity, addNode: true);

        private ActivityDesignerPair addElement(
            object activity,
            bool addNode,
            Diagrams.Core.Geometry.Point? initialPosition = null) {
            if (!typePairAttributes.Any())
                discoverPairs();

            var activityType = activity.GetType();
            DefaultNode? node;
            if (typePairAttributes.TryGetValue(activityType.IsGenericType ? activityType.GetGenericTypeDefinition() : activityType, out var pairT)) {
                if (activityType.IsGenericType) {
                    var genericTypes = activityType.GenericTypeArguments;
                    node = (Activator.CreateInstance(pairT.Type.MakeGenericType(genericTypes), this, activity) as Activity.DefaultNode)!;
                    if (designer.GetComponent(node) == null) {
                        designer.RegisterComponent(pairT.Type.MakeGenericType(genericTypes), pairT.PairAttribute.Control.MakeGenericType(genericTypes));
                    }
                } else {
                    node = (Activator.CreateInstance(pairT.Type, this, activity) as Activity.DefaultNode)!;
                    if (designer.GetComponent(node) == null) {
                        designer.RegisterComponent(pairT.Type, pairT.PairAttribute.Control);
                    }
                }

            } else {
                node = new DefaultNode(this, activity);
                if (designer.GetComponent(node) == null) {
                    designer.RegisterComponent(typeof(DefaultNode), typeof(DefaultControl));
                }
            }
            node.RestoreViewState();
            if (addNode && initialPosition is { } position)
                node.CenterPosition = position;
            if (addNode)
                designer.Nodes.Add(node);
            //The library measures the card in the browser (expand/collapse changes its size), so the port
            //rectangles have to be measured again; otherwise link ends stay at the old card border.
            node.SizeChanged += onNodeSizeChanged;
            ActivityDesignerPair result = new() { Activity = (activity as System.Activities.Activity)!, Element = activity, Node = node };
            items.Add(result);
            return result;
        }

        public void RefreshVariables() {
            Variables.Clear();
            foreach (var item in Path.SelectMany(p => p.Node.GetVariables()))
                Variables.Add(item);
        }

        private static ICollection<System.Activities.Variable>? getVariableCollection(object? activity) => activity switch {
            System.Activities.Statements.Sequence sequence => sequence.Variables,
            System.Activities.Statements.Flowchart flowchart => flowchart.Variables,
            System.Activities.Statements.DoWhile doWhile => doWhile.Variables,
            System.Activities.Statements.StateMachine stateMachine => stateMachine.Variables,
            //The editor shows the root as an ActivityBuilder wrapper (DynamicActivity) and its panel lists the
            //variables of the implementation (usually the root Sequence), so adds have to go there as well.
            System.Activities.DynamicActivity dynamicActivity => getVariableCollection(dynamicActivity.Implementation?.Invoke()),
            _ => null
        };

        public virtual void AddVariable<TActivity>(TActivity activity, string name, Type type, string defaultValue) where TActivity : class {
            var genType = typeof(System.Activities.Variable<>).MakeGenericType(type);
            object?[] constructorParams;
            try {
                var defType = Convert.ChangeType(defaultValue, type);
                constructorParams = new object?[] { name, defType };
            } catch {
                constructorParams = new object?[] { name };
            }
            var variable = Activator.CreateInstance(genType, constructorParams);
            if (variable != null)
                getVariableCollection(activity)?.Add((System.Activities.Variable)variable);
        }

        public virtual void RemoveVariable<TActivity>(TActivity activity, string name) where TActivity : class {
            var collection = getVariableCollection(activity);
            var variable = collection?.FirstOrDefault(p => p.Name == name);
            if (variable != null)
                collection!.Remove(variable);
        }

        public virtual void UpdateVariable<TActivity>(TActivity activity, string oldName, string name, Type type, string defaultValue) where TActivity : class {
            RemoveVariable(activity, oldName);
            AddVariable(activity, name, type, defaultValue);
        }
    }
}
