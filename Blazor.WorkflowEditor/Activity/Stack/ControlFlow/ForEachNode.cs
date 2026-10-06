using System.Activities;

namespace Blazor.WorkflowEditor.Activity.Stack.ControlFlow;

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

    public string? BodyName => activity.Body?.Handler?.DisplayName;
    public bool HasBody => activity.Body?.Handler != null;

    public void ClearBody() {
        var handler = activity.Body?.Handler;
        if (handler == null)
            return;

        RemoveChildEverywhere(handler);
        service.NotifyStateChanged();
    }

    public override void AddChild(ActivityDesignerPair child) {
        //Body is normally created by the activity, but a hand written/edited schema may leave it null.
        if (activity.Body is not { } body)
            return;

        ReplaceChild(body.Handler, child);
        body.Handler = child.Activity;
        service.NotifyStateChanged();
    }

    public override void RemoveChild(System.Activities.Activity child) {
        if (activity.Body?.Handler == child)
            activity.Body.Handler = null;
    }
}
