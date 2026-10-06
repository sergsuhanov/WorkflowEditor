using System.Activities;

namespace Blazor.WorkflowEditor.Activity.Stack.Primitives;

[Pair(typeof(System.Activities.Statements.Assign<>), typeof(AssignGenericControl<>))]
public class AssignGenericNode<T> : DefaultNode {
    private readonly System.Activities.Statements.Assign<T> activity;

    public AssignGenericNode(Service service, System.Activities.Statements.Assign<T> activity) : base(service, activity) {
        this.activity = activity;
        this.activity.To ??= new OutArgument<T>();
        this.activity.Value ??= new InArgument<T>();
        IsGeneric = true;
    }

    public string Source {
        get => ActivityArguments.GetText(activity.Value);
        set => ActivityArguments.SetVisualBasicExpression(activity.Value, argument => activity.Value = (InArgument<T>)argument, value);
    }

    public string Destination {
        get => ActivityArguments.GetText(activity.To);
        set => ActivityArguments.SetVisualBasicExpression(activity.To, argument => activity.To = (OutArgument<T>)argument, value, isReference: true);
    }
}
