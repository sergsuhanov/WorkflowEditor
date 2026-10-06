using System.Activities;
using System.Activities.Statements;

namespace Blazor.WorkflowEditor.Activity.Statements;

public enum IfBranch {
    Then,
    Else
}

[Pair(typeof(System.Activities.Statements.If), typeof(IfControl))]
public class IfNode : DefaultNode {
    private readonly System.Activities.Statements.If activity;

    public IfNode(Service service, System.Activities.Statements.If activity) : base(service, activity) {
        this.activity = activity;
        IsContainer = true;
    }

    public string Condition {
        get => ActivityArguments.GetText(activity.Condition);
        set => ActivityArguments.SetVisualBasicExpression(activity.Condition, argument => activity.Condition = (InArgument<bool>)argument, value, argumentType: typeof(bool));
    }

    public string? ThenName => activity.Then?.DisplayName;
    public string? ElseName => activity.Else?.DisplayName;

    public IfBranch SelectedBranch { get; set; } = IfBranch.Then;

    public override void LoadChilds(Func<System.Activities.Activity, ActivityDesignerPair> addActivity) {
        if (activity.Then != null)
            addActivity(activity.Then);
        if (activity.Else != null)
            addActivity(activity.Else);
    }

    public override void AddChild(ActivityDesignerPair child) {
        if (SelectedBranch == IfBranch.Then)
            activity.Then = child.Activity;
        else
            activity.Else = child.Activity;
    }

    public override void RemoveChild(System.Activities.Activity child) {
        if (activity.Then == child)
            activity.Then = null;
        if (activity.Else == child)
            activity.Else = null;
    }
}
