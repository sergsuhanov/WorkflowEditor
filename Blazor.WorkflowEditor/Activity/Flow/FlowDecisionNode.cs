using System.Activities.Statements;
using Blazor.Diagrams.Core.Models;

namespace Blazor.WorkflowEditor.Activity.Flow;

[Pair(typeof(System.Activities.Statements.FlowDecision), typeof(FlowDecisionControl))]
public class FlowDecisionNode : DefaultNode {
    private readonly FlowDecision decision;

    public FlowDecisionNode(Service service, FlowDecision decision) : base(service, decision) {
        this.decision = decision;
    }

    /// <summary>
    /// A decision has one entry and two branches: the entry is its top edge, the True branch leaves from the
    /// left one and the False branch from the right one, so the bottom edge carries nothing.
    /// </summary>
    protected override IReadOnlyList<PortAlignment> GraphPortEdges => new[] {
        PortAlignment.Top, PortAlignment.Left, PortAlignment.Right
    };

    /// <summary>
    /// The entry of a decision is its top edge and its branches leave from the sides, so its edges are pinned:
    /// the name of a branch belongs to the edge it leaves from, and a card drawn around a decision may not move
    /// them. Only the entry edge offers more than one point, because a decision can be entered more than once.
    /// </summary>
    protected override bool EdgesAreFixed => true;

    protected override PortAlignment GraphIncomingEdge => PortAlignment.Top;

    protected override PortAlignment GraphOutcomingEdge => PortAlignment.Right;

    /// <summary>The left edge draws the True branch, the right one the False branch.</summary>
    protected override string? BranchName(PortAlignment edge) => edge switch {
        PortAlignment.Left => "True",
        PortAlignment.Right => "False",
        _ => null
    };

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
        flowchart.RebuildLinks();
    }
}
