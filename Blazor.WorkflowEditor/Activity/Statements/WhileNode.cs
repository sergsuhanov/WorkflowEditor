using System.Activities;
using System.Activities.Statements;

namespace Blazor.WorkflowEditor.Activity.Statements;

[Pair(typeof(System.Activities.Statements.While), typeof(WhileControl))]
public class WhileNode : DefaultNode {
    private readonly System.Activities.Statements.While activity;

    public WhileNode(Service service, System.Activities.Statements.While activity) : base(service, activity) {
        this.activity = activity;
        IsContainer = true;
    }

    public string Condition {
        get => ActivityArguments.GetText(activity.Condition);
        set => activity.Condition = ActivityArguments.CreateVisualBasicBooleanExpression(value);
    }

    public override void LoadChilds(Func<System.Activities.Activity, ActivityDesignerPair> addActivity) {
        if (activity.Body != null)
            addActivity(activity.Body);
    }

    public override void AddChild(ActivityDesignerPair child) => activity.Body = child.Activity;

    public override void RemoveChild(System.Activities.Activity child) {
        if (activity.Body == child)
            activity.Body = null;
    }
}
