using System.Activities;
using Blazor.WorkflowEditor;
using Blazor.WorkflowEditor.Activity;

namespace WorkflowEditor.TestActivities.Design;

/// <summary>
/// Designer of <see cref="TestBranch{T}"/>: the card shows the field of the single input and the activity of
/// each of the three branches, which is what makes the one input and the three outputs of the activity visible.
/// </summary>
[Pair(typeof(TestBranch<>), typeof(TestBranchControl<>))]
public class TestBranchNode<T> : DefaultNode {
    private readonly TestBranch<T> activity;

    public TestBranchNode(Service service, TestBranch<T> activity) : base(service, activity) {
        this.activity = activity;
        IsGeneric = true;
        //Not a container: the card renders the single activity of each branch inline. The three branches are
        //made with the card, so it shows its three regions from the start.
        for (var index = 0; index < 3; index++)
            branchAction(index);
    }

    /// <summary>Expression the single input of the activity is filled with.</summary>
    public string Input {
        get => ActivityArguments.GetText(activity.Input);
        set {
            if (Input == value)
                return;

            if (string.IsNullOrWhiteSpace(value)) {
                //An empty field means the value is left to the caller: an expression of nothing would not compile.
                activity.Input = new InArgument<T>();
            } else {
                ActivityArguments.SetVisualBasicExpression(activity.Input, argument => activity.Input = (InArgument<T>)argument, value);
            }

            service.NotifyStateChanged();
        }
    }

    /// <summary>Branch a drop lands in; the region the user dropped on sets it before the drop is handled.</summary>
    public int SelectedBranch { get; set; }

    private IActivityHolder? firstSlot;
    private IActivityHolder? secondSlot;
    private IActivityHolder? thirdSlot;

    /// <summary>Slot that holds the first branch.</summary>
    public IActivityHolder FirstSlot => firstSlot ??= new Branch(this, 0);

    /// <summary>Slot that holds the second branch.</summary>
    public IActivityHolder SecondSlot => secondSlot ??= new Branch(this, 1);

    /// <summary>Slot that holds the third branch.</summary>
    public IActivityHolder ThirdSlot => thirdSlot ??= new Branch(this, 2);

    public override IReadOnlyList<IActivityHolder> Slots => new[] { FirstSlot, SecondSlot, ThirdSlot };

    public override void AddChild(ActivityDesignerPair child) {
        var branch = branchAction(SelectedBranch);

        //A branch holds a single activity: replace it.
        ReplaceChild(branch.Handler, child);
        branch.Handler = child.Activity;
        service.NotifyStateChanged();
    }

    public override void RemoveChild(System.Activities.Activity child) {
        for (var index = 0; index < 3; index++) {
            var branch = branchAction(index);
            if (branch.Handler == child)
                branch.Handler = null;
        }
    }

    private ActivityAction<T>? actionAt(int index) => index switch {
        0 => activity.First,
        1 => activity.Second,
        _ => activity.Third
    };

    /// <summary>
    /// Branch of the activity as the card shows it: the activity holds an activity action per branch, and an
    /// empty one is created here so every card has its three regions from the start.
    /// </summary>
    private ActivityAction<T> branchAction(int index) {
        if (actionAt(index) is { } existing)
            return existing;

        var branch = new ActivityAction<T> { Argument = new DelegateInArgument<T>(TestBranch<T>.InputArgumentName) };
        switch (index) {
            case 0:
                activity.First = branch;
                break;
            case 1:
                activity.Second = branch;
                break;
            default:
                activity.Third = branch;
                break;
        }

        return branch;
    }

    /// <summary>One branch of the activity, exposed as a slot so the card can render it.</summary>
    private sealed class Branch : IActivityHolder {
        private readonly TestBranchNode<T> owner;
        private readonly int index;

        public Branch(TestBranchNode<T> owner, int index) {
            this.owner = owner;
            this.index = index;
        }

        public DefaultNode Owner => owner;

        public string SlotLabel => TestBranch<T>.branchName(index);

        public System.Activities.Activity? Held => owner.branchAction(index).Handler;

        public void Attach(ActivityDesignerPair child) {
            owner.SelectedBranch = index;
            owner.AddChild(child);
        }
    }
}
