using System.Activities.Statements;

namespace Blazor.WorkflowEditor.Activity.Stack.Primitives;

[Pair(typeof(System.Activities.Statements.WriteLine), typeof(WriteLineControl))]
public class WriteLineNode : DefaultNode {
    private readonly WriteLine activity;

    public WriteLineNode(Service service, System.Activities.Statements.WriteLine activity) : base(service, activity) {
        this.activity = activity;
        this.activity.Text ??= new System.Activities.InArgument<string>(string.Empty);
    }

    //TODO: ..\CoreWF\src\Test\TestCases.Workflows\ExpressionTests.cs 
    public string? Text {
        get {
            return ActivityArguments.GetText(activity.Text);
        }
        set {
            var text = value ?? string.Empty;
            ActivityArguments.SetText(activity.Text, argument => activity.Text = argument, text, text);
        }
    }
}
