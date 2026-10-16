using System.Activities;
using System.Activities.Expressions;
using System.Activities.Statements;
using System.Activities.Validation;
using System.Collections.ObjectModel;
using Blazor.Diagrams;
using Blazor.WorkflowEditor;
using Blazor.WorkflowEditor.Activity;
using Bunit;
using Microsoft.AspNetCore.Components;
using Microsoft.VisualBasic.Activities;
using WorkflowEditor.TestActivities;
using WorkflowEditor.TestActivities.Design;

namespace Blazor.WorkflowEditor.Tests;

/// <summary>
/// The library of test activities is the example of an activity that lives in a project of its own. These tests
/// cover the activity itself and the way the editor draws it, and stand in for the card of any activity a user
/// of the editor wrote: one input, three branches, the branch drawn when the activity runs.
/// </summary>
public class TestBranchActivityTests {
    /// <summary>Branch activity that records the value it ran with, so a test sees which branch was chosen.</summary>
    private abstract class Sink : CodeActivity {
        public InArgument<string> Text { get; set; } = new InArgument<string>();

        protected override void CacheMetadata(CodeActivityMetadata metadata) {
            var argument = new RuntimeArgument("Text", typeof(string), ArgumentDirection.In);
            metadata.Bind(Text, argument);
            metadata.SetArgumentsCollection(new Collection<RuntimeArgument> { argument });
        }
    }

    private sealed class Record : Sink {
        private readonly ICollection<string> calls;
        private readonly string name;

        public Record(ICollection<string> calls, string name, string? expression = null) {
            this.calls = calls;
            this.name = name;
            if (expression != null)
                Text = new VisualBasicValue<string>(expression);
        }

        protected override void Execute(CodeActivityContext context) => calls.Add($"{name}({Text.Get(context)})");
    }

    /// <summary>Activity that puts a value into the variable the input of the tested activity is read from.</summary>
    private sealed class Provide : CodeActivity {
        public OutArgument<TestInput> Target { get; set; } = new OutArgument<TestInput>();

        public TestInput Value { get; set; } = new TestInput();

        protected override void CacheMetadata(CodeActivityMetadata metadata) {
            var argument = new RuntimeArgument("Target", typeof(TestInput), ArgumentDirection.Out);
            metadata.Bind(Target, argument);
            metadata.SetArgumentsCollection(new Collection<RuntimeArgument> { argument });
        }

        protected override void Execute(CodeActivityContext context) => Target.Set(context, Value);
    }

    private static ActivityAction<TestInput> branch(System.Activities.Activity? handler) => new() {
        Argument = new DelegateInArgument<TestInput>(TestBranch<TestInput>.InputArgumentName),
        Handler = handler
    };

    private static TestBranch<TestInput> withAllBranches() => withAllBranches(
        new WriteLine { DisplayName = "one" },
        new WriteLine { DisplayName = "two" },
        new WriteLine { DisplayName = "three" });

    /// <summary>Activity with the given handlers as its branches; a null handler is a branch left empty.</summary>
    private static TestBranch<TestInput> withAllBranches(
        System.Activities.Activity? first,
        System.Activities.Activity? second,
        System.Activities.Activity? third) => new() {
            First = branch(first),
            Second = branch(second),
            Third = branch(third)
        };

    [Fact]
    public void TheActivityTakesItsSingleInputByName() {
        var activity = withAllBranches();
        var inputs = new Dictionary<string, object> { { "Input", new TestInput { Name = "passed" } } };

        //The input is an argument of the activity, so a value can be passed in under the name the card shows.
        WorkflowInvoker.Invoke(activity, inputs);

        //The runtime rejects a key that does not map to an argument, which is what makes the run above a proof.
        inputs["Input2"] = new TestInput();
        Assert.Throws<ArgumentException>(() => WorkflowInvoker.Invoke(activity, inputs));
    }

    [Fact]
    public void TheActivityReportsTheBranchesThatAreNotFilled() {
        var missing = new TestBranch<TestInput> { First = branch(new WriteLine()), Second = branch(new WriteLine()) };

        var error = Assert.Single(ActivityValidationServices.Validate(missing).Errors);
        Assert.Contains("Third is not set", error.Message);

        var empty = withAllBranches(new WriteLine(), new WriteLine(), null);
        Assert.Contains("Third is empty", Assert.Single(ActivityValidationServices.Validate(empty).Errors).Message);
    }

    [Fact]
    public void TheActivityRunsExactlyOneOfItsThreeBranches() {
        var calls = new List<string>();
        var activity = withAllBranches(
            new Record(calls, "First"),
            new Record(calls, "Second"),
            new Record(calls, "Third"));
        var ran = new List<string>();

        for (var run = 0; run < 40; run++) {
            calls.Clear();
            WorkflowInvoker.Invoke(activity, new Dictionary<string, object> { { "Input", new TestInput() } });
            ran.Add(Assert.Single(calls));
        }

        //Which branch runs is drawn at random, so a run leaves by one output and 40 runs by more than one.
        Assert.True(ran.Distinct().Count() > 1, $"Only the {ran[0]} branch ever ran.");
    }

    [Fact]
    public void ABranchReadsTheInputTheWorkflowPassedIn() {
        var calls = new List<string>();
        var activity = withAllBranches(
            new Record(calls, "First", "inputValue.Name"),
            new Record(calls, "Second", "inputValue.Name"),
            new Record(calls, "Third", "inputValue.Name"));
        var incoming = new Variable<TestInput>("incoming");
        activity.Input = new InArgument<TestInput>(new VisualBasicValue<TestInput>("incoming"));
        var root = new Sequence {
            Variables = { incoming },
            Activities = {
                new Provide { Target = new OutArgument<TestInput>(incoming), Value = new TestInput { Name = "passed" } },
                activity
            }
        };

        //An expression that names a type of another assembly needs that assembly and its namespace, which is
        //what a host that runs the saved schema adds for the branches to read the value the workflow passed in.
        foreach (var target in new object[] { root, activity }) {
            TextExpression.SetReferencesForImplementation(target, new List<AssemblyReference> { new AssemblyReference(typeof(TestInput).Assembly.FullName) });
            TextExpression.SetNamespacesForImplementation(target, new List<string> { "WorkflowEditor.TestActivities" });
        }

        //The expression of a branch reads the input through the argument of the activity action, and it has to
        //resolve to that argument alone: a name that also matches the argument of the activity fails the schema.
        Assert.Empty(ActivityValidationServices.Validate(root).Errors);

        WorkflowInvoker.Invoke(root);

        Assert.EndsWith("(passed)", Assert.Single(calls));
    }

    [Fact]
    public void TheEditorFindsTheCardOfTheActivityInAnotherAssembly() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var sequence = new Sequence();
        service.SetActivityBuilder(new ActivityBuilder { Implementation = sequence });
        service.Open(service.Items.First(pair => pair.Activity == sequence).Node);

        //The type parameter is chosen when the activity is dropped, and the card of the activity is found by the
        //[Pair] attribute of the library it lives in.
        var (hasAdded, result) = service.AddActivity(typeof(TestBranch<>), typeof(TestInput));

        Assert.True(hasAdded);
        var node = Assert.IsType<TestBranchNode<TestInput>>(result.Node);
        Assert.Equal(new[] { "First", "Second", "Third" }, node.Slots.Select(slot => slot.SlotLabel));
        Assert.All(node.Slots, slot => Assert.Same(node, slot.Owner));
    }

    [Fact]
    public void DroppingOnABranchOfTheActivityFillsThatBranch() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var sequence = new Sequence();
        service.SetActivityBuilder(new ActivityBuilder { Implementation = sequence });
        service.Open(service.Items.First(pair => pair.Activity == sequence).Node);
        var activity = new TestBranch<TestInput>();
        var node = new TestBranchNode<TestInput>(service, activity);
        service.DropSlot = node.ThirdSlot;

        var (hasAdded, _) = service.AddActivity(typeof(WriteLine));

        Assert.True(hasAdded);
        Assert.IsType<WriteLine>(activity.Third!.Handler);
        Assert.Null(activity.First!.Handler);
        Assert.Null(activity.Second!.Handler);
    }

    [Fact]
    public void TheCardEditsTheInputExpressionAndTheBranches() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var activity = new TestBranch<TestInput>();
        var node = new TestBranchNode<TestInput>(service, activity);

        node.Input = "payload";
        node.SecondSlot.Attach(new ActivityDesignerPair { Activity = new WriteLine() });

        Assert.Equal("payload", ((VisualBasicValue<TestInput>)activity.Input.Expression!).ExpressionText);
        Assert.Equal("payload", node.Input);
        Assert.Same(activity.Second!.Handler, node.SecondSlot.Held);
        Assert.Null(node.FirstSlot.Held);
        Assert.Null(node.ThirdSlot.Held);
    }

    [Fact]
    public void ClearingTheInputFieldLeavesTheArgumentUnset() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var activity = new TestBranch<TestInput>();
        var node = new TestBranchNode<TestInput>(service, activity);

        node.Input = "payload";
        node.Input = string.Empty;

        //An argument left without an expression is one the caller can pass a value to, an empty one would not
        //compile, so clearing the field has to take the expression away rather than blank it.
        Assert.Null(activity.Input.Expression);
        Assert.Empty(node.Input);
    }

    [Fact]
    public void TheInputFieldOfTheCardWritesTheExpressionOfTheArgument() {
        using var context = new BunitContext();
        context.JSInterop.Mode = JSRuntimeMode.Loose;
        using var service = new Service(new BlazorDiagram(), () => { });
        var activity = new TestBranch<TestInput>();
        var node = new TestBranchNode<TestInput>(service, activity);

        var card = context.Render<CascadingValue<Service>>(parameters => parameters
            .Add(cascading => cascading.Value, service)
            .AddChildContent(builder => {
                builder.OpenComponent<TestBranchControl<TestInput>>(0);
                builder.AddAttribute(1, "Node", node);
                builder.CloseComponent();
            }));

        //The field has to be a binding of the control: a card whose fields are not compiled is a card that
        //shows a value the activity never keeps.
        card.Find("input[aria-label='Input']").Change("payload");

        Assert.Equal("payload", ((VisualBasicValue<TestInput>)activity.Input.Expression!).ExpressionText);
        Assert.Equal("payload", node.Input);
    }

    [Fact]
    public void TheActivityAndItsBranchesSurviveTheRoundTripThroughXaml() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var activity = withAllBranches();
        new TestBranchNode<TestInput>(service, activity).Input = "payload";

        var xaml = WorkflowXamlSerializer.SaveBuilder(new ActivityBuilder {
            Implementation = new Sequence { Activities = { activity } }
        });
        var restored = Assert.IsType<TestBranch<TestInput>>(
            Assert.Single(((Sequence)WorkflowXamlSerializer.LoadBuilder(xaml).Implementation).Activities));

        Assert.Equal("payload", ((VisualBasicValue<TestInput>)restored.Input.Expression!).ExpressionText);
        Assert.Equal(
            new[] { "one", "two", "three" },
            new[] { restored.First, restored.Second, restored.Third }.Select(action => action!.Handler!.DisplayName));
        Assert.Equal(
            new[] { "inputValue", "inputValue", "inputValue" },
            new[] { restored.First, restored.Second, restored.Third }.Select(action => action!.Argument!.Name));
    }
}
