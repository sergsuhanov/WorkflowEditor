using System.Activities;

namespace Blazor.WorkflowEditor.Activity.Statements;

[Pair(typeof(System.Activities.Statements.ForEach<>), typeof(ForEachControl<>))]
public class ForEachNode<T> : DefaultNode {
    private readonly System.Activities.Statements.ForEach<T> activity;

    public ForEachNode(Service service, System.Activities.Statements.ForEach<T> activity) : base(service, activity) {
        this.activity = activity;
        this.activity.Values ??= new InArgument<IEnumerable<T>>();
        this.activity.Body ??= new ActivityAction<T> { Argument = new DelegateInArgument<T>("item") };
        IsContainer = true;
        IsGeneric = true;
    }

    public string Values {
        get => ActivityArguments.GetText(activity.Values);
        set => ActivityArguments.SetVisualBasicExpression(activity.Values, argument => activity.Values = (InArgument<IEnumerable<T>>)argument, value);
    }

    public string ItemName {
        get => activity.Body.Argument?.Name ?? "item";
        set => activity.Body.Argument = new DelegateInArgument<T>(string.IsNullOrWhiteSpace(value) ? "item" : value);
    }

    public override void LoadChilds(Func<System.Activities.Activity, ActivityDesignerPair> addActivity) {
        if (activity.Body?.Handler != null)
            addActivity(activity.Body.Handler);
    }

    public override void AddChild(ActivityDesignerPair child) => activity.Body.Handler = child.Activity;

    public override void RemoveChild(System.Activities.Activity child) {
        if (activity.Body?.Handler == child)
            activity.Body.Handler = null;
    }
}
