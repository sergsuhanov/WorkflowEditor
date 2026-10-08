using System.Activities;
using System.Activities.Statements;

namespace Blazor.WorkflowEditor.Activity.Stack.ControlFlow;

[Pair(typeof(System.Activities.Statements.While), typeof(WhileControl))]
public class WhileNode : DefaultNode {
    private readonly System.Activities.Statements.While activity;

    public WhileNode(Service service, System.Activities.Statements.While activity) : base(service, activity) {
        this.activity = activity;
        //Not a container: the card renders the single activity of the body inline.
    }

    public string Condition {
        get => ActivityArguments.GetText(activity.Condition);
        set {
            if (Condition == value)
                return;

            activity.Condition = ActivityArguments.CreateVisualBasicBooleanExpression(value);
            service.NotifyStateChanged();
        }
    }

    public override IEnumerable<Variable> GetVariables() => GetVariables(activity.Variables);

    private IActivityHolder? bodySlot;

    /// <summary>Slot that holds the loop body; the card renders that activity inline.</summary>
    public IActivityHolder BodySlot => bodySlot ??= new Body(this);

    public override IReadOnlyList<IActivityHolder> Slots => new[] { BodySlot };

    /// <summary>The loop body, exposed as a slot so the card can render it.</summary>
    private sealed class Body : IActivityHolder {
        private readonly WhileNode owner;

        public Body(WhileNode owner) => this.owner = owner;

        public DefaultNode Owner => owner;

        public string SlotLabel => "Body";

        public System.Activities.Activity? Held => owner.activity.Body;

        public void Attach(ActivityDesignerPair child) => owner.AddChild(child);
    }

    public override void AddChild(ActivityDesignerPair child) {
        ReplaceChild(activity.Body, child);
        activity.Body = child.Activity;
        service.NotifyStateChanged();
    }

    public override void RemoveChild(System.Activities.Activity child) {
        if (activity.Body == child)
            activity.Body = null;
    }
}
