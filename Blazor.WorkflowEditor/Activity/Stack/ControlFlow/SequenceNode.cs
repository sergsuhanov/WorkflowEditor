using System.Activities.Statements;
using Blazor.Diagrams.Core.Models;

namespace Blazor.WorkflowEditor.Activity.Stack.ControlFlow;

[Pair(typeof(System.Activities.Statements.Sequence), typeof(DefaultControl))]
public class SequenceNode : DefaultNode {
    private readonly Sequence sequenceActivity;

    public SequenceNode(Service service, System.Activities.Statements.Sequence sequenceActivity) : base(service, sequenceActivity) {
        this.sequenceActivity = sequenceActivity;
        this.IsContainer = true;
    }

    public override IEnumerable<Variable> GetVariables() {
        return GetVariables(sequenceActivity.Variables);
    }

    /// <summary>An empty sequence has nothing on its canvas, so it asks for the first activity.</summary>
    public override string? EmptyHint =>
        sequenceActivity.Activities.Count == 0 ? "Drop the first activity here" : null;

    void linkFromTo(ActivityDesignerPair from, ActivityDesignerPair to) {
        _ = service.LinkFromTo(from, to);
    }

    public override void LoadChilds(Func<System.Activities.Activity, ActivityDesignerPair> addActivity) {
        this.service.SelectedOnMove -= onMove;
        this.service.SelectedOnMove += onMove;

        ActivityDesignerPair? last = default;
        foreach (var activity in this.sequenceActivity.Activities) {
            var result = addActivity(activity);

            //lock ports for manual connect 
            result.Node.Ports.ToList().ForEach(p => p.Locked = true);

            if (last != null)
                linkFromTo(last, result);

            last = result;
        }

        placeChildren();
    }

    public override void RelayoutChildren() => placeChildren();

    /// <summary>
    /// Lays the children out in a column, using the height the browser measured for each card so a tall card
    /// does not overlap the next one. A card that came from a saved position, or that the user moved, keeps its
    /// position.
    /// </summary>
    private void placeChildren() {
        var view = this.service.VisibleViewport;
        var horizontal = view.HasValue
            ? view.Value.Left + view.Value.Width / 2
            : (this.service.DiagramContainer?.Width ?? 0) / 2;
        var y = view.HasValue ? view.Value.Top + 60 : 0;
        const double gap = 24;

        foreach (var activity in this.sequenceActivity.Activities) {
            var node = this.service.FindPair(activity)?.Node;
            if (node?.Size is not { } size)
                continue;

            y += size.Height / 2;

            var place = node.LayoutPosition is null
                ? !node.HasViewState
                : node.IsAtLayoutPosition && Math.Abs(node.LayoutHeight - size.Height) > 0.5;

            if (place) {
                node.CenterPosition = new Diagrams.Core.Geometry.Point(horizontal, y);
                node.LayoutPosition = node.Position;
                node.LayoutHeight = size.Height;
                node.UpdateViewState();
            }

            y += size.Height / 2 + gap;
        }
    }

    public override void AddChild(ActivityDesignerPair child) {
        //lock ports for manual connect 
        child.Node.Ports.ToList().ForEach(p => p.Locked = true);

        if (service.SelectedLinks.Count() == 1) {
            var source = service.SelectedLinks.First().source;
            var target = service.SelectedLinks.First().target;

            service.RemoveLinkFromTo(source, target);

            linkFromTo(source, child);
            reconnect(source, child);

            linkFromTo(child, target);
            reconnect(child, target);

            var index = this.sequenceActivity.Activities.IndexOf(target.Activity);
            this.sequenceActivity.Activities.Insert(index, child.Activity);

            service.NotifyStateChanged();
            return;
        }

        if (this.sequenceActivity.Activities.Count() > 0) {
            var last = service.GetPair(this.sequenceActivity.Activities.Last());
            linkFromTo(last, child);
        }

        this.sequenceActivity.Activities.Add(child.Activity);
        service.NotifyStateChanged();
    }

    public override void RemoveChild(System.Activities.Activity child) {
        var index = sequenceActivity.Activities.IndexOf(child);
        if (index > 0 && index < sequenceActivity.Activities.Count - 1) {
            var prevActivity = sequenceActivity.Activities[index - 1];
            var nextActivity = sequenceActivity.Activities[index + 1];
            service.LinkFromTo(service.GetPair(prevActivity), service.GetPair(nextActivity));
        }

        sequenceActivity.Activities.Remove(child);
    }

    private void onMove() {
        if (sequenceActivity.Activities.Count < 2)
            return;

        foreach (var pair in service.SelectedItems) {

            var index = sequenceActivity.Activities.IndexOf(pair.Activity);

            if (index >= 0 && index < sequenceActivity.Activities.Count - 1) {
                var source = pair;
                var dest = service.GetPair(sequenceActivity.Activities[index + 1]);
                reconnect(source, dest);
            }

            if (index >= 1 && index < sequenceActivity.Activities.Count) {
                var source = service.GetPair(sequenceActivity.Activities[index - 1]);
                var dest = pair;
                reconnect(source, dest);
            }

        }
    }

    private static void reconnect(ActivityDesignerPair source, ActivityDesignerPair dest) {
        var avalableSourcePorts = source.Node.Ports.ToList();
        if (source.Node.IncomingPort?.Links.Count > 0)
            avalableSourcePorts.Remove(source.Node.IncomingPort);

        var avalableDestPorts = dest.Node.Ports.ToList();
        if (dest.Node.OutcomingPort?.Links.Count > 0)
            avalableDestPorts.Remove(dest.Node.OutcomingPort);

        List<(PortModel sourcePort, PortModel destPort, double Distance)> items =
                (from fp in avalableSourcePorts
                 from sp in avalableDestPorts
                 select (fp, sp, Math.Abs(fp.Position.DistanceTo(sp.Position)))).ToList();

        (var sourcePort, var destPort, var _) = items.OrderBy(p => p.Distance).First();
        source.Node.SetOutcoming(sourcePort);
        dest.Node.SetIncoming(destPort);
    }
}
