using System.Activities.Statements;

namespace Blazor.WorkflowEditor.Activity.Statements;

/// <summary>
/// Flowchart designer. Activities dropped into an open Flowchart are wrapped in FlowStep nodes
/// chained through FlowStep.Next. FlowDecision / FlowSwitch nodes are not editable yet.
/// </summary>
[Pair(typeof(System.Activities.Statements.Flowchart), typeof(FlowchartControl))]
public class FlowchartNode : DefaultNode {
    private readonly Flowchart activity;
    private readonly Dictionary<System.Activities.Activity, FlowStep> steps = new();

    public FlowchartNode(Service service, Flowchart activity) : base(service, activity) {
        this.activity = activity;
        IsContainer = true;
    }

    public override IEnumerable<Variable> GetVariables() => GetVariables(activity.Variables);

    public override void LoadChilds(Func<System.Activities.Activity, ActivityDesignerPair> addActivity) {
        steps.Clear();
        var pairs = new Dictionary<FlowStep, ActivityDesignerPair>();
        var ordered = new List<ActivityDesignerPair>();

        foreach (var step in activity.Nodes.OfType<FlowStep>()) {
            if (step.Action == null)
                continue;
            var pair = addActivity(step.Action);
            pair.Node.Ports.ToList().ForEach(p => p.Locked = true);
            steps[step.Action] = step;
            pairs[step] = pair;
            ordered.Add(pair);
        }

        foreach (var (step, pair) in pairs) {
            if (step.Next is FlowStep next && pairs.TryGetValue(next, out var target))
                service.LinkFromTo(pair, target);
        }

        ArrangeRow(ordered);
    }

    public override void AddChild(ActivityDesignerPair child) {
        var step = new FlowStep { Action = child.Activity };
        var last = activity.Nodes.OfType<FlowStep>().LastOrDefault(s => s.Next == null);
        activity.Nodes.Add(step);
        steps[child.Activity] = step;

        if (activity.StartNode == null)
            activity.StartNode = step;
        else if (last != null) {
            last.Next = step;
            if (last.Action != null && service.Items.FirstOrDefault(p => p.Activity == last.Action) is { } from)
                service.LinkFromTo(from, child);
        }
    }

    public override void RemoveChild(System.Activities.Activity child) {
        var step = activity.Nodes.OfType<FlowStep>().FirstOrDefault(s => s.Action == child);
        if (step == null)
            return;

        foreach (var other in activity.Nodes.OfType<FlowStep>().Where(s => s.Next == step))
            other.Next = step.Next;
        if (activity.StartNode == step)
            activity.StartNode = step.Next;

        activity.Nodes.Remove(step);
        steps.Remove(child);
    }
}
