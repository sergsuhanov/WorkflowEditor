using WfState = System.Activities.Statements.State;
using WfStateMachine = System.Activities.Statements.StateMachine;
using System.Activities.Statements;

namespace Blazor.WorkflowEditor.Activity.StateMachine;

/// <summary>
/// StateMachine designer. Only WfState elements can be added; links mirror Transition.To.
/// </summary>
[Pair(typeof(System.Activities.Statements.StateMachine), typeof(StateMachineControl))]
public class StateMachineNode : DefaultNode, IGraphContainer {
    private readonly WfStateMachine activity;

    public StateMachineNode(Service service, WfStateMachine activity) : base(service, activity) {
        this.activity = activity;
        IsContainer = true;
    }

    public static StateMachineNode? Of(Service service) => service.Path.LastOrDefault()?.Reference?.Node as StateMachineNode;

    /// <summary>An empty state machine has nothing on its canvas, so it asks for the first state.</summary>
    public override string? EmptyHint =>
        activity.States.Count == 0 ? "Drop the first state here" : null;

    /// <summary>Transition label: the display name of its trigger activity, when there is one.</summary>
    public string? LinkLabel(ActivityDesignerPair from, ActivityDesignerPair to) {
        if (from.Element is not WfState source || to.Element is not WfState target)
            return null;

        var transition = source.Transitions.FirstOrDefault(t => ReferenceEquals(t.To, target));
        if (transition?.Trigger == null)
            return null;

        return string.IsNullOrWhiteSpace(transition.Trigger.DisplayName)
            ? transition.Trigger.GetType().Name
            : transition.Trigger.DisplayName;
    }

    public int Count => activity.States.Count;

    public string LabelAt(int index) => stateName(activity.States[index]);

    private static string stateName(WfState state) =>
        string.IsNullOrWhiteSpace(state.DisplayName) ? "State" : state.DisplayName;

    public int IndexOf(WfState? state) => state == null ? -1 : activity.States.IndexOf(state);

    public WfState? At(int index) => index >= 0 && index < activity.States.Count ? activity.States[index] : null;

    public WfState? InitialState {
        get => activity.InitialState;
        set => activity.InitialState = value;
    }

    /// <summary>Index of the initial state, used by the initial state selector.</summary>
    public int InitialIndex {
        get => IndexOf(activity.InitialState);
        set => SetInitial(value);
    }

    public void SetInitial(int index) {
        activity.InitialState = At(index);
        service.NotifyStateChanged();
    }


    public override IEnumerable<Variable> GetVariables() => GetVariables(activity.Variables);

    public override bool CanAdd(Type elementType) => elementType == typeof(WfState);

    /// <summary>Rebuilds diagram links from the transitions of every state.</summary>
    public void RebuildLinks() {
        var pairs = activity.States.Select(s => service.FindPair(s)).OfType<ActivityDesignerPair>().ToList();
        foreach (var pair in pairs)
            service.RemoveAllLinks(pair.Node);

        var done = new HashSet<(ActivityDesignerPair, ActivityDesignerPair)>();
        foreach (var state in activity.States) {
            var from = service.FindPair(state);
            if (from == null || !service.IsDisplayed(from.Node))
                continue;
            foreach (var transition in state.Transitions) {
                var to = transition.To == null ? null : service.FindPair(transition.To);
                if (to != null && service.IsDisplayed(to.Node) && done.Add((from, to)))
                    service.LinkFromTo(from, to, LinkLabel(from, to));
            }
        }
    }

    public override void LoadElements(Func<object, ActivityDesignerPair> addElement) {
        var pairs = activity.States.Select(state => addElement(state)).ToList();
        //Graph nodes get a directional in/out port pair; both stay unlocked so transitions can be drawn.
        pairs.ForEach(p => {
            p.Node.UseGraphPorts();
            p.Node.Ports.ToList().ForEach(port => port.Locked = false);
        });
        //Lay out the nodes first: link geometry is computed from node positions, so links created while
        //the nodes still overlap would have no geometry at all.
        ArrangeRow(pairs);
        RebuildLinks();
    }

    /// <summary>Adds a transition between two states drawn by the user.</summary>
    public bool TryConnect(ActivityDesignerPair from, ActivityDesignerPair to) {
        if (from.Element is not WfState source || to.Element is not WfState target || ReferenceEquals(source, target))
            return false;

        if (source.Transitions.Any(transition => ReferenceEquals(transition.To, target)))
            return true;

        source.Transitions.Add(new Transition {
            DisplayName = $"Transition {source.Transitions.Count + 1}",
            To = target
        });
        return true;
    }

    public bool TryDisconnect(ActivityDesignerPair from, ActivityDesignerPair to) {
        if (from.Element is not WfState source || to.Element is not WfState target)
            return false;

        var removed = false;
        foreach (var transition in source.Transitions.Where(t => ReferenceEquals(t.To, target)).ToList()) {
            source.Transitions.Remove(transition);
            removed = true;
        }
        return removed;
    }

    /// <summary>
    /// Rebuilds the links and notifies the view.
    /// <para>
    /// Implemented explicitly (and named differently) on purpose: <c>NodeModel.Refresh()</c> of the library is
    /// virtual and is called on every position change, that is on every pointer move while a node is dragged;
    /// overriding it would rebuild the whole graph on each frame.
    /// </para>
    /// </summary>
    void IGraphContainer.Refresh() {
        RebuildLinks();
        service.NotifyStateChanged();
    }

    public override void AddChild(ActivityDesignerPair child) {
        if (child.Element is not WfState state)
            return;
        //Graph nodes get a directional in/out port pair; both stay unlocked so transitions can be drawn.
        //The node is null for an inline (not displayed) add, ports are applied when the container is opened.
        child.Node?.UseGraphPorts();
        child.Node?.Ports.ToList().ForEach(port => port.Locked = false);
        if (string.IsNullOrWhiteSpace(state.DisplayName))
            state.DisplayName = $"State{activity.States.Count + 1}";
        activity.States.Add(state);
        activity.InitialState ??= state;
        service.NotifyStateChanged();
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
        RebuildLinks();
    }
}
