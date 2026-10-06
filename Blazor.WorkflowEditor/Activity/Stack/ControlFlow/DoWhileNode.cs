using System.Activities;
using System.Activities.Statements;

namespace Blazor.WorkflowEditor.Activity.Stack.ControlFlow;

[Pair(typeof(System.Activities.Statements.DoWhile), typeof(DoWhileControl))]
public class DoWhileNode : DefaultNode {
    private readonly System.Activities.Statements.DoWhile activity;

    public DoWhileNode(Service service, System.Activities.Statements.DoWhile activity) : base(service, activity) {
        this.activity = activity;
        IsContainer = true;
    }

    public string Condition {
        get => ActivityArguments.GetText(activity.Condition);
        set => activity.Condition = ActivityArguments.CreateVisualBasicBooleanExpression(value);
    }

    public override IEnumerable<Variable> GetVariables() => GetVariables(activity.Variables);

    public override void LoadChilds(Func<System.Activities.Activity, ActivityDesignerPair> addActivity) {
        if (activity.Body != null)
            addActivity(activity.Body);
    }

    public string? BodyName => activity.Body?.DisplayName;
    public bool HasBody => activity.Body != null;

    public void ClearBody() {
        if (activity.Body == null)
            return;

        RemoveChildEverywhere(activity.Body);
        service.NotifyStateChanged();
    }

    public override void AddChild(ActivityDesignerPair child) {
        ReplaceChild(activity.Body, child);
        activity.Body = child.Activity;
        service.NotifyStateChanged();
    }

    public override void RemoveChild(System.Activities.Activity child) {
        if (activity.Body == child)
            activity.Body = null;
    }
}
