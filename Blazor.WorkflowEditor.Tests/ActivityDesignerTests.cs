using System.Activities;
using System.Activities.Expressions;
using System.Activities.Statements;
using Blazor.Diagrams;
using Blazor.WorkflowEditor;
using Blazor.WorkflowEditor.Activity.Statements;
using Microsoft.VisualBasic.Activities;
using State = System.Activities.Statements.State;
using Parallel = System.Activities.Statements.Parallel;
using DefaultNode = Blazor.WorkflowEditor.Activity.DefaultNode;

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
    public void SequenceDesignerAddsRemovesAndLoadsChildrenInOrder() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var sequence = new Sequence { Activities = { new WriteLine(), new Delay(), new WriteLine() } };
        service.SetActivityBuilder(new ActivityBuilder { Implementation = sequence });
        service.Open(service.Items.First(p => p.Activity == sequence).Node);

        Assert.Equal(5, service.Items.Count());
        var middle = service.Items.First(p => p.Activity == sequence.Activities[1]);
        service.Delete(middle.Node);

        Assert.Equal(2, sequence.Activities.Count);
        Assert.Equal(4, service.Items.Count());
    }

    [Fact]
    public void CollectionDesignersBindVariables() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var owner = new Sequence();
        var list = new Variable { Activity = owner, Name = "values", Type = typeof(List<int>) };
        service.Variables.Add(list);
        var remove = new RemoveFromCollection<int>();
        var clear = new ClearCollection<int>();

        new RemoveFromCollectionNode<int>(service, remove).Collection = list;
        new ClearCollectionNode<int>(service, clear).Collection = list;

        Assert.Equal("values", ((VisualBasicValue<ICollection<int>>)remove.Collection.Expression!).ExpressionText);
        Assert.Equal("values", ((VisualBasicValue<ICollection<int>>)clear.Collection.Expression!).ExpressionText);
    }

    [Fact]
    public void ParallelDesignerManagesBranches() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var activity = new Parallel();
        var node = new ParallelNode(service, activity);
        var a = new WriteLine();
        var b = new Delay();

        node.AddChild(new ActivityDesignerPair { Activity = a, Node = new DefaultNode(service, a) });
        node.AddChild(new ActivityDesignerPair { Activity = b, Node = new DefaultNode(service, b) });
        node.RemoveChild(a);

        Assert.Same(b, Assert.Single(activity.Branches));
    }

    [Fact]
    public void TryCatchDesignerManagesAllSections() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var activity = new TryCatch();
        var node = new TryCatchNode(service, activity);
        var t = new WriteLine();
        var c = new WriteLine();
        var f = new Delay();

        foreach (var (section, child) in new (TryCatchSection, System.Activities.Activity)[] {
            (TryCatchSection.Try, t), (TryCatchSection.CatchException, c), (TryCatchSection.Finally, f) }) {
            node.SelectedSection = section;
            node.AddChild(new ActivityDesignerPair { Activity = child, Node = new DefaultNode(service, child) });
        }

        Assert.Same(t, activity.Try);
        Assert.Same(f, activity.Finally);
        Assert.Same(c, Assert.Single(activity.Catches).GetType().GetProperty("Action")!.GetValue(activity.Catches[0]) is ActivityAction<Exception> a ? a.Handler : null);
        node.RemoveChild(c);
        Assert.Null(((ActivityAction<Exception>)activity.Catches[0].GetType().GetProperty("Action")!.GetValue(activity.Catches[0])!).Handler);
    }

    [Fact]
    public void TryCatchDesignerSupportsMultipleCatchTypes() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var activity = new TryCatch();
        var node = new TryCatchNode(service, activity);
        var a = new WriteLine();
        var b = new WriteLine();
        var a2 = new Delay();

        node.SelectedSection = TryCatchSection.CatchException;
        node.SelectedExceptionType = typeof(ArgumentException);
        node.AddChild(new ActivityDesignerPair { Activity = a, Node = new DefaultNode(service, a) });
        node.SelectedExceptionType = typeof(TimeoutException);
        node.AddChild(new ActivityDesignerPair { Activity = b, Node = new DefaultNode(service, b) });
        node.SelectedExceptionType = typeof(ArgumentException);
        node.AddChild(new ActivityDesignerPair { Activity = a2, Node = new DefaultNode(service, a2) });

        Assert.Equal(2, activity.Catches.Count);
        Assert.IsType<Catch<ArgumentException>>(activity.Catches[0]);
        Assert.Same(a2, ((Catch<ArgumentException>)activity.Catches[0]).Action!.Handler);
        Assert.Same(b, ((Catch<TimeoutException>)activity.Catches[1]).Action!.Handler);

        var xaml = WorkflowXamlSerializer.SaveBuilder(new ActivityBuilder { Implementation = activity });
        var loaded = Assert.IsType<TryCatch>(WorkflowXamlSerializer.LoadBuilder(xaml).Implementation);
        Assert.Equal(2, loaded.Catches.Count);
    }

    [Fact]
    public void ForEachDesignerEditsValuesAndBody() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var activity = new ForEach<int>();
        var node = new ForEachNode<int>(service, activity);
        var body = new WriteLine();

        node.Values = "numbers";
        node.ItemName = "n";
        node.AddChild(new ActivityDesignerPair { Activity = body });

        Assert.Equal("numbers", ((VisualBasicValue<IEnumerable<int>>)activity.Values.Expression!).ExpressionText);
        Assert.Equal("n", activity.Body.Argument.Name);
        Assert.Same(body, activity.Body.Handler);
    }

    [Fact]
    public void NewContainersRoundTripThroughXaml() {
        var source = new ActivityBuilder {
            Implementation = new Sequence {
                Activities = {
                    new Parallel { Branches = { new WriteLine { Text = "a" }, new Delay() } },
                    new TryCatch { Try = new WriteLine { Text = "t" }, Finally = new WriteLine { Text = "f" } },
                    new DoWhile { Body = new WriteLine { Text = "d" } }
                }
            }
        };

        var xaml = WorkflowXamlSerializer.SaveBuilder(source);
        var result = Assert.IsType<Sequence>(WorkflowXamlSerializer.LoadBuilder(xaml).Implementation);

        Assert.Equal(2, Assert.IsType<Parallel>(result.Activities[0]).Branches.Count);
        Assert.NotNull(Assert.IsType<TryCatch>(result.Activities[1]).Finally);
        Assert.NotNull(Assert.IsType<DoWhile>(result.Activities[2]).Body);
    }

    [Fact]
    public void ThrowTerminateAndTypedAssignDesignersWriteArguments() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var thr = new Throw();
        var term = new TerminateWorkflow();
        var assign = new Assign<int>();

        new ThrowNode(service, thr).Exception = "New Exception(\"x\")";
        new TerminateWorkflowNode(service, term).Reason = "stop";
        var node = new AssignGenericNode<int>(service, assign) { Destination = "n", Source = "1 + 1" };

        Assert.Equal("New Exception(\"x\")", ((VisualBasicValue<Exception>)thr.Exception.Expression!).ExpressionText);
        Assert.Equal("stop", ((Literal<string>)term.Reason.Expression!).Value);
        Assert.Equal("n", ((VisualBasicReference<int>)assign.To.Expression!).ExpressionText);
        Assert.Equal("1 + 1", node.Source);
    }

    [Fact]
    public void ViewStateSurvivesXamlRoundTrip() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var write = new WriteLine { Text = "a" };
        Blazor.WorkflowEditor.Activity.State.Designer.SetCenterX(write, 120);
        Blazor.WorkflowEditor.Activity.State.Designer.SetCenterY(write, 80);
        var xaml = WorkflowXamlSerializer.SaveBuilder(new ActivityBuilder { Implementation = new Sequence { Activities = { write } } });
        var seq = (Sequence)WorkflowXamlSerializer.LoadBuilder(xaml).Implementation;

        Assert.Equal(120, Blazor.WorkflowEditor.Activity.State.Designer.GetCenterX(seq.Activities[0]));
        Assert.Equal(80, Blazor.WorkflowEditor.Activity.State.Designer.GetCenterY(seq.Activities[0]));
    }

    [Fact]
    public void FlowchartDesignerChainsStepsAndRoundTripsThroughXaml() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var chart = new Flowchart();
        var node = new FlowchartNode(service, chart);
        var a = new WriteLine { Text = "a" };
        var b = new WriteLine { Text = "b" };
        var c = new WriteLine { Text = "c" };

        foreach (var x in new[] { a, b, c })
            node.AddChild(new ActivityDesignerPair { Activity = x, Node = new DefaultNode(service, x) });

        var steps = chart.Nodes.Cast<FlowStep>().ToList();
        Assert.Same(steps[0], chart.StartNode);
        Assert.Same(steps[1], steps[0].Next);
        Assert.Same(steps[2], steps[1].Next);

        node.RemoveChild(b);
        Assert.Same(steps[2], steps[0].Next);
        Assert.Equal(2, chart.Nodes.Count);

        var xaml = WorkflowXamlSerializer.SaveBuilder(new ActivityBuilder { Implementation = chart });
        var loaded = Assert.IsType<Flowchart>(WorkflowXamlSerializer.LoadBuilder(xaml).Implementation);
        Assert.Equal(2, loaded.Nodes.Count);
        Assert.NotNull(loaded.StartNode);
    }

    [Fact]
    public void FlowchartLoadsAsContainerWithLinkedSteps() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var chart = new Flowchart();
        var s2 = new FlowStep { Action = new Delay() };
        var s1 = new FlowStep { Action = new WriteLine(), Next = s2 };
        chart.Nodes.Add(s1);
        chart.Nodes.Add(s2);
        chart.StartNode = s1;

        service.SetActivityBuilder(new ActivityBuilder { Implementation = chart });
        service.Open(service.Items.First(p => p.Activity == chart).Node);

        Assert.Contains(service.Items, p => p.Activity == s1.Action);
        Assert.Contains(service.Items, p => p.Activity == s2.Action);
    }

    private static (Service service, Flowchart chart, FlowchartNode node) openFlowchart(Flowchart chart) {
        var service = new Service(new BlazorDiagram(), () => { });
        service.SetActivityBuilder(new ActivityBuilder { Implementation = chart });
        var node = (FlowchartNode)service.Items.First(p => p.Activity == chart).Node;
        service.Open(node);
        return (service, chart, node);
    }

    [Fact]
    public void FlowDecisionAndSwitchEditConditionsAndTargets() {
        var chart = new Flowchart();
        var s1 = new FlowStep { Action = new WriteLine { DisplayName = "yes" } };
        var s2 = new FlowStep { Action = new WriteLine { DisplayName = "no" } };
        var decision = new FlowDecision { DisplayName = "check" };
        var sw = new FlowSwitch<string>();
        foreach (FlowNode n in new FlowNode[] { decision, sw, s1, s2 })
            chart.Nodes.Add(n);
        chart.StartNode = decision;

        var (service, _, flowchartNode) = openFlowchart(chart);
        using var _s = service;
        var decisionNode = Assert.IsType<FlowDecisionNode>(service.FindPair(decision)!.Node);

        decisionNode.Condition = "ok";
        decisionNode.TrueTarget = flowchartNode.IndexOf(s1);
        decisionNode.FalseTarget = flowchartNode.IndexOf(sw);

        Assert.Same(s1, decision.True);
        Assert.Same(sw, decision.False);
        Assert.Equal("ok", ((VisualBasicValue<bool>)decision.Condition!).ExpressionText);

        var switchNode = Assert.IsType<FlowSwitchNode<string>>(service.FindPair(sw)!.Node);
        switchNode.Expression = "mode";
        switchNode.DefaultTarget = flowchartNode.IndexOf(s2);
        Assert.True(switchNode.SetCase("a", flowchartNode.IndexOf(s1)));
        Assert.False(switchNode.SetCase("b", -1));

        Assert.Same(s2, sw.Default);
        Assert.Same(s1, sw.Cases["a"]);
        Assert.Equal(new[] { "a" }, switchNode.CaseKeys);

        // links follow the model: decision->s1, decision->sw, sw->s2, sw->s1
        Assert.Equal(4, service.LinkCount);

        var xaml = WorkflowXamlSerializer.SaveBuilder(new ActivityBuilder { Implementation = chart });
        var loaded = Assert.IsType<Flowchart>(WorkflowXamlSerializer.LoadBuilder(xaml).Implementation);
        var loadedDecision = loaded.Nodes.OfType<FlowDecision>().Single();
        Assert.IsType<FlowStep>(loadedDecision.True);
        Assert.IsType<FlowSwitch<string>>(loadedDecision.False);

        // removing a node clears references to it
        service.Delete(service.FindPair(s1.Action!)!.Node);
        Assert.Null(decision.True);
        Assert.False(sw.Cases.ContainsKey("a"));
    }

    [Fact]
    public void StateMachineDesignerManagesStatesAndTransitions() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var machine = new StateMachine();
        var a = new State { DisplayName = "A" };
        var b = new State { DisplayName = "B" };
        machine.States.Add(a);
        machine.States.Add(b);
        machine.InitialState = a;
        service.SetActivityBuilder(new ActivityBuilder { Implementation = machine });
        service.Open(service.Items.First(p => p.Activity == machine).Node);

        var aNode = Assert.IsType<StateNode>(service.FindPair(a)!.Node);
        var t = aNode.AddTransition();
        aNode.SetTarget(t, 1);
        aNode.SetCondition(t, "ready");
        aNode.IsFinal = false;
        service.FindPair(b)!.Node.GetType();
        ((StateNode)service.FindPair(b)!.Node).IsInitial = true;

        Assert.Same(b, t.To);
        Assert.Equal("ready", ((VisualBasicValue<bool>)t.Condition!).ExpressionText);
        Assert.Same(b, machine.InitialState);
        Assert.Equal(1, service.LinkCount);

        var xaml = WorkflowXamlSerializer.SaveBuilder(new ActivityBuilder { Implementation = machine });
        var loaded = Assert.IsType<StateMachine>(WorkflowXamlSerializer.LoadBuilder(xaml).Implementation);
        Assert.Equal(2, loaded.States.Count);
        Assert.Same(loaded.States[1], loaded.States[0].Transitions[0].To);

        service.Delete(service.FindPair(b)!.Node);
        Assert.Empty(a.Transitions);
        Assert.Same(a, machine.InitialState);
        Assert.Equal(0, service.LinkCount);
    }

    [Fact]
    public void ContainersRejectIncompatibleChildren() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var machine = new StateMachine();
        var chart = new Flowchart();
        var sequence = new Sequence();

        Assert.True(new StateMachineNode(service, machine).CanAdd(typeof(State)));
        Assert.False(new StateMachineNode(service, machine).CanAdd(typeof(WriteLine)));
        Assert.True(new FlowchartNode(service, chart).CanAdd(typeof(FlowDecision)));
        Assert.False(new FlowchartNode(service, chart).CanAdd(typeof(State)));
        Assert.False(new SequenceNode(service, sequence).CanAdd(typeof(State)));
        Assert.True(new SequenceNode(service, sequence).CanAdd(typeof(StateMachine)));
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
