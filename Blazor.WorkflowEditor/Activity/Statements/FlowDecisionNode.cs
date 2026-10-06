using System.Activities.Statements;

namespace Blazor.WorkflowEditor.Activity.Statements;

[Pair(typeof(System.Activities.Statements.FlowDecision), typeof(FlowDecisionControl))]
public class FlowDecisionNode : DefaultNode {
    private readonly FlowDecision decision;

    public FlowDecisionNode(Service service, FlowDecision decision) : base(service, decision) {
        this.decision = decision;
    }

    public IGraphContainer? Container => FlowchartNode.Of(service);

    public string Condition {
        get => ActivityArguments.GetText(decision.Condition);
        set => decision.Condition = ActivityArguments.CreateVisualBasicBooleanExpression(value);
    }

    public int TrueTarget {
        get => FlowchartNode.Of(service)?.IndexOf(decision.True) ?? -1;
        set => setTarget(value, n => decision.True = n);
    }

    public int FalseTarget {
        get => FlowchartNode.Of(service)?.IndexOf(decision.False) ?? -1;
        set => setTarget(value, n => decision.False = n);
    }

    private void setTarget(int index, Action<FlowNode?> assign) {
        var flowchart = FlowchartNode.Of(service);
        if (flowchart == null)
            return;
        assign(flowchart.At(index));
        flowchart.Changed();
    }
}
