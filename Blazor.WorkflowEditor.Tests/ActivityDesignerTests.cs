using System.Activities;
using System.Activities.Expressions;
using System.Activities.Statements;
using Blazor.Diagrams;
using Blazor.WorkflowEditor;
using Blazor.WorkflowEditor.Activity.Statements;
using Microsoft.VisualBasic.Activities;

namespace Blazor.WorkflowEditor.Tests;

public class ActivityDesignerTests {
    [Fact]
    public void AssignDesignerWritesExpressionsToActivityArguments() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var activity = new Assign();
        var node = new AssignNode(service, activity);

        node.Destination = "result";
        node.Source = "40 + 2";

        Assert.Equal("result", ((VisualBasicReference<object>)activity.To.Expression!).ExpressionText);
        Assert.Equal("40 + 2", ((VisualBasicValue<object>)activity.Value.Expression!).ExpressionText);
    }

    [Fact]
    public void WriteLineDesignerUpdatesLiteralArgument() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var activity = new WriteLine { Text = new InArgument<string>("before") };
        var node = new WriteLineNode(service, activity);

        node.Text = "after";

        Assert.Equal("after", ((Literal<string>)activity.Text.Expression!).Value);
    }

    [Fact]
    public void DelayDesignerUpdatesLiteralDuration() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var activity = new Delay();
        var node = new DelayNode(service, activity);

        node.Duration = "00:00:12";

        Assert.Equal(TimeSpan.FromSeconds(12), ((Literal<TimeSpan>)activity.Duration.Expression!).Value);
    }

    [Fact]
    public void IfDesignerEditsConditionAndBothBranches() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var activity = new If();
        var node = new IfNode(service, activity);
        var thenActivity = new WriteLine();
        var elseActivity = new Delay();

        node.Condition = "ready";
        node.SelectedBranch = IfBranch.Then;
        node.AddChild(new ActivityDesignerPair { Activity = thenActivity });
        node.SelectedBranch = IfBranch.Else;
        node.AddChild(new ActivityDesignerPair { Activity = elseActivity });
        node.RemoveChild(thenActivity);

        Assert.Equal("ready", ((VisualBasicValue<bool>)activity.Condition.Expression!).ExpressionText);
        Assert.Null(activity.Then);
        Assert.Same(elseActivity, activity.Else);
    }

    [Fact]
    public void WhileDesignerEditsConditionAndBody() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var activity = new While();
        var node = new WhileNode(service, activity);
        var body = new Sequence();

        node.Condition = "keepRunning";
        node.AddChild(new ActivityDesignerPair { Activity = body });

        Assert.Equal("keepRunning", ((VisualBasicValue<bool>)activity.Condition!).ExpressionText);
        Assert.Same(body, activity.Body);
        node.RemoveChild(body);
        Assert.Null(activity.Body);
    }

    [Fact]
    public void AddToCollectionDesignerBindsSelectedWorkflowVariables() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var owner = new Sequence();
        var collection = new Variable {
            Activity = owner,
            Name = "values",
            Type = typeof(List<int>)
        };
        var item = new Variable {
            Activity = owner,
            Name = "nextValue",
            Type = typeof(int)
        };
        service.Variables.Add(collection);
        service.Variables.Add(item);
        var activity = new AddToCollection<int>();
        var node = new AddToCollectionNode<int>(service, activity);

        node.Collection = collection;
        node.Item = item;

        Assert.Equal("values", ((VisualBasicValue<ICollection<int>>)activity.Collection.Expression!).ExpressionText);
        Assert.Equal("nextValue", ((VisualBasicValue<int>)activity.Item.Expression!).ExpressionText);
    }

    [Fact]
    public void ReplacingWorkflowBuilderDoesNotAccumulateEditorNodes() {
        using var service = new Service(new BlazorDiagram(), () => { });

        service.SetActivityBuilder(new ActivityBuilder { Implementation = new Sequence() });
        Assert.Equal(2, service.Items.Count());

        service.SetActivityBuilder(new ActivityBuilder { Implementation = new Sequence() });
        Assert.Equal(2, service.Items.Count());
    }

    [Fact]
    public void DoWhileDesignerEditsConditionBodyAndVariables() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var activity = new DoWhile();
        var node = new DoWhileNode(service, activity);
        var body = new Sequence();

        node.Condition = "again";
        node.AddChild(new ActivityDesignerPair { Activity = body });
        service.AddVariable(activity, "counter", typeof(int), "1");

        Assert.Equal("again", ((VisualBasicValue<bool>)activity.Condition!).ExpressionText);
        Assert.Same(body, activity.Body);
        Assert.Equal("counter", Assert.Single(node.GetVariables()).Name);
        node.RemoveChild(body);
        Assert.Null(activity.Body);
    }

    [Fact]
    public void NavigatingIntoContainerDropsStaleNodesAndLoadsWithoutViewport() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var inner = new Sequence { Activities = { new WriteLine(), new WriteLine() } };
        var outer = new Sequence { Activities = { inner, new Delay() } };

        service.SetActivityBuilder(new ActivityBuilder { Implementation = outer });
        service.Open(service.Items.First(p => p.Activity == outer).Node);
        Assert.Equal(4, service.Items.Count());

        var innerPair = service.Items.First(p => p.Activity == inner);
        service.Open(innerPair.Node);

        Assert.Equal(5, service.Items.Count());
        Assert.DoesNotContain(service.Items, p => p.Activity is Delay);
    }

    [Fact]
    public void XamlRoundTripPreservesEditedWriteLineText() {
        var source = new ActivityBuilder {
            Implementation = new Sequence {
                Activities = {
                    new WriteLine { Text = new InArgument<string>("round trip") }
                }
            }
        };

        var xaml = WorkflowXamlSerializer.SaveBuilder(source);
        var result = Assert.IsType<Sequence>(WorkflowXamlSerializer.LoadBuilder(xaml).Implementation);
        var writeLine = Assert.IsType<WriteLine>(Assert.Single(result.Activities));

        Assert.Equal("round trip", ((Literal<string>)writeLine.Text.Expression!).Value);
    }

    [Fact]
    public void XamlRoundTripPreservesAssignExpressions() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var assign = new Assign();
        var node = new AssignNode(service, assign) {
            Destination = "result",
            Source = "40 + 2"
        };
        var source = new ActivityBuilder {
            Implementation = new Sequence { Activities = { assign } }
        };

        var xaml = WorkflowXamlSerializer.SaveBuilder(source);
        var sequence = Assert.IsType<Sequence>(WorkflowXamlSerializer.LoadBuilder(xaml).Implementation);
        var result = Assert.IsType<Assign>(Assert.Single(sequence.Activities));

        Assert.Equal("result", ((VisualBasicReference<object>)result.To.Expression!).ExpressionText);
        Assert.Equal("40 + 2", ((VisualBasicValue<object>)result.Value.Expression!).ExpressionText);
    }

    [Fact]
    public void XamlLoaderRejectsEmptyAndMalformedDocuments() {
        Assert.Throws<ArgumentException>(() => WorkflowXamlSerializer.LoadBuilder(" "));
        Assert.ThrowsAny<Exception>(() => WorkflowXamlSerializer.LoadBuilder("<Activity"));
    }

    [Fact]
    public void WorkflowValidationReturnsActivityErrors() {
        var result = System.Activities.Validation.ActivityValidationServices.Validate(new InvalidActivity());

        Assert.Contains(result.Errors, error => error.Message.Contains("Invalid test activity"));
    }

    private sealed class InvalidActivity : CodeActivity {
        protected override void Execute(CodeActivityContext context) { }

        protected override void CacheMetadata(CodeActivityMetadata metadata) =>
            metadata.AddValidationError("Invalid test activity");
    }
}
