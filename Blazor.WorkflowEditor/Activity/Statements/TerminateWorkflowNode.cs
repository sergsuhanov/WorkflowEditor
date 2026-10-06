using System.Activities;

namespace Blazor.WorkflowEditor.Activity.Statements;

[Pair(typeof(System.Activities.Statements.TerminateWorkflow), typeof(TerminateWorkflowControl))]
public class TerminateWorkflowNode : DefaultNode {
    private readonly System.Activities.Statements.TerminateWorkflow activity;

    public TerminateWorkflowNode(Service service, System.Activities.Statements.TerminateWorkflow activity) : base(service, activity) {
        this.activity = activity;
        this.activity.Reason ??= new InArgument<string>(string.Empty);
    }

    public string Reason {
        get => ActivityArguments.GetText(activity.Reason);
        set {
            var text = value ?? string.Empty;
            ActivityArguments.SetText(activity.Reason, argument => activity.Reason = argument, text, text);
        }
    }
}
