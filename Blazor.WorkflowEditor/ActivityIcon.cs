using System.Activities.Statements;

namespace Blazor.WorkflowEditor;

/// <summary>
/// Maps system Activity types to Open Iconic icon names so that toolbox items and diagram nodes
/// show a recognizable icon. Unknown (for example custom) activities simply have no icon.
/// </summary>
public static class ActivityIcon {
    private static readonly Dictionary<Type, string> icons = new();

    static ActivityIcon() {
        // Stack: control flow
        Add(typeof(Sequence), "list-rich");
        Add(typeof(If), "fork");
        Add(typeof(While), "loop");
        Add(typeof(DoWhile), "loop-square");
        Add(typeof(System.Activities.Statements.Parallel), "layers");
        Add(typeof(TryCatch), "shield");
        Add(typeof(Switch<>), "fork");

        // Stack: primitives
        Add(typeof(Assign), "action-redo");
        Add(typeof(WriteLine), "terminal");
        Add(typeof(Delay), "clock");
        Add(typeof(Throw), "bolt");
        Add(typeof(Rethrow), "warning");
        Add(typeof(TerminateWorkflow), "power-standby");

        // Stack: collections and iteration
        Add(typeof(Assign<>), "action-redo");
        Add(typeof(ForEach<>), "loop-circular");
        Add(typeof(AddToCollection<>), "inbox");
        Add(typeof(RemoveFromCollection<>), "minus");
        Add(typeof(ExistsInCollection<>), "magnifying-glass");
        Add(typeof(ClearCollection<>), "trash");

        // Flow
        Add(typeof(Flowchart), "share");
        Add(typeof(FlowDecision), "random");
        Add(typeof(FlowSwitch<>), "share-boxed");

        // State machine
        Add(typeof(StateMachine), "transfer");
        Add(typeof(State), "target");

        // Editor root
        Add(typeof(System.Activities.DynamicActivity), "puzzle-piece");
    }

    private static void Add(Type type, string icon) => icons[type] = icon;

    /// <summary>Icon name for an activity type, or null when the type is not mapped.</summary>
    public static string? Name(Type activityType) {
        if (icons.TryGetValue(activityType, out var exact))
            return exact;

        if (activityType.IsGenericType && icons.TryGetValue(activityType.GetGenericTypeDefinition(), out var open))
            return open;

        return null;
    }

    /// <summary>Open Iconic CSS class for an activity type (for example "oi oi-clock"), or null.</summary>
    public static string? CssClass(Type? activityType) {
        var name = activityType == null ? null : Name(activityType);
        return name == null ? null : $"oi oi-{name}";
    }

    /// <summary>Open Iconic CSS class for an element (Activity or non-activity node element), or null.</summary>
    public static string? CssClass(object? element) => element == null ? null : CssClass(element.GetType());
}
