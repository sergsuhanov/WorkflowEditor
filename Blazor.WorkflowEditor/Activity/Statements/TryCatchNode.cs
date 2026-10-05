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

    public TryCatchSection SelectedSection { get; set; } = TryCatchSection.Try;

    public override IEnumerable<Variable> GetVariables() => GetVariables(activity.Variables);

    private static System.Activities.Activity? handlerOf(Catch c) =>
        (c.GetType().GetProperty("Action")?.GetValue(c) as ActivityAction<System.Exception>)?.Handler;

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
                var existing = activity.Catches.OfType<Catch<System.Exception>>().FirstOrDefault();
                if (existing == null) {
                    existing = new Catch<System.Exception> {
                        Action = new ActivityAction<System.Exception> { Argument = new DelegateInArgument<System.Exception>("exception") }
                    };
                    activity.Catches.Add(existing);
                }
                existing.Action!.Handler = child.Activity;
                break;
        }
    }

    public override void RemoveChild(System.Activities.Activity child) {
        if (activity.Try == child)
            activity.Try = null;
        if (activity.Finally == child)
            activity.Finally = null;
        foreach (var c in activity.Catches.ToList()) {
            if (c is Catch<System.Exception> ce && ce.Action?.Handler == child)
                ce.Action.Handler = null;
        }
    }
}
