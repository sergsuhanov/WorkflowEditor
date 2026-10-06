namespace Blazor.WorkflowEditor.Activity.Stack.Primitives;

[Pair(typeof(System.Activities.Statements.Delay), typeof(DelayControl))]
public class DelayNode : DefaultNode {
    private readonly System.Activities.Statements.Delay activity;

    public DelayNode(Service service, System.Activities.Statements.Delay activity) : base(service, activity) {
        this.activity = activity;
    }

    public string Duration {
        get => ActivityArguments.GetText(activity.Duration);
        set {
            if (TimeSpan.TryParse(value, System.Globalization.CultureInfo.InvariantCulture, out var duration))
                ActivityArguments.SetLiteral(activity.Duration, argument => activity.Duration = argument, duration);
        }
    }
}
