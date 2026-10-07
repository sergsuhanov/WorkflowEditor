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

        public event Action? SelectedOnMove;

        /// <summary>Raised when the workflow model changed (used to re-run validation).</summary>
        public event Action? ModelChanged;

        /// <summary>Raised when the unsaved-changes flag changes.</summary>
        public event Action? DirtyChanged;

        /// <summary>True when the schema contains changes that are not saved to XAML yet.</summary>
        public bool IsDirty => isDirty;

        /// <summary>The graph container currently opened in the editor, if any (Flowchart, StateMachine).</summary>
        public IGraphContainer? OpenedGraph => currentGraphContainer;

        /// <summary>True while the ActivityBuilder root is open in the editor.</summary>
        public bool IsRootPath => Path.Count == 1 && Path[0].Reference.Node is DynamicActivityNode;

        /// <summary>Whether the current canvas shows the root workflow or an open Flowchart.</summary>
        public bool ShowStartPresentation =>
            Path.Count == 0 || IsRootPath || Path.LastOrDefault()?.Reference?.Node is FlowchartNode;

        /// <summary>The ActivityBuilder implementation or Flowchart start element shown on this canvas.</summary>
        public DefaultNode? StartTargetNode {
            get {
                if (IsRootPath && activityBuilder?.Implementation is { } implementation)
                    return items.FirstOrDefault(p => ReferenceEquals(p.Activity, implementation))?.Node;

                if (Path.LastOrDefault()?.Reference?.Node is FlowchartNode flowchart &&
                    flowchart.StartElement is { } element)
                    return items.FirstOrDefault(p => ReferenceEquals(p.Element, element))?.Node;

                return null;
            }
        }

        public string StartHint {
            get {
                if (Path.Count == 0 || IsRootPath)
                    return "Drop the first activity here";

                return Path.LastOrDefault()?.Reference?.Node is FlowchartNode { Count: 0 }
                    ? "Add a node to create the flowchart start"
                    : "Choose the start node in Flowchart properties";
            }
        }

        public Service(BlazorDiagram designer, Action updateState) {
            this.designer = designer;

            this.designer.SelectionChanged += selectionChanged;
            this.designer.PointerDoubleClick += pointerDoubleClick;
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
                if (!IsDisplayed(item.Node))
                    continue;

                item.Node.UpdatePortGeometry();
            }

            foreach (var item in items)
                item.Node?.RefreshLinks();

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

            //Remove element in parent
            Path.LastOrDefault()?.Reference?.Node?.RemoveElement(item.Element);

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

            var openContainer = Path.LastOrDefault()?.Reference?.Node;
            var target = DropTarget ?? openContainer;

            //The target must accept the element (keeps non-activity elements such as State or FlowDecision
            //out of containers that only accept Activity children).
            var elementType = activityObject.GetType();
            if (target == null || !target.CanAdd(elementType.IsGenericType ? elementType.GetGenericTypeDefinition() : elementType))
                return (false, default!);

            // A drop target that is not the opened container adds the child inline (the branch region
            // shows the child, so no separate node is placed on the diagram).
            var inline = DropTarget != null && !ReferenceEquals(DropTarget, openContainer);
            DropTarget = null;

            var result = addElement(activityObject, addNode: !inline, initialPosition);
            target.AddChild(result);
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
        public void SetValidationErrors(IEnumerable<System.Activities.Validation.ValidationError> errors) {
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

            updateState();
        }

        /// <summary>Validation messages of one model element (an activity, a State, a FlowNode, ...).</summary>
        public IReadOnlyList<string> ErrorsFor(object? element) =>
            element != null && validationErrors.TryGetValue(element, out var list) ? list : Array.Empty<string>();

        public int ErrorCount(object? element) => ErrorsFor(element).Count;

        /// <summary>All validation messages of an element as a single tooltip text.</summary>
        public string? ErrorSummary(object? element) {
            var errors = ErrorsFor(element);
            return errors.Count == 0 ? null : string.Join(Environment.NewLine, errors);
        }

        public void SetActivityBuilder(ActivityBuilder activityBuilder) {
            SelectedOnMove = null;
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

            var openContainer = Path.LastOrDefault()?.Reference?.Node;
            if (openContainer is DynamicActivityNode)
                return openContainer.CanAdd(elementType);

            if (openContainer is { IsContainer: true } && openContainer.CanAdd(elementType))
                return true;

            //A region on another container node (for example a collapsed StateMachine or Flowchart)
            //may be the actual drop target.
            return items.Any(item => item.Node.IsContainer && item.Node.CanAdd(elementType));
        }

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

        internal void RemoveLinkFromTo(ActivityDesignerPair from, ActivityDesignerPair to) {
            var link = designer.Links.OfType<LinkModel>().FirstOrDefault(p => nodeOf(p.Source) == from.Node && nodeOf(p.Target) == to.Node);
            if (link != null)
                removeLink(link);

            selectedLinks.Remove((from, to));
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

        private ActivityDesignerPair? getById(string id) => this.items.FirstOrDefault(p => p.Node.Id == id);

        private void selectionChanged(Diagrams.Core.Models.Base.SelectableModel obj) {
            if (obj is NodeModel) {
                var item = getById(obj.Id);
                if (item == null)
                    return;

                if (obj.Selected)
                    selectedItems.Add(item);
                else
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
            if (model is null)
                return;

            if (arg.ClientX > 50 || arg.ClientY > 50) {
                if (model is DefaultNode node) {
                    SelectedOnMove?.Invoke();

                    node.UpdateViewState();
                    updateState();
                }
            }
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
            this.SelectedOnMove = null;

            //Keep only the pairs of the opened path; children are recreated by LoadChilds
            items.RemoveAll(p => !Path.Any(x => x.Reference == p));

            Variables.Clear();
            foreach (var item in Path.SelectMany(p => p.Node.GetVariables()))
                Variables.Add(item);

            Path.Last().Reference.Node.LoadElements(addElement);
            pendingInitialLayout = VisibleViewport == null;
            updateState();
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
