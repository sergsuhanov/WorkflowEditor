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
    /// The connections of a graph surface: the links the model and the diagram keep in step, the
    /// gestures that draw one and that move the end of one, and the search for the points a connection runs
    /// between.
    /// </summary>
    public partial class Service {
        /// <summary>True while links are added/removed from the model, to avoid reacting to our own changes.</summary>
        private bool suppressLinkSync;

        /// <summary>
        /// Points of the cards the user picked while drawing a connection. A graph link is rebuilt from the
        /// workflow model on every change, so the choice of anchor has to be remembered here, otherwise the
        /// rebuilt link would jump back to the points the model alone would pick.
        /// </summary>
        private readonly Dictionary<(ActivityDesignerPair from, ActivityDesignerPair to), (PortPlace source, PortPlace target)> linkPlaces = new();

        /// <summary>Whether the connections of the surface follow the cards instead of the points they were given.</summary>
        private bool dynamicLinks = true;

        /// <summary>
        /// Whether the connections of a graph surface follow the cards: the two ends of a connection are picked as
        /// a pair, by the cheapest route the two cards allow, and they are picked again whenever a card moves, so
        /// an arranged diagram keeps short lines with as few bends as the surface allows — a connection that can
        /// leave a card downwards and arrive on the side of the other one is not wrapped around both cards
        /// because the two cards happen to lie in a row. Turned off, a connection keeps the point it was given —
        /// the point of the branch the model asks for, or the point the user dragged its end onto, which is also
        /// what a saved schema keeps.
        /// <para>Switching the mode on or off draws the connections of the open surface again from the model,
        /// which is a change of the picture only: the schema is left as it is.</para>
        /// </summary>
        public bool DynamicLinks {
            get => dynamicLinks;
            set {
                if (dynamicLinks == value)
                    return;

                dynamicLinks = value;
                currentGraphContainer?.RebuildLinks();
                updateState();
            }
        }

        /// <summary>Distance the name of a branch keeps from the line it belongs to.</summary>
        private const double LinkLabelOffset = 24;

        /// <summary>
        /// How much cheaper another pair of connection points has to be before the ends of a connection are moved
        /// onto it: one bend, so the ends do not trade places between routes that cost nearly the same.
        /// </summary>
        private const double EndChoiceMargin = WorkflowRouter.BendPenalty;

        /// <summary>
        /// Connection point locked for the gesture that took the connection ending there, or null. The lock keeps
        /// the library from drawing a new link from that point while the user moves the connection instead.
        /// </summary>
        private PortModel? pressedPort;

        /// <summary>How far from an end of a connection the pointer has to be pressed to take that end.</summary>
        private const double LinkEndGrabRadius = 26;

        /// <summary>Distance within which a moving end of a connection takes a connection point of a card.</summary>
        private const double LinkEndSnapRadius = 60;

        /// <summary>How far the pointer moves before a press on a connection counts as a drag of its end.</summary>
        private const double LinkEndDragThreshold = 4;

        /// <summary>Set when the ports have to be measured again after the next render.</summary>
        private bool portGeometryDirty;

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

        internal void RemoveAllLinks(DefaultNode node) {
            foreach (var link in designer.Links.OfType<LinkModel>().Where(l => nodeOf(l.Source) == node || nodeOf(l.Target) == node).ToList())
                removeLink(link);
        }

        internal LinkModel LinkFromTo(ActivityDesignerPair from, ActivityDesignerPair to, string? label = null,
            PortAlignment? sourceEdge = null, PortAlignment? targetEdge = null) {
            //Port anchors: the ports are placed on the node border and the library rebuilds the link geometry
            //afterwards, so the line follows the node. They are also what the router of the editor needs in order
            //to build right-angled (Workflow Foundation style) routes.
            var (sourcePort, targetPort) = linkPorts(from, to, sourceEdge, targetEdge);

            var linkModel = new LinkModel(
                new SinglePortAnchor(sourcePort),
                new SinglePortAnchor(targetPort)) {
                TargetMarker = LinkMarker.Arrow
            };

            if (!string.IsNullOrWhiteSpace(label))
                //The name of the branch sits above the line instead of on it, because the commands of the link
                //are drawn on the line, at the middle of its route.
                linkModel.AddLabel(label, offset: new Point(0, -LinkLabelOffset));

            addLink(linkModel);

            //A picked link offers its one command, exactly like a picked card: removing it. Removing the link
            //raises Links.Removed, which translates it into TryDisconnect of the open container; the connection
            //itself is moved by taking one of its ends on the line, which needs no command of its own.
            designer.Controls.AddFor(linkModel, ControlsType.OnSelection)
                .Add(new RemoveLinkControl(new LinkCommandPositionProvider(0)));

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

        /// <summary>
        /// A press on a connection takes the end of it the pointer is nearest to, so that end can be dragged onto
        /// another connection point; a press that does not move only picks the link, which the library does on
        /// its own. A press on a connection point that already receives a connection takes the end that arrives
        /// there, and a press anywhere else on a point starts a new connection, which the library draws.
        /// </summary>
        private void pointerDown(Model? model, Diagrams.Core.Events.PointerEventArgs e) {
            //A press starts a gesture of its own: an end left following the pointer by a release the canvas never
            //saw goes back to the connection the model keeps, and a point locked for the previous gesture is free
            //again before this press takes one.
            releasePressedPort();
            if (movingLinkEnd != null)
                CancelLinkEndDrag();

            if (model is PortModel port) {
                StartLinkEndDragFromPort(port, e.ClientX, e.ClientY);
                return;
            }

            if (model is LinkModel link)
                StartLinkEndDrag(link, e.ClientX, e.ClientY);
        }

        /// <summary>
        /// Takes the end of the connection that belongs to a connection point, so a drag started on that point
        /// detaches the connection from the card instead of drawing one more: the point is what the user grabs to
        /// put the connection somewhere else. Returns false when no connection belongs there or when the point
        /// adds connections instead of replacing one, which leaves the press to the library, that draws a new one.
        /// </summary>
        public bool StartLinkEndDragFromPort(PortModel port, double clientX, double clientY) {
            pendingLinkEnd = null;
            if (attachedLinkOf(port) is not { } attached)
                return false;

            if (!beginLinkEndDrag(attached.Link, attached.SourceEnd, clientX, clientY))
                return false;

            //The library would start a new link from the pressed point; it is locked for this gesture, which is
            //what makes the press take the connection that belongs there instead.
            port.Locked = true;
            pressedPort = port;
            return true;
        }

        /// <summary>Frees the connection point a gesture locked, if any.</summary>
        private void releasePressedPort() {
            if (pressedPort == null)
                return;

            pressedPort.Locked = false;
            pressedPort = null;
        }

        /// <summary>
        /// Takes the end of a connection the pointer was pressed on: a press on the line near one of its ends
        /// starts with that end, which is what lets the user move a connection by its beginning or by its end
        /// instead of drawing it again. Returns false when the link does not belong to the container that is open
        /// or the press is not near an end of it.
        /// </summary>
        public bool StartLinkEndDrag(LinkModel link, double clientX, double clientY) {
            pendingLinkEnd = null;
            //The end of the link follows the pointer in canvas coordinates, so the canvas has to be measured
            //before it can be taken.
            if (designer.Container is null)
                return false;

            return linkEndAt(link, designer.GetRelativeMousePoint(clientX, clientY)) is { } sourceEnd
                && beginLinkEndDrag(link, sourceEnd, clientX, clientY);
        }

        /// <summary>
        /// Takes one end of a connection, so that end follows the pointer once the press turns into a drag.
        /// Returns false when the link does not belong to the container that is open.
        /// </summary>
        private bool beginLinkEndDrag(LinkModel link, bool sourceEnd, double clientX, double clientY) {
            pendingLinkEnd = null;
            var from = findPair(nodeOf(link.Source));
            var to = findPair(nodeOf(link.Target));
            if (from == null || to == null || currentGraphContainer == null || designer.Container is null)
                return false;

            pendingLinkEnd = (link, from, to, sourceEnd,
                PortPlaceOf(link.Source, PortPlace.Of(from.Node.OutcomingPort)).Edge, clientX, clientY);
            return true;
        }

        /// <summary>
        /// Lets the end of the pressed connection follow the pointer, once the press has turned into a drag.
        /// Returns false while nothing is pending or the pointer has not moved far enough, so a click on the line
        /// picks it instead of moving it.
        /// </summary>
        public bool DragLinkEnd(double clientX, double clientY) {
            if (pendingLinkEnd is not { } pending)
                return false;

            if (Math.Abs(clientX - pending.ClientX) < LinkEndDragThreshold
                && Math.Abs(clientY - pending.ClientY) < LinkEndDragThreshold)
                return false;

            pendingLinkEnd = null;
            var floating = new PositionAnchor(designer.GetRelativeMousePoint(clientX, clientY));
            moveLinkEnd(pending.Link, pending.SourceEnd, floating);
            movingLinkEnd = (pending.Link, pending.From, pending.To, pending.SourceEnd, pending.SourceEdge, floating);
            return true;
        }

        /// <summary>
        /// Puts an end of a connection that is following the pointer back on the connection the model keeps,
        /// which is where it was before the drag: a release the canvas never saw (the pointer left it while the
        /// end was moving) leaves the end with nothing holding it, and the line is drawn from the model again.
        /// </summary>
        public void CancelLinkEndDrag() {
            if (movingLinkEnd == null && pendingLinkEnd == null)
                return;

            movingLinkEnd = null;
            pendingLinkEnd = null;
            releasePressedPort();
            currentGraphContainer?.RebuildLinks();
            updateState();
        }

        /// <summary>
        /// Leaves the end of the moving connection on the connection point the pointer was released on: the connection keeps the
        /// end that did not move and takes that point, and the line is drawn from the model afterwards, so it
        /// arrives and leaves on the points the user put it between. A drop away from every point, or on a point
        /// the container refuses (a card into itself), leaves the connection as it was — moving a connection is
        /// not the way to remove it.
        /// </summary>
        public void DropLinkEnd(double clientX, double clientY) {
            if (movingLinkEnd is not { } moving)
                return;

            movingLinkEnd = null;
            //The gesture that took the end of the connection is over, so the point it was taken from is free
            //again for the next press.
            releasePressedPort();
            if (currentGraphContainer is not { } container || designer.Container is null)
                return;

            //The point the pointer was released on is what counts, and not the place the end was last put: a move
            //that never reached the handler would otherwise leave the end somewhere the user did not point at.
            var at = designer.GetRelativeMousePoint(clientX, clientY);
            var port = findPortNear(at);
            var pair = port == null ? null : findPair(port.Parent);

            //The end that did not move stays where it is; the other one takes the point it was dropped on, and
            //the point it leaves from on its own card names the branch when it is the start of the connection.
            var source = moving.SourceEnd ? pair : moving.From;
            var end = moving.SourceEnd ? moving.To : pair;
            var edge = moving.SourceEnd ? port?.Alignment ?? moving.SourceEdge : moving.SourceEdge;
            if (source == null || end == null) {
                container.RebuildLinks();
                updateState();
                return;
            }

            var moved = !ReferenceEquals(source, moving.From) || !ReferenceEquals(end, moving.To);
            container.TryDisconnect(moving.From, moving.To);
            if (!container.TryConnect(source, end, edge)) {
                container.TryConnect(moving.From, moving.To, moving.SourceEdge);
                container.Refresh();
                updateState();
                return;
            }

            //The end that moved keeps the point it was dropped on, so drawing the line again does not send it
            //back to the point the model of the activity would pick.
            var dropped = PortPlace.Of(port!);
            var kept = moving.SourceEnd
                ? PortPlaceOf(moving.Link.Target, PortPlace.Of(moving.To.Node.IncomingPort))
                : PortPlaceOf(moving.Link.Source, PortPlace.Of(moving.From.Node.OutcomingPort));
            linkPlaces.Remove((moving.From, moving.To));
            //A connection that follows the cards is not given a point: it takes the points the cards ask for, so
            //the choice is not kept (and the schema is not rewritten with a choice nobody made).
            if (!DynamicLinks) {
                linkPlaces[(source, end)] = moving.SourceEnd ? (dropped, kept) : (kept, dropped);
                savePlaces(source, end);
            }

            if (moved) {
                container.Refresh();
                notifyModelChanged();
            } else {
                //The same connection, arriving where the user put the end: nothing changed to report.
                container.RebuildLinks();
                updateState();
            }
        }

        /// <summary>
        /// Puts one end of a link on the given anchor, redrawing the line: the library only redraws a link whose
        /// own port changed, and an end that follows the pointer belongs to no port.
        /// </summary>
        private static void moveLinkEnd(LinkModel link, bool sourceEnd, Anchor anchor) {
            if (sourceEnd)
                link.SetSource(anchor);
            else
                link.SetTarget(anchor);

            link.Refresh();
            link.RefreshLinks();
        }

        /// <summary>
        /// Which end of a link a point of the canvas takes: the source end, the target end, or null when the
        /// point is not near either of them. The line runs from one end of its route to the other, so the nearer
        /// end is the one the user reached for.
        /// </summary>
        private static bool? linkEndAt(LinkModel link, Point point) {
            var path = link.PathGeneratorResult?.FullPath;
            if (path == null || path.Length <= 0)
                return null;

            var source = path.GetPointAtLength(0);
            var target = path.GetPointAtLength(path.Length);
            var toSource = distance(point, source.X, source.Y);
            var toTarget = distance(point, target.X, target.Y);
            if (Math.Min(toSource, toTarget) > LinkEndGrabRadius)
                return null;

            return toSource <= toTarget;
        }

        /// <summary>Connection point nearest to a point of the canvas, within the radius a moving end snaps in.</summary>
        private PortModel? findPortNear(Point point) {
            PortModel? nearest = null;
            var nearestDistance = LinkEndSnapRadius;
            foreach (var port in designer.Nodes.SelectMany(node => node.Ports)) {
                if (port.Locked)
                    continue;

                var middle = port.MiddlePosition;
                var away = distance(point, middle.X, middle.Y);
                if (away <= nearestDistance) {
                    nearest = port;
                    nearestDistance = away;
                }
            }

            return nearest;
        }

        private static double distance(Point one, double x, double y) =>
            Math.Sqrt(Math.Pow(one.X - x, 2) + Math.Pow(one.Y - y, 2));

        /// <summary>
        /// Follows the pointer with the moving end: the end takes the connection point it points at, and lets go
        /// of it when the pointer moves away from every point.
        /// </summary>
        private void pointerMove(Model? model, Diagrams.Core.Events.PointerEventArgs e) {
            //An end that follows the pointer belongs to a press: a pointer that moves with no button down has lost
            //its release, so the end goes back where the model has it instead of following the pointer on its own.
            if (movingLinkEnd != null && e.Buttons == 0) {
                CancelLinkEndDrag();
                return;
            }

            if (DragLinkEnd(e.ClientX, e.ClientY) || movingLinkEnd is not { } moving)
                return;

            var point = designer.GetRelativeMousePoint(e.ClientX, e.ClientY);
            moving.Floating.SetPosition(point);
            var port = findPortNear(point);
            moveLinkEnd(moving.Link, moving.SourceEnd,
                port == null ? moving.Floating : new SinglePortAnchor(port));
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
            if (from == null || to == null) {
                //Not a valid connection for the current container: drop the drawn link.
                removeLink(link);
                updateState();
                return;
            }

            //The edge the link was drawn from names the branch the connection replaces (True/False of a
            //decision, the default branch of a switch), so a branch is moved by drawing it again instead of
            //one more branch being added next to it.
            var sourcePort = PortPlaceOf(link.Source, PortPlace.Of(from.Node.OutcomingPort));
            if (currentGraphContainer is { } graph && graph.TryConnect(from, to, sourcePort.Edge)) {
                //Keep the points the user dropped the ends on: the link is rebuilt from the model afterwards.
                if (!DynamicLinks) {
                    linkPlaces[(from, to)] = (sourcePort, PortPlaceOf(link.Target, PortPlace.Of(to.Node.IncomingPort)));
                    savePlaces(from, to);
                }
                graph.Refresh();
                notifyModelChanged();
                return;
            }

            //Not a valid connection for the current container: drop the drawn link, and put back the connection
            //the drag took the end of.
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
                linkPlaces.Remove((from, to));
                graph.Refresh();
                notifyModelChanged();
            }
        }

        /// <summary>Place of the point a link end is anchored on, or the fallback one.</summary>
        private static PortPlace PortPlaceOf(Anchor? anchor, PortPlace fallback) =>
            anchor is SinglePortAnchor { Port: { } port } ? PortPlace.Of(port) : fallback;

        /// <summary>What a route between two connection points costs, or null when none can be laid out.</summary>
        private double? endsCost(PortModel source, PortModel target) =>
            WorkflowRouter.MeasureRoute(designer, source, target)?.Cost;

        /// <summary>
        /// Gives the connections of the open surface the points the cards now ask for: a card that is moved takes
        /// the ends of its connections with it, so the lines keep leaving and arriving on the edges that face the
        /// cards they join, with as few bends as the two cards allow. A connection that already holds the point it
        /// calls for is left untouched.
        /// <para>
        /// <paramref name="movedCard"/> is the card the surface moved, when the pass follows a card. Only the
        /// connections whose band a route between their cards is searched in can meet it: every cost of the rest
        /// is what it was when their ends were picked, so they are left alone instead of being measured again —
        /// a surface of many cards would otherwise pay for every connection on each frame of the drag.
        /// </para>
        /// </summary>
        internal void FollowCards(DefaultNode? movedCard = null) {
            if (!DynamicLinks || currentGraphContainer is not { } graph || designer.Container == null)
                return;

            //A gesture that holds an end of a connection decides where that end is, so nothing moves it meanwhile.
            if (movingLinkEnd != null || pendingLinkEnd != null || pressedPort != null)
                return;

            var movedBounds = movedCard?.GetBounds();

            foreach (var link in designer.Links.OfType<LinkModel>().ToList()) {
                if (nodeOf(link.Source) is not DefaultNode source || nodeOf(link.Target) is not DefaultNode target)
                    continue;

                if (movedBounds is { } bounds && !WorkflowRouter.MeetsCorridor(source, target, bounds))
                    continue;

                if (findPair(source) is not { } from || findPair(target) is not { } to)
                    continue;

                //The edge a connection leaves from is the one the model of the activity asks for — the side that
                //names a branch of a decision — so the branch stays where its name is drawn.
                var kept = link.SourcePort() is { } keptSource && link.TargetPort() is { } keptTarget
                    ? (Source: keptSource, Target: keptTarget)
                    : ((PortModel Source, PortModel Target)?)null;
                var ends = bestEnds(source, target, graph.SourceEdge(from, to),
                    target.IncomingPort.Alignment, link, kept);

                if (!ReferenceEquals(ends.Source, link.SourcePort()))
                    link.SetSource(new SinglePortAnchor(ends.Source));

                if (!ReferenceEquals(ends.Target, link.TargetPort()))
                    link.SetTarget(new SinglePortAnchor(ends.Target));
            }
        }

        /// <summary>A card was moved: the connections that follow the cards take the points the cards now ask for.</summary>
        private void onNodeMoved(NodeModel model) {
            if (model is DefaultNode card)
                FollowCards(card);
        }

        /// <summary>
        /// Port to anchor a link end on: the point of the card the connection was put on, when the card still
        /// offers it. A card whose edges changed since the schema was saved takes the point of that edge that
        /// lies nearest to it instead.
        /// </summary>
        private PortModel PortOf(DefaultNode node, PortPlace place, PortModel fallback, bool source) =>
            node.PortAt(place) ?? PortOnEdge(node, place.Edge, fallback, source);

        /// <summary>
        /// Port of an edge a link end takes when the model of the activity asks for that edge: the ends that
        /// share one take its points in order, so two connections leaving through the same side do not cover
        /// each other. A card that offers no such edge keeps the canonical port of that end of a link (the right
        /// edge for its start, the left one for its end).
        /// </summary>
        private PortModel PortOnEdge(DefaultNode node, PortAlignment edge, PortModel fallback, bool source) =>
            node.Ports.Any(p => p.Alignment == edge)
                ? node.PortOn(edge, endsOn(node, edge, source))
                : fallback;

        /// <summary>Connections already anchored on an end of the card, which is how the points of an edge are shared out.</summary>
        private int endsOn(DefaultNode node, PortAlignment edge, bool source) =>
            designer.Links.OfType<LinkModel>().Count(link => portOf(link, source) is { } port
                && ReferenceEquals(port.Parent, node) && port.Alignment == edge);

        private static PortModel? portOf(LinkModel link, bool source) => source ? link.SourcePort() : link.TargetPort();

        /// <summary>Keeps the points of a connection the user moved with the element the connection leaves from.</summary>
        private void savePlaces(ActivityDesignerPair from, ActivityDesignerPair to) {
            if (currentGraphContainer is not { } graph || graph.BranchKey(from, to) is not { } key)
                return;

            if (linkPlaces.TryGetValue((from, to), out var places))
                Blazor.WorkflowEditor.Activity.State.BranchPorts.Set(from.Element, key, places.source, places.target);
        }

    }
}
