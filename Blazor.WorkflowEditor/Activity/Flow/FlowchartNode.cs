using Blazor.Diagrams.Core.Models;
using System.Activities.Statements;

namespace Blazor.WorkflowEditor.Activity.Flow;

/// <summary>
/// Flowchart designer. Activities dropped into an open Flowchart are wrapped in FlowStep nodes;
/// FlowDecision and FlowSwitch are shown as their own nodes. Links on the diagram mirror
/// FlowStep.Next, FlowDecision.True/False and FlowSwitch.Default/Cases.
/// </summary>
[Pair(typeof(System.Activities.Statements.Flowchart), typeof(FlowchartControl))]
public class FlowchartNode : DefaultNode, IGraphContainer {
    private readonly Flowchart activity;

    public FlowchartNode(Service service, Flowchart activity) : base(service, activity) {
        this.activity = activity;
        IsContainer = true;
    }

    /// <summary>The flowchart currently opened in the editor, if any.</summary>
    public static FlowchartNode? Of(Service service) => service.Path.LastOrDefault()?.Reference?.Node as FlowchartNode;

    /// <summary>The element shown as the flowchart's start target on the diagram.</summary>
    public object? StartElement => activity.StartNode switch {
        FlowStep step => step.Action,
        { } node => node,
        _ => null
    };

    /// <summary>Label of the drawn connection: True/False for decisions, the case key for switches.</summary>
    public string? LinkLabel(ActivityDesignerPair from, ActivityDesignerPair to) {
        var fromNode = flowNodeOf(from);
        var toNode = flowNodeOf(to);
        if (fromNode == null || toNode == null)
            return null;

        if (fromNode is FlowDecision decision) {
            if (ReferenceEquals(decision.True, toNode))
                return "True";
            return ReferenceEquals(decision.False, toNode) ? "False" : null;
        }

        return isSwitch(fromNode) ? invokeSwitch(nameof(caseLabel), fromNode, toNode) as string : null;
    }

    private static string? caseLabel<T>(FlowSwitch<T> node, FlowNode? to) {
        if (to == null)
            return null;

        foreach (var pair in node.Cases)
            if (ReferenceEquals(pair.Value, to))
                return Convert.ToString(pair.Key, System.Globalization.CultureInfo.InvariantCulture) ?? "case";

        return ReferenceEquals(node.Default, to) ? "default" : null;
    }

    public int Count => activity.Nodes.Count;

    public string LabelAt(int index) => Label(activity.Nodes[index]);

    public int IndexOf(FlowNode? node) => node == null ? -1 : activity.Nodes.IndexOf(node);

    public FlowNode? At(int index) => index >= 0 && index < activity.Nodes.Count ? activity.Nodes[index] : null;

    /// <summary>
    /// Makes the element shown by a card the start of the flowchart. Returns false when the element is not a
    /// node of this flowchart, or when it already starts it.
    /// </summary>
    public bool SetStartElement(object element) {
        var node = activity.Nodes.FirstOrDefault(n =>
            ReferenceEquals(n is FlowStep step ? step.Action : n, element));
        if (node == null || ReferenceEquals(node, activity.StartNode))
            return false;

        activity.StartNode = node;
        service.NotifyStateChanged();
        return true;
    }

    public static string Label(FlowNode node) => node switch {
        FlowStep step => step.Action?.DisplayName ?? "FlowStep",
        FlowDecision decision => decision.DisplayName,
        _ => node.GetType().Name.Split('`')[0]
    };

    public override IEnumerable<Variable> GetVariables() => GetVariables(activity.Variables);

    public override bool CanAdd(Type elementType) =>
        typeof(FlowNode).IsAssignableFrom(elementType) || typeof(System.Activities.Activity).IsAssignableFrom(elementType);

    public static IEnumerable<FlowNode> Successors(FlowNode node) {
        switch (node) {
            case FlowStep step:
                if (step.Next != null)
                    yield return step.Next;
                break;
            case FlowDecision decision:
                if (decision.True != null)
                    yield return decision.True;
                if (decision.False != null)
                    yield return decision.False;
                break;
            default:
                if (isSwitch(node)) {
                    foreach (var target in (IEnumerable<FlowNode>)invokeSwitch(nameof(switchTargets), node)!)
                        yield return target;
                }
                break;
        }
    }

    private static object? invokeSwitch(string method, FlowNode node, params object?[] args) =>
        typeof(FlowchartNode)
            .GetMethod(method, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static)!
            .MakeGenericMethod(node.GetType().GetGenericArguments()[0])
            .Invoke(null, new object?[] { node }.Concat(args).ToArray());

    private static IEnumerable<FlowNode> switchTargets<T>(FlowSwitch<T> node) {
        var result = new List<FlowNode>();
        if (node.Default != null)
            result.Add(node.Default);
        result.AddRange(node.Cases.Values.OfType<FlowNode>());
        return result;
    }

    private static object? redirectSwitch<T>(FlowSwitch<T> node, FlowNode from, FlowNode? to) {
        if (node.Default == from)
            node.Default = to;
        foreach (var pair in node.Cases.Where(c => c.Value == from).ToList()) {
            if (to == null)
                node.Cases.Remove(pair.Key);
            else
                node.Cases[pair.Key] = to;
        }
        return null;
    }

    private static bool isSwitch(FlowNode node) =>
        node.GetType().IsGenericType && node.GetType().GetGenericTypeDefinition() == typeof(FlowSwitch<>);

    private ActivityDesignerPair? pairOf(FlowNode node) =>
        service.FindPair(node is FlowStep step ? step.Action : node);

    /// <summary>Rebuilds diagram links from the flowchart model.</summary>
    public void RebuildLinks() {
        var pairs = activity.Nodes.Select(pairOf).OfType<ActivityDesignerPair>().ToList();
        foreach (var pair in pairs)
            service.RemoveAllLinks(pair.Node);

        var done = new HashSet<(ActivityDesignerPair, ActivityDesignerPair)>();
        foreach (var node in activity.Nodes) {
            var from = pairOf(node);
            if (from == null || !service.IsDisplayed(from.Node))
                continue;
            foreach (var target in Successors(node)) {
                var to = pairOf(target);
                if (to != null && service.IsDisplayed(to.Node) && done.Add((from, to)))
                    service.LinkFromTo(from, to, LinkLabel(from, to), SourceEdge(from, to));
            }
        }
    }

    /// <summary>
    /// Edge a connection leaves its source card from. A decision keeps its `False` branch and a switch its
    /// `default` branch on the bottom edge, so that is the edge that branch is drawn from: the line then leaves
    /// the card at the point the name next to it belongs to, and the commands of that line re-point that very
    /// branch. Every other connection leaves on the right edge.
    /// </summary>
    public PortAlignment SourceEdge(ActivityDesignerPair from, ActivityDesignerPair to) {
        var fromNode = flowNodeOf(from);
        var toNode = flowNodeOf(to);
        if (fromNode is FlowDecision decision && toNode != null && ReferenceEquals(decision.False, toNode))
            return PortAlignment.Bottom;

        return fromNode != null && isSwitch(fromNode) && invokeSwitch(nameof(isDefaultTarget), fromNode, toNode) is true
            ? PortAlignment.Bottom
            : PortAlignment.Right;
    }

    private static object? isDefaultTarget<T>(FlowSwitch<T> node, FlowNode? to) =>
        to != null && ReferenceEquals(node.Default, to);

    /// <summary>Model element shown by a diagram node (a FlowStep is shown through its action).</summary>
    private FlowNode? flowNodeOf(ActivityDesignerPair? pair) =>
        pair == null ? null : activity.Nodes.FirstOrDefault(n =>
            n is FlowStep step ? ReferenceEquals(step.Action, pair.Element) : ReferenceEquals(n, pair.Element));

    /// <summary>
    /// Connects two nodes drawn by the user. The edge the connection was drawn from names the branch it
    /// replaces: a decision keeps True on the right edge and False on the bottom one, so re-drawing a branch
    /// moves it instead of filling the next free one.
    /// </summary>
    public bool TryConnect(ActivityDesignerPair from, ActivityDesignerPair to, PortAlignment source) {
        var fromNode = flowNodeOf(from);
        var toNode = flowNodeOf(to);
        if (fromNode == null || toNode == null || ReferenceEquals(fromNode, toNode))
            return false;

        switch (fromNode) {
            case FlowStep step:
                if (ReferenceEquals(step.Next, toNode))
                    return true;
                step.Next = toNode;
                return true;
            case FlowDecision decision:
                //The right edge is the True branch, the bottom one the False branch, so a connection drawn a
                //second time takes the place of the branch it names instead of guessing which one is free.
                if (source == PortAlignment.Bottom)
                    decision.False = toNode;
                else
                    decision.True = toNode;
                return true;
            default:
                //A switch takes the drawn connection as a new case, or as its default branch when the
                //connection was drawn from the bottom edge; the key of a new case can be renamed in the node
                //form.
                return isSwitch(fromNode)
                    && invokeSwitch(nameof(connectSwitch), fromNode, toNode, source == PortAlignment.Bottom) is true;
        }
    }

    public bool TryDisconnect(ActivityDesignerPair from, ActivityDesignerPair to) {
        var fromNode = flowNodeOf(from);
        var toNode = flowNodeOf(to);
        if (fromNode == null || toNode == null)
            return false;

        switch (fromNode) {
            case FlowStep step:
                if (!ReferenceEquals(step.Next, toNode))
                    return false;
                step.Next = null;
                return true;
            case FlowDecision decision:
                var changed = false;
                if (ReferenceEquals(decision.True, toNode)) {
                    decision.True = null;
                    changed = true;
                }
                if (ReferenceEquals(decision.False, toNode)) {
                    decision.False = null;
                    changed = true;
                }
                return changed;
            default:
                return isSwitch(fromNode) && invokeSwitch(nameof(disconnectSwitch), fromNode, toNode) is true;
        }
    }

    /// <summary>Connects a drawn connection to a switch, as its default branch or as a new case.</summary>
    private static object connectSwitch<T>(FlowSwitch<T> node, FlowNode? to, bool asDefault) {
        if (to == null)
            return false;

        //The bottom edge of a switch names its default branch, so it is set or moved by drawing like a case.
        if (asDefault) {
            node.Default = to;
            return true;
        }

        //Already connected (as a case or as the default): keep it as is.
        if (node.Cases.Values.Any(c => ReferenceEquals(c, to)) || ReferenceEquals(node.Default, to))
            return true;

        if (!tryNextSwitchKey(node, out var key))
            return false;

        node.Cases[key] = to;
        return true;
    }

    /// <summary>Removes the switch cases (and default) that point at the given node.</summary>
    private static object disconnectSwitch<T>(FlowSwitch<T> node, FlowNode? to) {
        var removed = false;
        foreach (var pair in node.Cases.Where(c => ReferenceEquals(c.Value, to)).ToList()) {
            node.Cases.Remove(pair.Key);
            removed = true;
        }

        if (ReferenceEquals(node.Default, to)) {
            node.Default = null;
            removed = true;
        }

        return removed;
    }

    /// <summary>Finds a free key that can be converted to T (numeric keys for numbers, "1", "2", ... otherwise).</summary>
    private static bool tryNextSwitchKey<T>(FlowSwitch<T> node, out T key) {
        for (var i = node.Cases.Count + 1; i <= node.Cases.Count + 1000; i++) {
            var text = i.ToString(System.Globalization.CultureInfo.InvariantCulture);
            T candidate;
            try {
                candidate = (T)Convert.ChangeType(text, typeof(T), System.Globalization.CultureInfo.InvariantCulture)!;
            } catch {
                break;
            }

            if (!node.Cases.ContainsKey(candidate)) {
                key = candidate;
                return true;
            }
        }

        key = default!;
        return false;
    }

    /// <summary>
    /// Rebuilds the links and notifies the view.
    /// <para>
    /// Implemented explicitly (and named differently) on purpose: <c>NodeModel.Refresh()</c> of the library is
    /// virtual and is called on every position change, that is on every pointer move while a node is dragged;
    /// overriding it would rebuild the whole graph on each frame. Hiding it (the previous shape) was worse:
    /// a method named like the base members was easy to mistake for them.
    /// </para>
    /// </summary>
    void IGraphContainer.Refresh() {
        RebuildLinks();
        service.NotifyStateChanged();
    }

    /// <summary>
    /// Releases a node that is removed: every connection that pointed at it is moved to the node that took its
    /// place — the next one for a step, the first branch for a decision or a switch — so the ones that ran
    /// after it keep running, and the flowchart keeps a start node when the start node itself is removed.
    /// </summary>
    private void redirect(FlowNode from, FlowNode? to) {
        if (activity.StartNode == from)
            activity.StartNode = to;

        foreach (var node in activity.Nodes) {
            switch (node) {
                case FlowStep step:
                    if (step.Next == from) step.Next = to;
                    break;
                case FlowDecision decision:
                    if (decision.True == from) decision.True = to;
                    if (decision.False == from) decision.False = to;
                    break;
                default:
                    if (isSwitch(node))
                        invokeSwitch(nameof(redirectSwitch), node, from, to);
                    break;
            }
        }
    }

    public override void LoadElements(Func<object, ActivityDesignerPair> addElement) {
        var ordered = new List<ActivityDesignerPair>();
        foreach (var node in activity.Nodes) {
            object? element = node is FlowStep step ? step.Action : node;
            if (element == null)
                continue;
            var pair = addElement(element);
            //Graph nodes get a directional in/out port pair; both stay unlocked so links can be drawn.
            pair.Node.UseGraphPorts();
            pair.Node.Ports.ToList().ForEach(p => p.Locked = false);
            ordered.Add(pair);
        }

        //Lay out the nodes first: link geometry is computed from node positions, so links created while
        //the nodes still overlap would have no geometry at all.
        ArrangeRow(ordered);
        RebuildLinks();
    }

    public override void AddChild(ActivityDesignerPair child) {
        //The node is null for an inline (not displayed) add, ports are applied when the container is opened.
        child.Node?.UseGraphPorts();
        child.Node?.Ports.ToList().ForEach(p => p.Locked = false);

        //A dropped element becomes a node of the flowchart and nothing more: the step that runs after another
        //one and the node that starts the flowchart are both chosen by the user, by drawing the connection and
        //by dragging the START badge, so a drop never decides either of them.
        if (child.Element is FlowNode flowNode)
            activity.Nodes.Add(flowNode);
        else
            activity.Nodes.Add(new FlowStep { Action = child.Activity });

        RebuildLinks();
        service.NotifyStateChanged();
    }

    public override void RemoveElement(object child) {
        var node = activity.Nodes.FirstOrDefault(n => n is FlowStep s ? s.Action == child : n == child);
        if (node == null)
            return;

        //A step hands its place to the node that ran after it; a decision or a switch hides its branches behind
        //itself, so the first one of them takes that place instead and the flowchart keeps its start node.
        redirect(node, Successors(node).FirstOrDefault());
        activity.Nodes.Remove(node);
        RebuildLinks();
    }

    public override void RemoveChild(System.Activities.Activity child) => RemoveElement(child);
}
