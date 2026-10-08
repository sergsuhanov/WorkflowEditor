using System.Activities;
using System.Activities.Statements;

namespace Blazor.WorkflowEditor.Activity.Stack.ControlFlow;

public enum IfBranch {
    Then,
    Else
}

[Pair(typeof(System.Activities.Statements.If), typeof(IfControl))]
public class IfNode : DefaultNode {
    private readonly System.Activities.Statements.If activity;

    public IfNode(Service service, System.Activities.Statements.If activity) : base(service, activity) {
        this.activity = activity;
        //Not a container: the card renders the single activity of each branch inline.
    }

    public string Condition {
        get => ActivityArguments.GetText(activity.Condition);
        set {
            if (Condition == value)
                return;

            ActivityArguments.SetVisualBasicExpression(activity.Condition, argument => activity.Condition = (InArgument<bool>)argument, value, argumentType: typeof(bool));
            service.NotifyStateChanged();
        }
    }

    /// <summary>Both branches are shown next to each other, so the card is wider than the default one.</summary>
    public override string NodeLayoutClass => "we-node-split";

    public IfBranch SelectedBranch { get; set; } = IfBranch.Then;

    private IActivityHolder? thenSlot;
    private IActivityHolder? elseSlot;

    /// <summary>Slot that holds the Then branch; the card renders that activity inline.</summary>
    public IActivityHolder ThenSlot => thenSlot ??= new Branch(this, IfBranch.Then);

    /// <summary>Slot that holds the Else branch.</summary>
    public IActivityHolder ElseSlot => elseSlot ??= new Branch(this, IfBranch.Else);

    public override IReadOnlyList<IActivityHolder> Slots => new[] { ThenSlot, ElseSlot };

    public override void AddChild(ActivityDesignerPair child) {
        var branch = SelectedBranch;
        var existing = branch == IfBranch.Then ? activity.Then : activity.Else;

        //A branch holds a single activity: replace it.
        ReplaceChild(existing, child);

        if (branch == IfBranch.Then)
            activity.Then = child.Activity;
        else
            activity.Else = child.Activity;

        service.NotifyStateChanged();
    }

    public override void RemoveChild(System.Activities.Activity child) {
        if (activity.Then == child)
            activity.Then = null;
        if (activity.Else == child)
            activity.Else = null;
    }

    /// <summary>One branch of the If, exposed as a slot so the card can render it.</summary>
    private sealed class Branch : IActivityHolder {
        private readonly IfNode owner;
        private readonly IfBranch branch;

        public Branch(IfNode owner, IfBranch branch) {
            this.owner = owner;
            this.branch = branch;
        }

        public DefaultNode Owner => owner;

        public string SlotLabel => branch == IfBranch.Then ? "Then" : "Else";

        public System.Activities.Activity? Held =>
            branch == IfBranch.Then ? owner.activity.Then : owner.activity.Else;

        public void Attach(ActivityDesignerPair child) {
            owner.SelectedBranch = branch;
            owner.AddChild(child);
        }
    }
}
