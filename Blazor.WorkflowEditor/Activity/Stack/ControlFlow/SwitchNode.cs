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
        IsContainer = true;
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

    public string? DefaultName => activity.Default?.DisplayName;

    public bool HasDefault => activity.Default != null;

    public bool IsDefaultSelected => defaultSelected;

    public bool IsCaseSelected(string key) =>
        !defaultSelected && string.Equals(selectedCaseKey, key, StringComparison.Ordinal);

    public string? CaseName(string key) =>
        tryParseKey(key, out var parsed) && activity.Cases.TryGetValue(parsed, out var child)
            ? child?.DisplayName
            : null;

    public bool HasCaseBody(string key) =>
        tryParseKey(key, out var parsed) && activity.Cases.TryGetValue(parsed, out var child) && child != null;

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

    public void ClearDefault() {
        if (activity.Default == null)
            return;

        RemoveChildEverywhere(activity.Default);
        service.NotifyStateChanged();
    }

    public void ClearCase(string key) {
        if (!tryParseKey(key, out var parsed) ||
            !activity.Cases.TryGetValue(parsed, out var child) ||
            child == null)
            return;

        RemoveChildEverywhere(child);
        service.NotifyStateChanged();
    }

    public override void LoadChilds(Func<System.Activities.Activity, ActivityDesignerPair> addActivity) {
        var children = new List<ActivityDesignerPair>();
        if (activity.Default != null)
            children.Add(addActivity(activity.Default));

        foreach (var child in activity.Cases.Values.OfType<System.Activities.Activity>())
            children.Add(addActivity(child));

        ArrangeRow(children);
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
