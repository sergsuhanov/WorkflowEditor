using System.Activities.Statements;

namespace Blazor.WorkflowEditor.Activity.Statements;

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

    public int Count => activity.Nodes.Count;

    public string LabelAt(int index) => Label(activity.Nodes[index]);

    public int IndexOf(FlowNode? node) => node == null ? -1 : activity.Nodes.IndexOf(node);

    public FlowNode? At(int index) => index >= 0 && index < activity.Nodes.Count ? activity.Nodes[index] : null;

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
    public void Changed() {
        var pairs = activity.Nodes.Select(pairOf).OfType<ActivityDesignerPair>().ToList();
        foreach (var pair in pairs)
            service.RemoveAllLinks(pair.Node);

        var done = new HashSet<(ActivityDesignerPair, ActivityDesignerPair)>();
        foreach (var node in activity.Nodes) {
            var from = pairOf(node);
            if (from == null)
                continue;
            foreach (var target in Successors(node)) {
                var to = pairOf(target);
                if (to != null && done.Add((from, to)))
                    service.LinkFromTo(from, to);
            }
        }
    }

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
            pair.Node.Ports.ToList().ForEach(p => p.Locked = true);
            ordered.Add(pair);
        }

        Changed();
        ArrangeRow(ordered);
    }

    public override void AddChild(ActivityDesignerPair child) {
        if (child.Element is FlowNode flowNode) {
            activity.Nodes.Add(flowNode);
            if (activity.StartNode == null)
                activity.StartNode = flowNode;
            return;
        }

        var step = new FlowStep { Action = child.Activity };
        var last = activity.Nodes.OfType<FlowStep>().LastOrDefault(s => s.Next == null);
        activity.Nodes.Add(step);

        if (activity.StartNode == null)
            activity.StartNode = step;
        else if (last != null)
            last.Next = step;

        Changed();
    }

    public override void RemoveElement(object child) {
        var node = activity.Nodes.FirstOrDefault(n => n is FlowStep s ? s.Action == child : n == child);
        if (node == null)
            return;

        redirect(node, node is FlowStep step ? step.Next : null);
        activity.Nodes.Remove(node);
        Changed();
    }

    public override void RemoveChild(System.Activities.Activity child) => RemoveElement(child);
}
