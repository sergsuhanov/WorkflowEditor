using System.Activities;

namespace Blazor.WorkflowEditor.Activity.Stack.Primitives;

[Pair(typeof(System.Activities.Statements.Throw), typeof(ThrowControl))]
public class ThrowNode : DefaultNode {
    private readonly System.Activities.Statements.Throw activity;

    public ThrowNode(Service service, System.Activities.Statements.Throw activity) : base(service, activity) {
        this.activity = activity;
        this.activity.Exception ??= new InArgument<System.Exception>();
    }

    public string Exception {
        get => ActivityArguments.GetText(activity.Exception);
        set => ActivityArguments.SetVisualBasicExpression(activity.Exception, argument => activity.Exception = (InArgument<System.Exception>)argument, value);
    }
}
