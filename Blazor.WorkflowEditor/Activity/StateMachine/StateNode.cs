using WfState = System.Activities.Statements.State;
using System.Activities.Statements;

namespace Blazor.WorkflowEditor.Activity.StateMachine;

[Pair(typeof(System.Activities.Statements.State), typeof(StateControl))]
public class StateNode : DefaultNode {
    private readonly WfState state;

    public StateNode(Service service, WfState state) : base(service, state) {
        this.state = state;
    }

    public IGraphContainer? Container => StateMachineNode.Of(service);

    /// <summary>Editable child slot of a state. Trigger and Action belong to a transition.</summary>
    public enum Slot { Entry, Exit, Trigger, Action }

    /// <summary>Slot that receives the next activity dropped on this node.</summary>
    public Slot SelectedSlot { get; private set; } = Slot.Entry;

    /// <summary>Transition the current Trigger/Action slot belongs to.</summary>
    public Transition? SelectedTransition { get; private set; }

    public void SelectSlot(Slot slot, Transition? transition = null) {
        SelectedSlot = slot;
        SelectedTransition = slot is Slot.Trigger or Slot.Action ? transition : null;
    }

    public bool IsFinal {
        get => state.IsFinal;
        set {
            if (state.IsFinal == value)
                return;

            state.IsFinal = value;
            service.NotifyStateChanged();
        }
    }

    public bool IsInitial {
        get => StateMachineNode.Of(service)?.InitialState == state;
        set {
            if (value && StateMachineNode.Of(service) is { } machine)
                machine.InitialState = state;
        }
    }

    public string? EntryName => state.Entry?.DisplayName;
    public bool HasEntry => state.Entry != null;
    public string? ExitName => state.Exit?.DisplayName;
    public bool HasExit => state.Exit != null;

    public void ClearEntry() {
        if (state.Entry == null)
            return;

        RemoveChildEverywhere(state.Entry);
        //The state machine container only clears states, so clear the slot explicitly.
        state.Entry = null;
        service.NotifyStateChanged();
    }

    public void ClearExit() {
        if (state.Exit == null)
            return;

        RemoveChildEverywhere(state.Exit);
        state.Exit = null;
        service.NotifyStateChanged();
    }

    public IReadOnlyList<Transition> Transitions => state.Transitions.ToList();

    public Transition AddTransition() {
        var transition = new Transition { DisplayName = $"Transition {state.Transitions.Count + 1}" };
        state.Transitions.Add(transition);
        service.NotifyStateChanged();
        return transition;
    }

    public void RemoveTransition(Transition transition) {
        state.Transitions.Remove(transition);
        StateMachineNode.Of(service)?.RebuildLinks();
        service.NotifyStateChanged();
    }

    public int GetTarget(Transition transition) => StateMachineNode.Of(service)?.IndexOf(transition.To) ?? -1;

    public void SetTarget(Transition transition, int index) {
        var machine = StateMachineNode.Of(service);
        if (machine == null)
            return;
        transition.To = machine.At(index);
        machine.RebuildLinks();
        service.NotifyStateChanged();
    }

    public string GetCondition(Transition transition) => ActivityArguments.GetText(transition.Condition);

    public void SetCondition(Transition transition, string text) {
        transition.Condition = string.IsNullOrWhiteSpace(text) ? null : ActivityArguments.CreateVisualBasicBooleanExpression(text);
        service.NotifyStateChanged();
    }

    public string? GetTrigger(Transition transition) => transition.Trigger?.DisplayName;
    public bool HasTrigger(Transition transition) => transition.Trigger != null;
    public string? GetAction(Transition transition) => transition.Action?.DisplayName;
    public bool HasAction(Transition transition) => transition.Action != null;

    public void ClearTrigger(Transition transition) {
        if (transition.Trigger == null)
            return;

        RemoveChildEverywhere(transition.Trigger);
        transition.Trigger = null;
        service.NotifyStateChanged();
    }

    public void ClearAction(Transition transition) {
        if (transition.Action == null)
            return;

        RemoveChildEverywhere(transition.Action);
        transition.Action = null;
        service.NotifyStateChanged();
    }

    /// <summary>Dropped activities fill the selected slot (Entry, Exit, or a transition's Trigger/Action).</summary>
    public override void AddChild(ActivityDesignerPair child) {
        switch (SelectedSlot) {
            case Slot.Entry:
                ReplaceChild(state.Entry, child);
                state.Entry = child.Activity;
                break;
            case Slot.Exit:
                ReplaceChild(state.Exit, child);
                state.Exit = child.Activity;
                break;
            case Slot.Trigger when SelectedTransition != null:
                ReplaceChild(SelectedTransition.Trigger, child);
                SelectedTransition.Trigger = child.Activity;
                break;
            case Slot.Action when SelectedTransition != null:
                ReplaceChild(SelectedTransition.Action, child);
                SelectedTransition.Action = child.Activity;
                break;
        }

        service.NotifyStateChanged();
    }

    public override void RemoveChild(System.Activities.Activity child) {
        if (state.Entry == child)
            state.Entry = null;
        if (state.Exit == child)
            state.Exit = null;

        foreach (var transition in state.Transitions) {
            if (transition.Trigger == child)
                transition.Trigger = null;
            if (transition.Action == child)
                transition.Action = null;
        }
    }
}
