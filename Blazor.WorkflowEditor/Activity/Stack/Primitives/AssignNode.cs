namespace Blazor.WorkflowEditor.Activity.Stack.Primitives;

[Pair(typeof(System.Activities.Statements.Assign), typeof(AssignControl))]
public class AssignNode : DefaultNode {
    private readonly System.Activities.Statements.Assign assignActivity;

    public AssignNode(Service service, System.Activities.Statements.Assign assignActivity) : base(service, assignActivity) {
        this.assignActivity = assignActivity;
        this.assignActivity.To ??= new System.Activities.OutArgument<object>();
        this.assignActivity.Value ??= new System.Activities.InArgument<object>();
    }

    public string Source {
        get => ActivityArguments.GetText(assignActivity.Value);
        set => ActivityArguments.SetVisualBasicExpression(assignActivity.Value, argument => assignActivity.Value = (System.Activities.InArgument)argument, value);
    }

    public string Destination {
        get => ActivityArguments.GetText(assignActivity.To);
        set => ActivityArguments.SetVisualBasicExpression(assignActivity.To, argument => assignActivity.To = (System.Activities.OutArgument)argument, value, isReference: true);
    }
}
