using System.Activities;
using System.Activities.Statements;
using Microsoft.VisualBasic.Activities;

namespace Blazor.WorkflowEditor.Activity.Statements;

[Pair(typeof(System.Activities.Statements.FlowSwitch<>), typeof(FlowSwitchControl<>))]
public class FlowSwitchNode<T> : DefaultNode {
    private readonly FlowSwitch<T> flowSwitch;

    public FlowSwitchNode(Service service, FlowSwitch<T> flowSwitch) : base(service, flowSwitch) {
        this.flowSwitch = flowSwitch;
        IsGeneric = true;
    }

    public IGraphContainer? Container => FlowchartNode.Of(service);

    public string Expression {
        get => ActivityArguments.GetText(flowSwitch.Expression);
        set => flowSwitch.Expression = new VisualBasicValue<T> { ExpressionText = value };
    }

    public int DefaultTarget {
        get => FlowchartNode.Of(service)?.IndexOf(flowSwitch.Default) ?? -1;
        set {
            var flowchart = FlowchartNode.Of(service);
            if (flowchart == null)
                return;
            flowSwitch.Default = flowchart.At(value);
            flowchart.Changed();
        }
    }

    public IEnumerable<string> CaseKeys =>
        flowSwitch.Cases.Keys.Select(k => Convert.ToString(k, System.Globalization.CultureInfo.InvariantCulture) ?? string.Empty).ToList();

    private static bool tryKey(string text, out T key) {
        try {
            key = (T)Convert.ChangeType(text, typeof(T), System.Globalization.CultureInfo.InvariantCulture);
            return true;
        } catch {
            key = default!;
            return false;
        }
    }

    public int GetCaseTarget(string key) =>
        tryKey(key, out var k) && flowSwitch.Cases.TryGetValue(k, out var node) ? FlowchartNode.Of(service)?.IndexOf(node) ?? -1 : -1;

    /// <summary>Adds or retargets a case. Returns false when the key is invalid for T or no target is selected.</summary>
    public bool SetCase(string key, int targetIndex) {
        var flowchart = FlowchartNode.Of(service);
        var target = flowchart?.At(targetIndex);
        if (flowchart == null || target == null || !tryKey(key, out var k))
            return false;
        flowSwitch.Cases[k] = target;
        flowchart.Changed();
        return true;
    }

    public void RemoveCase(string key) {
        if (tryKey(key, out var k) && flowSwitch.Cases.Remove(k))
            FlowchartNode.Of(service)?.Changed();
    }
}
