using System.Activities;

namespace Blazor.WorkflowEditor.Activity.Stack.ControlFlow;

[Pair(typeof(System.Activities.Statements.ForEach<>), typeof(ForEachControl<>))]
public class ForEachNode<T> : DefaultNode {
    private readonly System.Activities.Statements.ForEach<T> activity;

    public ForEachNode(Service service, System.Activities.Statements.ForEach<T> activity) : base(service, activity) {
        this.activity = activity;
        this.activity.Values ??= new InArgument<IEnumerable<T>>();
        this.activity.Body ??= new ActivityAction<T> { Argument = new DelegateInArgument<T>("item") };
        //Not a container: the card renders the single activity of the body inline.
        IsGeneric = true;
    }

    public string Values {
        get => ActivityArguments.GetText(activity.Values);
        set {
            if (Values == value)
                return;

            ActivityArguments.SetVisualBasicExpression(activity.Values, argument => activity.Values = (InArgument<IEnumerable<T>>)argument, value);
            service.NotifyStateChanged();
        }
    }

    public string ItemName {
        get => activity.Body.Argument?.Name ?? "item";
        set {
            if (ItemName == value)
                return;

            activity.Body.Argument = new DelegateInArgument<T>(string.IsNullOrWhiteSpace(value) ? "item" : value);
            service.NotifyStateChanged();
        }
    }

    public override void LoadChilds(Func<System.Activities.Activity, ActivityDesignerPair> addActivity) {
        if (activity.Body?.Handler != null)
            addActivity(activity.Body.Handler);
    }

    private IActivityHolder? bodySlot;

    /// <summary>Slot that holds the loop body; the card renders that activity inline.</summary>
    public IActivityHolder BodySlot => bodySlot ??= new Body(this);

    public override IReadOnlyList<IActivityHolder> Slots => new[] { BodySlot };

    /// <summary>The loop body, exposed as a slot so the card can render it.</summary>
    private sealed class Body : IActivityHolder {
        private readonly ForEachNode<T> owner;

        public Body(ForEachNode<T> owner) => this.owner = owner;

        public DefaultNode Owner => owner;

        public string SlotLabel => "Body";

        public System.Activities.Activity? Held => owner.activity.Body?.Handler;

        public void Attach(ActivityDesignerPair child) => owner.AddChild(child);
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
