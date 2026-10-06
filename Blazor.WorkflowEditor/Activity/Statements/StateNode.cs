using WfState = System.Activities.Statements.State;
using System.Activities.Statements;

namespace Blazor.WorkflowEditor.Activity.Statements;

[Pair(typeof(System.Activities.Statements.State), typeof(StateControl))]
public class StateNode : DefaultNode {
    private readonly WfState state;

    public StateNode(Service service, WfState state) : base(service, state) {
        this.state = state;
    }

    public IGraphContainer? Container => StateMachineNode.Of(service);

    public bool IsFinal {
        get => state.IsFinal;
        set => state.IsFinal = value;
    }

    public bool IsInitial {
        get => StateMachineNode.Of(service)?.InitialState == state;
        set {
            if (value && StateMachineNode.Of(service) is { } machine)
                machine.InitialState = state;
        }
    }

    public IReadOnlyList<Transition> Transitions => state.Transitions.ToList();

    public Transition AddTransition() {
        var transition = new Transition { DisplayName = $"Transition {state.Transitions.Count + 1}" };
        state.Transitions.Add(transition);
        return transition;
    }

    public void RemoveTransition(Transition transition) {
        state.Transitions.Remove(transition);
        StateMachineNode.Of(service)?.Changed();
    }

    public int GetTarget(Transition transition) => StateMachineNode.Of(service)?.IndexOf(transition.To) ?? -1;

    public void SetTarget(Transition transition, int index) {
        var machine = StateMachineNode.Of(service);
        if (machine == null)
            return;
        transition.To = machine.At(index);
        machine.Changed();
    }

    public string GetCondition(Transition transition) => ActivityArguments.GetText(transition.Condition);

    public void SetCondition(Transition transition, string text) =>
        transition.Condition = string.IsNullOrWhiteSpace(text) ? null : ActivityArguments.CreateVisualBasicBooleanExpression(text);
}
