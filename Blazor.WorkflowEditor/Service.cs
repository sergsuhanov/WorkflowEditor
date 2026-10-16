using System.Activities;
using System.Collections.ObjectModel;
using System.Reflection;
using Blazor.Diagrams;
using Blazor.Diagrams.Core;
using Blazor.Diagrams.Core.Anchors;
using Blazor.Diagrams.Core.Behaviors;
using Blazor.Diagrams.Core.Controls;
using Blazor.Diagrams.Core.Controls.Default;
using Blazor.Diagrams.Core.Geometry;
using Blazor.Diagrams.Core.Models;
using Blazor.Diagrams.Core.Models.Base;
using Blazor.Diagrams.Core.Positions;
using Blazor.WorkflowEditor.Activity;
using Blazor.WorkflowEditor.Activity.Flow;
using Microsoft.AspNetCore.Components.Web;

namespace Blazor.WorkflowEditor {
    /// <summary>
    /// The editor behind the surface: the schema it holds, the cards and the connections it is made of, and
    /// what it reports about them. The parts of it are here: the connections of a graph surface in
    /// `Service.Links.cs`, the cards in `Service.Cards.cs`, the surfaces in `Service.Graph.cs`, the validation
    /// in `Service.Validation.cs`, the history in `Service.History.cs` and the variables in
    /// `Service.Variables.cs`.
    /// </summary>
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

        /// <summary>
        /// End of a connection the pointer was pressed on, with the place of the press: the end is only taken
        /// away from the link once the pointer has moved, so that a press that stays where it was (a click that
        /// picks the link) leaves the connection alone.
        /// </summary>
        private (LinkModel Link, ActivityDesignerPair From, ActivityDesignerPair To, bool SourceEnd,
                 PortAlignment SourceEdge, double ClientX, double ClientY)? pendingLinkEnd;

        /// <summary>End of a connection that follows the pointer while the user moves it, or null.</summary>
        private (LinkModel Link, ActivityDesignerPair From, ActivityDesignerPair To, bool SourceEnd,
                 PortAlignment SourceEdge, PositionAnchor Floating)? movingLinkEnd;

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

        /// <summary>Raised when the workflow model changed (used to re-run validation).</summary>
        public event Action? ModelChanged;

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
        /// Card the START drag of the opened Flowchart points at, or null. It is highlighted as the place the
        /// start node lands, exactly like a drop target of an activity.
        /// </summary>
        public DefaultNode? StartDropTarget { get; private set; }

        /// <summary>True while the user points the START badge of the opened Flowchart at another card.</summary>
        public bool IsRebindingStart { get; private set; }

        public Service(BlazorDiagram designer, Action updateState) {
            this.designer = designer;

            this.designer.SelectionChanged += selectionChanged;
            this.designer.PointerDoubleClick += pointerDoubleClick;
            this.designer.PointerDown += pointerDown;
            this.designer.PointerMove += pointerMove;
            this.designer.PointerUp += pointerUp;
            this.designer.KeyDown += keyDown;
            this.designer.ContainerChanged += onContainerChanged;
            this.designer.Links.Added += linksAdded;
            this.designer.Links.Removed += linksRemoved;

            //The library starts a new link on every press on a connection point. A press on a point that already
            //receives a connection takes that connection's end instead, which this service decides on the same
            //event, and the point is locked for the gesture so the library leaves it alone. The behavior is
            //registered again here, after this service, so it reads that decision instead of making its own first.
            this.designer.UnregisterBehavior<Blazor.Diagrams.Core.Behaviors.DragNewLinkBehavior>();
            this.designer.RegisterBehavior(new Blazor.Diagrams.Core.Behaviors.DragNewLinkBehavior(this.designer));

            this.updateState = updateState;
        }

        public void Dispose() {
            this.designer.SelectionChanged -= selectionChanged;
            this.designer.PointerDoubleClick -= pointerDoubleClick;

            this.designer.PointerDown -= pointerDown;

            this.designer.PointerMove -= pointerMove;

            this.designer.PointerUp -= pointerUp;

            this.designer.KeyDown -= keyDown;
            this.designer.ContainerChanged -= onContainerChanged;
            this.designer.Links.Added -= linksAdded;
            this.designer.Links.Removed -= linksRemoved;

            GC.SuppressFinalize(this);
        }

        /// <summary>Delete removes the selected connections or the selected nodes.</summary>
        private void keyDown(Blazor.Diagrams.Core.Events.KeyboardEventArgs e) {
            //Ctrl+Z takes the last step back and Ctrl+Y (or Ctrl+Shift+Z) applies it again. The commands take the
            //place of the ones the browser would use on a page of its own.
            if (e.CtrlKey) {
                if (e.Key is "z" or "Z") {
                    if (e.ShiftKey)
                        Redo();
                    else
                        Undo();

                    return;
                }

                if (e.Key is "y" or "Y") {
                    Redo();
                    return;
                }

                //Ctrl+D adds a copy of the selected element behind it, while Ctrl+C and Ctrl+V put one on the
                //clipboard and add it to the opened container.
                if (e.Key is "d" or "D") {
                    DuplicateSelected();
                    return;
                }

                if (e.Key is "c" or "C") {
                    CopySelected();
                    return;
                }

                if (e.Key is "v" or "V") {
                    PasteCopied();
                    return;
                }
            }

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

        /// <summary>
        /// Puts a copy of a card right behind it, in the place that draws it: the surface of the opened container
        /// draws the copy as a card of its own, while a list drawn inside another card draws it inline, exactly
        /// like the original. On a graph surface the copy follows the original, and joins nothing: a copy carries
        /// the elements of the original, not its connections.
        /// </summary>
        private (bool hasAdded, ActivityDesignerPair result) copyBehind(ActivityDesignerPair original) {
            var owner = ownerOf(original.Node);
            var opened = Path.LastOrDefault()?.Reference?.Node;
            var inline = owner != null && !ReferenceEquals(owner, opened);
            var target = owner ?? opened;
            if (target == null)
                return (false, default!);

            //A branch (a slot of a card) holds one activity, so it has no room for a copy of the one it holds.
            if (owner != null && holdsAsSlot(owner, original.Element))
                return (false, default!);

            if (cloneActivityOf(original) is not { } copy)
                return (false, default!);

            var elementType = copy.GetType();
            if (!target.CanAdd(elementType.IsGenericType ? elementType.GetGenericTypeDefinition() : elementType))
                return (false, default!);

            //The place of the copy is read before it is placed: a list takes it right behind the original, while
            //a graph surface only puts it beside it.
            if (inline || target is IStackContainer) {
                var index = (target as IStackContainer)?.IndexOf(original.Element) ?? -1;
                if (index < 0)
                    return (false, default!);

                if (inline)
                    SetInlineDropTarget(target, index + 1);
                else
                    SetDropInsertIndex(index + 1);
            }

            var position = new Diagrams.Core.Geometry.Point(
                original.Node.CenterPosition.X + CopyOffset,
                original.Node.CenterPosition.Y + CopyOffset);

            var placed = placeActivity(copy, existing: null, existingOwner: null, initialPosition: position);
            resetStackInteraction();
            return placed;
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

            //A new activity has no node yet, so it gets one where it is placed.
            return activityObject == null
                ? (false, default!)
                : placeActivity(activityObject, existing: null, existingOwner: null, initialPosition);
        }

        /// <summary>
        /// Places an activity where the drop pointed: the branch region of a card, the list of an ordered
        /// container, or the container that takes it. A new activity gets a node of its own, while a card the user
        /// dragged inside an inline list keeps the node it is drawn with (<paramref name="existing"/> is that
        /// card's pair and <paramref name="existingOwner"/> the card that draws it): it leaves the container that
        /// drew it and only changes the one that owns it. A target that does not take the activity leaves the
        /// schema as it is.
        /// </summary>
        private (bool hasAdded, ActivityDesignerPair result) placeActivity(
            object activityObject,
            ActivityDesignerPair? existing,
            DefaultNode? existingOwner,
            Diagrams.Core.Geometry.Point? initialPosition) {
            var openContainer = Path.LastOrDefault()?.Reference?.Node;
            var elementType = activityObject.GetType();

            //A slot (a branch region of a card) holds a single activity, so the drop goes straight into it
            //instead of through AddChild on the opened container.
            var slot = DropSlot;
            DropSlot = null;
            if (slot != null) {
                if (activityObject is not System.Activities.Activity activity)
                    return (false, default!);

                //A card dropped on a region of the container it carries would close a cycle in the model.
                if (existing != null && wouldCarryItself(slot.Owner, existing.Node))
                    return (false, default!);

                //The child is drawn by the card that holds the branch, not as a node of the diagram.
                detachFromOwner(existing, existingOwner);
                var attached = existing ?? addElement(activity, addNode: false, initialPosition);
                slot.Attach(attached);
                adoptEmbedded(attached.Node, slot.Owner);
                createEmbeddedChildren(attached.Node, new HashSet<DefaultNode>());

                notifyModelChanged();
                return (true, attached);
            }

            var target = DropTarget ?? openContainer;

            //The target must accept the element (keeps non-activity elements such as State or FlowDecision
            //out of containers that only accept Activity children).
            if (target == null || !target.CanAdd(elementType.IsGenericType ? elementType.GetGenericTypeDefinition() : elementType))
                return (false, default!);

            //A card dropped on a container it carries would close a cycle in the model.
            if (existing != null && wouldCarryItself(target, existing.Node))
                return (false, default!);

            // A drop target that is not the opened container adds the child inline (the branch region
            // shows the child, so no separate node is placed on the diagram).
            var inline = DropTarget != null && !ReferenceEquals(DropTarget, openContainer);
            DropTarget = null;

            //The place the card already takes in the target list, read before it is taken out of that list:
            //the place the drag showed counts it, so the drop shifts by one.
            var from = target is IStackContainer list && existing != null ? list.IndexOf(existing.Element) : -1;

            detachFromOwner(existing, existingOwner);
            var result = existing ?? addElement(activityObject, addNode: !inline, initialPosition);

            if (inline) {
                //A child of a card that is not the opened container is drawn inside that card, exactly like a
                //branch child, so it gets no node on the surface.
                adoptEmbedded(result.Node, target);
                createEmbeddedChildren(result.Node, new HashSet<DefaultNode>());
            } else {
                //The opened container draws the card on its surface, so a card that another card drew (a
                //branch child, a card of an inline list) becomes a node of the canvas again.
                adoptSurface(result.Node);
            }

            //A drop into an ordered container lands at the index of the drop point; anywhere else the child is
            //appended (containers) or takes the branch it was dropped on (region targets).
            if (target is IStackContainer stack) {
                var index = DropInsertIndex ?? stack.Count;
                if (from >= 0 && index > from)
                    index--;

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

        /// <summary>
        /// Connection a press on a connection point takes, with the end of it that is moved. A connection that
        /// ends at the point is taken first, because the point is the handle of the connection that arrives
        /// there; a point nothing arrives at hands over the connection that leaves from it instead, so the
        /// connection is grabbed by its beginning as well as by its end — the beginning of a line sits on the
        /// point of the card it leaves from, where the line itself cannot be reached. A point that adds
        /// connections next to the ones it carries is never full, so it takes none and keeps drawing a new one.
        /// </summary>
        private (LinkModel Link, bool SourceEnd)? attachedLinkOf(PortModel port) {
            LinkModel? outgoing = null;
            foreach (var link in designer.Links.OfType<LinkModel>()) {
                if (link.Target is SinglePortAnchor target && ReferenceEquals(target.Port, port))
                    return (link, false);

                if (outgoing == null && link.Source is SinglePortAnchor source && ReferenceEquals(source.Port, port))
                    outgoing = link;
            }

            if (outgoing == null || port.Parent is not DefaultNode node || !node.PortReplacesConnection(port))
                return null;

            return (outgoing, true);
        }

        /// <summary>
        /// Ports the ends of a link take on the two cards it joins. A connection that follows the cards takes the
        /// points the cards as they stand ask for; every other connection takes the points it was given — the ones
        /// the user dragged its ends onto, or the points of the edges the model of the activity asks for.
        /// </summary>
        private (PortModel Source, PortModel Target) linkPorts(ActivityDesignerPair from, ActivityDesignerPair to,
            PortAlignment? sourceEdge, PortAlignment? targetEdge) {
            var sourceCanonical = sourceEdge ?? from.Node.OutcomingPort.Alignment;
            var targetCanonical = targetEdge ?? to.Node.IncomingPort.Alignment;
            if (DynamicLinks)
                return bestEnds(from.Node, to.Node, sourceCanonical, targetCanonical, taken: null);

            var chosen = linkPlaces.TryGetValue((from, to), out var picked) ? picked : savedPlaces(from, to);
            if (chosen is { } places)
                return (PortOf(from.Node, places.source, from.Node.OutcomingPort, source: true),
                    PortOf(to.Node, places.target, to.Node.IncomingPort, source: false));

            return (PortOnEdge(from.Node, sourceCanonical, from.Node.OutcomingPort, source: true),
                PortOnEdge(to.Node, targetCanonical, to.Node.IncomingPort, source: false));
        }

        /// <summary>
        /// Connection points a connection between two cards is drawn between while its ends follow the cards: of
        /// every pair of edges the two cards offer, the pair whose route is the cheapest. The route of a pair is
        /// measured with the router of the editor, so what is picked is what is drawn: a connection that can
        /// leave a card downwards and arrive on the side of the other one is not wrapped around both cards just
        /// because the two cards lie in a row.
        /// </summary>
        /// <param name="kept">Ends the connection has now, which are kept while no other pair is clearly better.</param>
        private (PortModel Source, PortModel Target) bestEnds(DefaultNode from, DefaultNode to,
            PortAlignment sourceCanonical, PortAlignment targetCanonical, BaseLinkModel? taken,
            (PortModel Source, PortModel Target)? kept = null) {
            (PortModel Source, PortModel Target)? best = null;
            var bestCost = double.MaxValue;

            foreach (var sourceEdge in from.EdgeCandidates(sourceCanonical, to)) {
                if (from.PortTowards(sourceEdge, to, taken) is not { } sourcePort)
                    continue;

                foreach (var targetEdge in to.EdgeCandidates(targetCanonical, from)) {
                    if (to.PortTowards(targetEdge, from, taken) is not { } targetPort)
                        continue;

                    if (endsCost(sourcePort, targetPort) is not { } cost || cost >= bestCost)
                        continue;

                    bestCost = cost;
                    best = (sourcePort, targetPort);
                }
            }

            //The points of the winning edges are then taken against each other instead of against the middles of
            //the two cards, which lines the ends up and removes the little jog between two edges that meet at an
            //angle.
            if (best is { } winning
                && from.PortTowards(winning.Source.Alignment, DefaultNode.ReferenceOn(winning.Source.Alignment, winning.Target), taken) is { } lined
                && to.PortTowards(winning.Target.Alignment, DefaultNode.ReferenceOn(winning.Target.Alignment, lined), taken) is { } linedTarget)
                best = (lined, linedTarget);

            //The ends a connection has are only moved to a cheaper pair when that pair saves more than a bend:
            //two routes that cost nearly the same would otherwise trade places while a card is being dragged.
            if (kept is { } current && endsCost(current.Source, current.Target) is { } currentCost
                && bestCost > currentCost - EndChoiceMargin)
                return current;

            return best ?? (from.PortTowards(sourceCanonical, to, taken) ?? from.OutcomingPort,
                to.PortTowards(targetCanonical, from, taken) ?? to.IncomingPort);
        }

        /// <summary>
        /// Edges a user picked for a connection of the open container, kept with the element the connection
        /// leaves from so that they outlive the schema: a line that was dragged onto another edge of a card is
        /// drawn there again after the workflow was saved and opened.
        /// </summary>
        private (PortPlace source, PortPlace target)? savedPlaces(ActivityDesignerPair from, ActivityDesignerPair to) =>
            currentGraphContainer is { } graph && graph.BranchKey(from, to) is { } key
                ? Blazor.WorkflowEditor.Activity.State.BranchPorts.Get(from.Element, key)
                : null;

        public ActivityDesignerPair? FindPair(object element) => this.items.FirstOrDefault(p => ReferenceEquals(p.Element, element));
        internal ActivityDesignerPair GetPair(System.Activities.Activity source) => this.items.First(p => p.Activity == source);
        internal ActivityDesignerPair GetPair(DefaultNode node) => this.items.First(p => p.Node == node);

        /// <summary>Control component registered for the node, used to render a branch child inside its owner card.</summary>
        public Type? GetControlType(DefaultNode node) => designer.GetComponent(node);

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
            //A press on a connection that never moved is a click that picks the link; the end of a connection
            //that did move is left on the point the pointer points at.
            pendingLinkEnd = null;
            DropLinkEnd(arg.ClientX, arg.ClientY);
            releasePressedPort();

            //A click anywhere else takes the selection over from a branch child rendered inside a card. The
            //click that selects such a child runs after this handler, so the order is not a problem.
            clearEmbeddedSelection();

            if (model is null)
                return;

            //A released node keeps the place it was moved to; a card that its container lays out ignores it.
            if (arg.ClientX > 50 || arg.ClientY > 50) {
                if (model is DefaultNode node) {
                    node.UpdateViewState();

                    //A card that was dropped draws the connections of its surface again: the edges a connection
                    //uses follow the cards they join, while the edges the user picked stay where they were put.
                    if (node.ShowsPorts && currentGraphContainer is { } graph)
                        graph.RebuildLinks();

                    updateState();
                }
            }
        }

        /// <summary>Index of a card in the column of the opened ordered container, or -1.</summary>
        public int StackIndexOf(DefaultNode node) => OpenedStack?.IndexOf(node.Element) ?? -1;

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
            Path.Last().Reference.Node.LoadElements(addElement);
            ensureEmbeddedChildren();

            //The variables are collected once the surface is loaded: the root lists the variables of the
            //implementation it holds, which it can only see once the implementation is a card of the surface.
            //Collecting them before the load would leave a workflow that was just opened — or one an undo put
            //back — without the variables of its root scope until the next navigation.
            foreach (var item in Path.SelectMany(p => p.Node.GetVariables()))
                Variables.Add(item);

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
            node.Moving += onNodeMoved;
            ActivityDesignerPair result = new() { Activity = (activity as System.Activities.Activity)!, Element = activity, Node = node };
            items.Add(result);
            return result;
        }

        public virtual void AddVariable<TActivity>(TActivity activity, string name, Type type, string defaultValue) where TActivity : class {
            var genType = typeof(System.Activities.Variable<>).MakeGenericType(type);
            object?[] constructorParams;
            try {
                //A value a nullable type holds is a value of the type inside it, which is the one the typed
                //default value can be made of.
                var valueType = Nullable.GetUnderlyingType(type) ?? type;
                var defType = Convert.ChangeType(defaultValue, valueType);
                constructorParams = new object?[] { name, defType };
            } catch {
                constructorParams = new object?[] { name };
            }
            var variable = Activator.CreateInstance(genType, constructorParams);
            var collection = getVariableCollection(activity);
            if (variable == null || collection == null)
                return;

            collection.Add((System.Activities.Variable)variable);
            //A variable is part of the schema, so the command of the panel marks the workflow as changed and
            //lets the editor record the step, exactly like an edit of a card does.
            notifyModelChanged();
        }

        public virtual void RemoveVariable<TActivity>(TActivity activity, string name) where TActivity : class {
            var collection = getVariableCollection(activity);
            var variable = collection?.FirstOrDefault(p => p.Name == name);
            if (variable != null) {
                collection!.Remove(variable);
                notifyModelChanged();
            }
        }

        public virtual void UpdateVariable<TActivity>(TActivity activity, string oldName, string name, Type type, string defaultValue) where TActivity : class {
            var collection = getVariableCollection(activity);
            var index = indexOf(collection, oldName);
            RemoveVariable(activity, oldName);
            AddVariable(activity, name, type, defaultValue);
            //A variable is replaced rather than changed, and the collection takes the new one at its end: the
            //panel draws the variables in that order, so the place of the edited one is restored.
            if (collection is IList<System.Activities.Variable> list && index >= 0 && index < list.Count - 1) {
                var moved = list[list.Count - 1];
                list.RemoveAt(list.Count - 1);
                list.Insert(index, moved);
            }
        }
    }
}
