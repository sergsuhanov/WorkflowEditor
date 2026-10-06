using System.Activities;
using System.Activities.Statements;

namespace Blazor.WorkflowEditor.Activity.Statements;

public enum TryCatchSection {
    Try,
    CatchException,
    Finally
}

[Pair(typeof(System.Activities.Statements.TryCatch), typeof(TryCatchControl))]
public class TryCatchNode : DefaultNode {
    private readonly System.Activities.Statements.TryCatch activity;

    public TryCatchNode(Service service, System.Activities.Statements.TryCatch activity) : base(service, activity) {
        this.activity = activity;
        IsContainer = true;
    }

    public static readonly IReadOnlyList<Type> CatchExceptionTypes = new[] {
        typeof(System.Exception),
        typeof(ArgumentException),
        typeof(InvalidOperationException),
        typeof(NullReferenceException),
        typeof(TimeoutException),
        typeof(System.IO.IOException),
        typeof(FormatException)
    };

    public TryCatchSection SelectedSection { get; set; } = TryCatchSection.Try;

    /// <summary>Exception type of the Catch used when SelectedSection is CatchException.</summary>
    public Type SelectedExceptionType { get; set; } = typeof(System.Exception);

    public string SelectedExceptionTypeName {
        get => SelectedExceptionType.FullName!;
        set => SelectedExceptionType = CatchExceptionTypes.FirstOrDefault(t => t.FullName == value) ?? typeof(System.Exception);
    }

    private static Type? exceptionTypeOf(Catch c) => c.GetType().IsGenericType ? c.GetType().GetGenericArguments()[0] : null;

    private static System.Activities.Activity? handlerOf(Catch c) {
        var action = c.GetType().GetProperty("Action")?.GetValue(c);
        return action?.GetType().GetProperty("Handler")?.GetValue(action) as System.Activities.Activity;
    }

    private static void setHandler(Catch c, System.Activities.Activity? handler) {
        var action = c.GetType().GetProperty("Action")!.GetValue(c)!;
        action.GetType().GetProperty("Handler")!.SetValue(action, handler);
    }

    private Catch getOrCreateCatch(Type exceptionType) {
        var existing = activity.Catches.FirstOrDefault(c => exceptionTypeOf(c) == exceptionType);
        if (existing != null)
            return existing;

        var catchType = typeof(Catch<>).MakeGenericType(exceptionType);
        var created = (Catch)Activator.CreateInstance(catchType)!;
        var actionType = typeof(ActivityAction<>).MakeGenericType(exceptionType);
        var action = Activator.CreateInstance(actionType)!;
        var argument = Activator.CreateInstance(typeof(DelegateInArgument<>).MakeGenericType(exceptionType), "exception");
        actionType.GetProperty("Argument")!.SetValue(action, argument);
        catchType.GetProperty("Action")!.SetValue(created, action);
        activity.Catches.Add(created);
        return created;
    }

    public override IEnumerable<Variable> GetVariables() => GetVariables(activity.Variables);

    public override void LoadChilds(Func<System.Activities.Activity, ActivityDesignerPair> addActivity) {
        var pairs = new List<ActivityDesignerPair>();
        if (activity.Try != null)
            pairs.Add(addActivity(activity.Try));
        foreach (var c in activity.Catches) {
            var handler = handlerOf(c);
            if (handler != null)
                pairs.Add(addActivity(handler));
        }
        if (activity.Finally != null)
            pairs.Add(addActivity(activity.Finally));
        ArrangeRow(pairs);
    }

    public override void AddChild(ActivityDesignerPair child) {
        switch (SelectedSection) {
            case TryCatchSection.Try:
                activity.Try = child.Activity;
                break;
            case TryCatchSection.Finally:
                activity.Finally = child.Activity;
                break;
            default:
                setHandler(getOrCreateCatch(SelectedExceptionType), child.Activity);
                break;
        }
    }

    public override void RemoveChild(System.Activities.Activity child) {
        if (activity.Try == child)
            activity.Try = null;
        if (activity.Finally == child)
            activity.Finally = null;
        foreach (var c in activity.Catches.ToList()) {
            if (handlerOf(c) == child)
                setHandler(c, null);
        }
    }
}
