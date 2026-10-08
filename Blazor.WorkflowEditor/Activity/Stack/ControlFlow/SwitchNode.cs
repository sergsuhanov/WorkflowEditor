using System.Activities;
using System.Activities.Statements;
using System.Globalization;
using Microsoft.VisualBasic.Activities;

namespace Blazor.WorkflowEditor.Activity.Stack.ControlFlow;

[Pair(typeof(System.Activities.Statements.Switch<>), typeof(SwitchControl<>))]
public class SwitchNode<T> : DefaultNode {
    private readonly System.Activities.Statements.Switch<T> activity;
    private bool defaultSelected = true;
    private string? selectedCaseKey;

    public SwitchNode(Service service, System.Activities.Statements.Switch<T> activity) : base(service, activity) {
        this.activity = activity;
        //Not a container: the card renders the single activity of each case inline.
        IsGeneric = true;
    }

    public string Expression {
        get => ActivityArguments.GetText(activity.Expression);
        set {
            if (string.Equals(Expression, value, StringComparison.Ordinal))
                return;

            activity.Expression = new VisualBasicValue<T> { ExpressionText = value };
            service.NotifyStateChanged();
        }
    }

    public IReadOnlyList<string> CaseKeys =>
        activity.Cases.Keys.Select(formatKey).ToList();

    /// <summary>A case per row reads better on the wider card.</summary>
    public override string NodeLayoutClass => "we-node-wide";

    private IActivityHolder? defaultSlot;
    private readonly Dictionary<string, IActivityHolder> caseSlots = new();

    /// <summary>Slot that holds the Default branch.</summary>
    public IActivityHolder DefaultSlot => defaultSlot ??= new DefaultBranch(this);

    public override IReadOnlyList<IActivityHolder> Slots =>
        new[] { DefaultSlot }.Concat(CaseKeys.Select(CaseSlot)).ToList();

    /// <summary>Slot that holds the body of the case with the given key.</summary>
    public IActivityHolder CaseSlot(string key) {
        if (!caseSlots.TryGetValue(key, out var slot))
            caseSlots[key] = slot = new CaseBranch(this, key);
        return slot;
    }

    /// <summary>One case of the Switch, exposed as a slot so the editor can navigate into it.</summary>
    private sealed class CaseBranch : IActivityHolder {
        private readonly SwitchNode<T> owner;
        private readonly string key;

        public CaseBranch(SwitchNode<T> owner, string key) {
            this.owner = owner;
            this.key = key;
        }

        public DefaultNode Owner => owner;

        public string SlotLabel => $"Case {key}";

        public System.Activities.Activity? Held =>
            tryParseKey(key, out var parsed) && owner.activity.Cases.TryGetValue(parsed, out var child)
                ? child
                : null;

        public void Attach(ActivityDesignerPair child) {
            owner.SelectCase(key);
            owner.AddChild(child);
        }
    }

    /// <summary>The Default branch of the Switch, exposed as a slot.</summary>
    private sealed class DefaultBranch : IActivityHolder {
        private readonly SwitchNode<T> owner;

        public DefaultBranch(SwitchNode<T> owner) => this.owner = owner;

        public DefaultNode Owner => owner;

        public string SlotLabel => "Default";

        public System.Activities.Activity? Held => owner.activity.Default;

        public void Attach(ActivityDesignerPair child) {
            owner.SelectDefault();
            owner.AddChild(child);
        }
    }

    public void SelectDefault() {
        defaultSelected = true;
        selectedCaseKey = null;
    }

    public bool SelectCase(string key) {
        if (!tryParseKey(key, out var parsed) || !activity.Cases.ContainsKey(parsed))
            return false;

        defaultSelected = false;
        selectedCaseKey = formatKey(parsed);
        return true;
    }

    public bool AddCase(string key) {
        if (!tryParseKey(key, out var parsed) || activity.Cases.ContainsKey(parsed))
            return false;

        activity.Cases.Add(parsed, null!);
        SelectCase(formatKey(parsed));
        service.NotifyStateChanged();
        return true;
    }

    public bool RemoveCase(string key) {
        if (!tryParseKey(key, out var parsed) || !activity.Cases.TryGetValue(parsed, out var child))
            return false;

        if (child != null)
            RemoveChildEverywhere(child);

        activity.Cases.Remove(parsed);
        if (!defaultSelected && string.Equals(selectedCaseKey, formatKey(parsed), StringComparison.Ordinal))
            SelectDefault();

        service.NotifyStateChanged();
        return true;
    }

    public override void AddChild(ActivityDesignerPair child) {
        if (defaultSelected) {
            ReplaceChild(activity.Default, child);
            activity.Default = child.Activity;
        } else {
            if (selectedCaseKey == null ||
                !tryParseKey(selectedCaseKey, out var key) ||
                !activity.Cases.TryGetValue(key, out var existing))
                return;

            ReplaceChild(existing, child);
            activity.Cases[key] = child.Activity;
        }

        service.NotifyStateChanged();
    }

    public override void RemoveChild(System.Activities.Activity child) {
        if (activity.Default == child)
            activity.Default = null;

        foreach (var key in activity.Cases.Where(pair => pair.Value == child).Select(pair => pair.Key).ToList())
            activity.Cases[key] = null!;
    }

    private static string formatKey(T key) =>
        Convert.ToString(key, CultureInfo.InvariantCulture) ?? string.Empty;

    private static bool tryParseKey(string text, out T key) {
        try {
            key = (T)Convert.ChangeType(text, typeof(T), CultureInfo.InvariantCulture);
            return true;
        } catch (Exception ex) when (ex is InvalidCastException or FormatException or OverflowException or ArgumentException) {
            key = default!;
            return false;
        }
    }
}
