namespace Blazor.WorkflowEditor.Activity.Stack.Primitives;

[Pair(typeof(System.Activities.Statements.Assign), typeof(AssignControl))]
public class AssignNode : DefaultNode {
    private readonly System.Activities.Statements.Assign assignActivity;

    public AssignNode(Service service, System.Activities.Statements.Assign assignActivity) : base(service, assignActivity) {
        this.assignActivity = assignActivity;
        this.assignActivity.To ??= new System.Activities.OutArgument<object>();
        this.assignActivity.Value ??= new System.Activities.InArgument<object>();
    }

    /// <summary>Destination and source sit next to each other, so the card is wider than the default one.</summary>
    public override string NodeLayoutClass => "we-node-wide";

    public string Source {
        get => ActivityArguments.GetText(assignActivity.Value);
        set {
            if (Source == value)
                return;

            ActivityArguments.SetVisualBasicExpression(assignActivity.Value, argument => assignActivity.Value = (System.Activities.InArgument)argument, value);
            service.NotifyStateChanged();
        }
    }

    public string Destination {
        get => ActivityArguments.GetText(assignActivity.To);
        set {
            if (Destination == value)
                return;

            ActivityArguments.SetVisualBasicExpression(assignActivity.To, argument => assignActivity.To = (System.Activities.OutArgument)argument, value, isReference: true);
            service.NotifyStateChanged();
        }
    }
}
