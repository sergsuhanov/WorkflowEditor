using WfState = System.Activities.Statements.State;
using System.Activities.Statements;

namespace Blazor.WorkflowEditor.Activity.Statements;

/// <summary>
/// StateMachine designer. Only WfState elements can be added; links mirror Transition.To.
/// </summary>
[Pair(typeof(System.Activities.Statements.StateMachine), typeof(StateMachineControl))]
public class StateMachineNode : DefaultNode, IGraphContainer {
    private readonly StateMachine activity;

    public StateMachineNode(Service service, StateMachine activity) : base(service, activity) {
        this.activity = activity;
        IsContainer = true;
    }

    public static StateMachineNode? Of(Service service) => service.Path.LastOrDefault()?.Reference?.Node as StateMachineNode;

    public int Count => activity.States.Count;

    public string LabelAt(int index) => activity.States[index].DisplayName;

    public int IndexOf(WfState? state) => state == null ? -1 : activity.States.IndexOf(state);

    public WfState? At(int index) => index >= 0 && index < activity.States.Count ? activity.States[index] : null;

    public WfState? InitialState {
        get => activity.InitialState;
        set => activity.InitialState = value;
    }

    public override IEnumerable<Variable> GetVariables() => GetVariables(activity.Variables);

    public override bool CanAdd(Type elementType) => elementType == typeof(WfState);

    /// <summary>Rebuilds diagram links from the transitions of every state.</summary>
    public void Changed() {
        var pairs = activity.States.Select(s => service.FindPair(s)).OfType<ActivityDesignerPair>().ToList();
        foreach (var pair in pairs)
            service.RemoveAllLinks(pair.Node);

        var done = new HashSet<(ActivityDesignerPair, ActivityDesignerPair)>();
        foreach (var state in activity.States) {
            var from = service.FindPair(state);
            if (from == null)
                continue;
            foreach (var transition in state.Transitions) {
                var to = transition.To == null ? null : service.FindPair(transition.To);
                if (to != null && done.Add((from, to)))
                    service.LinkFromTo(from, to);
            }
        }
    }

    public override void LoadElements(Func<object, ActivityDesignerPair> addElement) {
        var pairs = activity.States.Select(state => addElement(state)).ToList();
        pairs.ForEach(p => p.Node.Ports.ToList().ForEach(port => port.Locked = true));
        Changed();
        ArrangeRow(pairs);
    }

    public override void AddChild(ActivityDesignerPair child) {
        if (child.Element is not WfState state)
            return;
        activity.States.Add(state);
        activity.InitialState ??= state;
    }

    public override void RemoveElement(object child) {
        if (child is not WfState state)
            return;

        foreach (var other in activity.States)
            foreach (var transition in other.Transitions.Where(t => t.To == state).ToList())
                other.Transitions.Remove(transition);

        activity.States.Remove(state);
        if (activity.InitialState == state)
            activity.InitialState = activity.States.FirstOrDefault();
        Changed();
    }
}
