using System.Activities;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace WorkflowEditor.TestActivities;

/// <summary>
/// An example of an activity a user of the editor wrote themselves: one input and three branches, of which
/// exactly one runs. The activity draws the branch when it runs, so a single schema can leave by any of the
/// three outputs — that is what the editor is expected to draw as three regions on one card.
/// </summary>
/// <typeparam name="T">Type of the single input; the editor asks for it when the activity is dropped.</typeparam>
public sealed class TestBranch<T> : NativeActivity {
    /// <summary>
    /// Name the branches read the input by in their expressions, as in <c>inputValue.Name</c>. It differs from
    /// the name of the argument on purpose: an expression compiler that does not tell the case apart would read
    /// the two as one and the schema would fail to validate.
    /// </summary>
    public const string InputArgumentName = "inputValue";

    /// <summary>The single input of the activity: the value the branch that runs works with.</summary>
    [DisplayName("Input")]
    public InArgument<T> Input { get; set; } = new InArgument<T>();

    /// <summary>First of the three branches.</summary>
    public ActivityAction<T>? First { get; set; }

    /// <summary>Second of the three branches.</summary>
    public ActivityAction<T>? Second { get; set; }

    /// <summary>Third of the three branches.</summary>
    public ActivityAction<T>? Third { get; set; }

    protected override void CacheMetadata(NativeActivityMetadata metadata) {
        //An argument of a NativeActivity is declared here and bound to the property that holds it, so a workflow
        //passes the value in under the name the card shows the field under.
        var input = new RuntimeArgument(nameof(Input), typeof(T), ArgumentDirection.In);
        metadata.Bind(Input ??= new InArgument<T>(), input);
        metadata.SetArgumentsCollection(new Collection<RuntimeArgument> { input });

        var branches = new[] { First, Second, Third };
        for (var index = 0; index < branches.Length; index++) {
            if (branches[index] is not { } branch) {
                metadata.AddValidationError($"{nameof(TestBranch<T>)} needs all three of its branches: {branchName(index)} is not set.");
                continue;
            }

            //A branch is an activity action, so its activity reads the input by the name of the argument and the
            //value is bound to it when the branch is scheduled. A schema written by hand can leave it null.
            branch.Argument ??= new DelegateInArgument<T>(InputArgumentName);
            metadata.AddImplementationDelegate(branch);

            //An empty branch would make the output it stands for do nothing, so the editor is told about it.
            if (branch.Handler == null)
                metadata.AddValidationError($"{nameof(TestBranch<T>)} needs all three of its branches: {branchName(index)} is empty.");
        }
    }

    protected override void Execute(NativeActivityContext context) {
        var branches = new List<ActivityAction<T>>(3);
        foreach (var branch in new[] { First, Second, Third }) {
            if (branch?.Handler != null)
                branches.Add(branch);
        }

        if (branches.Count == 0)
            throw new InvalidOperationException($"{nameof(TestBranch<T>)} has no branch to run.");

        context.ScheduleAction(branches[Random.Shared.Next(branches.Count)], Input.Get(context));
    }

    /// <summary>Name of a branch where the messages and the card say one, so both agree on it.</summary>
    internal static string branchName(int index) => index switch {
        0 => "First",
        1 => "Second",
        _ => "Third"
    };
}
