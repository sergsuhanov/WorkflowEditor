using System.Activities;
using System.Activities.Expressions;
using System.Activities.Statements;
using Blazor.Diagrams;
using Blazor.Diagrams.Core.Geometry;
using Blazor.WorkflowEditor;
using Blazor.WorkflowEditor.Activity;
using Blazor.WorkflowEditor.Activity.Stack.ControlFlow;
using Blazor.WorkflowEditor.Activity.Stack.Primitives;
using Blazor.WorkflowEditor.Activity.Stack.Collections;
using Blazor.WorkflowEditor.Activity.Flow;
using Blazor.WorkflowEditor.Activity.StateMachine;
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
    public void IfDesignerReplacesExistingBranchChild() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var activity = new If();
        var node = new IfNode(service, activity);
        var first = new WriteLine();
        var second = new Delay();

        node.SelectedBranch = IfBranch.Then;
        node.AddChild(new ActivityDesignerPair { Activity = first });
        node.AddChild(new ActivityDesignerPair { Activity = second });

        Assert.Same(second, activity.Then);
    }

    [Fact]
    public void IfDesignerRemovesTheChildOfABranch() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var elseActivity = new Delay();
        var activity = new If { Else = elseActivity };
        var node = new IfNode(service, activity);

        node.RemoveChildEverywhere(elseActivity);

        Assert.Null(activity.Else);
    }

    [Fact]
    public void BranchHoldersAreNotContainersAndExposeTheirBranchesAsSlots() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var ifActivity = new If();
        var whileActivity = new While();
        service.SetActivityBuilder(new ActivityBuilder {
            Implementation = new Sequence { Activities = { ifActivity, whileActivity } }
        });
        service.Open(service.Items.First(pair => pair.Activity is Sequence).Node);

        var ifNode = Assert.IsType<IfNode>(service.Items.Single(pair => ReferenceEquals(pair.Activity, ifActivity)).Node);
        var whileNode = Assert.IsType<WhileNode>(service.Items.Single(pair => ReferenceEquals(pair.Activity, whileActivity)).Node);

        //A branch holds a single activity that the card renders itself, so there is nothing to open.
        Assert.False(ifNode.IsContainer);
        Assert.False(whileNode.IsContainer);
        Assert.Equal(new[] { "Then", "Else" }, ifNode.Slots.Select(slot => slot.SlotLabel));
        Assert.Equal(new[] { "Body" }, whileNode.Slots.Select(slot => slot.SlotLabel));
        Assert.All(ifNode.Slots, slot => Assert.Same(ifNode, slot.Owner));
    }

    [Fact]
    public void DroppingOnABranchRegionRendersTheChildInsideTheCard() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var sequence = new Sequence();
        service.SetActivityBuilder(new ActivityBuilder { Implementation = sequence });
        service.Open(service.Items.First(pair => pair.Activity == sequence).Node);

        var ifActivity = new If();
        var ifNode = new IfNode(service, ifActivity);
        service.DropSlot = ifNode.ElseSlot;

        var (hasAdded, result) = service.AddActivity(typeof(WriteLine));

        Assert.True(hasAdded);
        Assert.IsType<WriteLine>(ifActivity.Else);
        Assert.Null(ifActivity.Then);
        Assert.Null(service.DropSlot);

        //The child is not a node of the diagram: its control is rendered inside the branch region instead.
        Assert.False(service.IsDisplayed(result.Node));
        Assert.True(result.Node.IsEmbedded);
        Assert.Same(ifNode, result.Node.EmbeddedOwner);
        Assert.NotNull(service.GetControlType(result.Node));
    }

    [Fact]
    public void LoadingAWorkflowCreatesTheNodesOfTheBranchChildren() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var thenActivity = new WriteLine { DisplayName = "then" };
        var elseActivity = new Delay();
        var ifActivity = new If { Then = thenActivity, Else = elseActivity };
        service.SetActivityBuilder(new ActivityBuilder { Implementation = ifActivity });

        var ifNode = Assert.IsType<IfNode>(service.Items.Single(pair => ReferenceEquals(pair.Activity, ifActivity)).Node);
        var thenNode = service.FindPair(thenActivity)!.Node;
        var elseNode = service.FindPair(elseActivity)!.Node;

        Assert.True(thenNode.IsEmbedded);
        Assert.Same(ifNode, thenNode.EmbeddedOwner);
        Assert.True(elseNode.IsEmbedded);
        Assert.Same(ifNode, elseNode.EmbeddedOwner);
        Assert.False(service.IsDisplayed(thenNode));
        Assert.Same(thenActivity, ifNode.ThenSlot.Held);
        Assert.Same(elseActivity, ifNode.ElseSlot.Held);
    }

    [Fact]
    public void SelectingABranchChildFillsThePropertiesPanelAndTheDiagramNodeTakesItOver() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var thenActivity = new WriteLine();
        var ifActivity = new If { Then = thenActivity };
        service.SetActivityBuilder(new ActivityBuilder { Implementation = ifActivity });

        var ifNode = Assert.IsType<IfNode>(service.Items.Single(pair => ReferenceEquals(pair.Activity, ifActivity)).Node);
        var thenNode = service.FindPair(thenActivity)!.Node;

        service.Select(thenNode);
        Assert.Contains(service.SelectedItems, item => ReferenceEquals(item.Node, thenNode));

        service.Select(ifNode);
        Assert.Contains(service.SelectedItems, item => ReferenceEquals(item.Node, ifNode));
        Assert.DoesNotContain(service.SelectedItems, item => ReferenceEquals(item.Node, thenNode));
    }

    [Fact]
    public void DeletingABranchChildClearsTheBranchItBelongsTo() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var thenActivity = new WriteLine();
        var ifActivity = new If { Then = thenActivity };
        service.SetActivityBuilder(new ActivityBuilder { Implementation = ifActivity });

        var thenNode = service.FindPair(thenActivity)!.Node;

        service.Delete(thenNode);

        Assert.Null(ifActivity.Then);
        Assert.DoesNotContain(service.Items, pair => ReferenceEquals(pair.Activity, thenActivity));
    }

    [Fact]
    public void OpeningAnEmbeddedContainerChildNavigatesIntoIt() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var inner = new Sequence { DisplayName = "inside", Activities = { new WriteLine() } };
        var ifActivity = new If { Then = inner };
        service.SetActivityBuilder(new ActivityBuilder { Implementation = ifActivity });

        var innerNode = service.FindPair(inner)!.Node;
        Assert.True(innerNode.IsContainer);

        service.Open(innerNode);

        Assert.Equal("inside", service.Path.Last().Name);
        Assert.False(innerNode.IsEmbedded);
        Assert.True(service.IsDisplayed(service.FindPair(inner.Activities[0])!.Node));
    }

    [Fact]
    public void DroppingOnALoopBodyRegionRendersTheBodyInsideTheCard() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var sequence = new Sequence();
        service.SetActivityBuilder(new ActivityBuilder { Implementation = sequence });
        service.Open(service.Items.First(pair => pair.Activity == sequence).Node);

        var whileActivity = new While();
        var whileNode = new WhileNode(service, whileActivity);
        service.DropSlot = whileNode.BodySlot;

        var (hasAdded, result) = service.AddActivity(typeof(WriteLine));

        Assert.True(hasAdded);
        Assert.IsType<WriteLine>(whileActivity.Body);
        Assert.False(service.IsDisplayed(result.Node));
        Assert.True(result.Node.IsEmbedded);
        Assert.Same(whileNode, result.Node.EmbeddedOwner);
    }

    [Fact]
    public void LoadingALoopCreatesTheNodeOfItsBody() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var body = new WriteLine { DisplayName = "body" };
        var whileActivity = new While { Body = body };
        service.SetActivityBuilder(new ActivityBuilder { Implementation = whileActivity });

        var bodyNode = service.FindPair(body)!.Node;

        Assert.True(bodyNode.IsEmbedded);
        Assert.False(service.IsDisplayed(bodyNode));
    }

    [Fact]
    public void TryCatchAndSwitchSlotsAttachTheirBranch() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var tryCatch = new TryCatchNode(service, new TryCatch());
        Assert.Equal(new[] { "Try", "Catch Exception", "Finally" }, tryCatch.Slots.Select(slot => slot.SlotLabel));

        var handler = new WriteLine();
        tryCatch.CatchSlot.Attach(new ActivityDesignerPair { Activity = handler });
        Assert.Same(handler, tryCatch.CatchSlot.Held);

        var switchActivity = new System.Activities.Statements.Switch<int>();
        var switchNode = new SwitchNode<int>(service, switchActivity);
        Assert.True(switchNode.AddCase("1"));
        var caseBody = new Delay();
        switchNode.CaseSlot("1").Attach(new ActivityDesignerPair { Activity = caseBody });
        Assert.Same(caseBody, switchActivity.Cases[1]);
        Assert.Contains("Case 1", switchNode.Slots.Select(slot => slot.SlotLabel));
    }

    [Fact]
    public void LoadingASwitchCreatesTheNodesOfItsBranches() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var switchActivity = new System.Activities.Statements.Switch<int>();
        var first = new WriteLine { DisplayName = "one" };
        var second = new Delay { DisplayName = "two" };
        switchActivity.Cases.Add(1, first);
        switchActivity.Cases.Add(2, second);
        switchActivity.Default = new WriteLine { DisplayName = "other" };
        service.SetActivityBuilder(new ActivityBuilder { Implementation = switchActivity });

        var node = Assert.IsType<SwitchNode<int>>(service.Items.Single(pair => ReferenceEquals(pair.Activity, switchActivity)).Node);

        Assert.False(node.IsContainer);
        Assert.Equal(new[] { "Default", "Case 1", "Case 2" }, node.Slots.Select(slot => slot.SlotLabel));
        Assert.All(service.Items.Where(pair => pair.Node.IsEmbedded), pair => Assert.Same(node, pair.Node.EmbeddedOwner));
        Assert.Same(second, node.CaseSlot("2").Held);
        Assert.Same(switchActivity.Default, node.DefaultSlot.Held);
    }

    [Fact]
    public void DroppingOnNodeDropTargetAddsChildToThatNodeInsteadOfOpenedContainer() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var inner = new Sequence();
        var outer = new Sequence { Activities = { inner } };
        service.SetActivityBuilder(new ActivityBuilder { Implementation = outer });
        service.Open(service.Items.First(p => p.Activity == outer).Node);

        var ifActivity = new If();
        var ifNode = new IfNode(service, ifActivity) { SelectedBranch = IfBranch.Else };
        service.DropTarget = ifNode;

        var (hasAdded, _) = service.AddActivity(typeof(WriteLine));

        Assert.True(hasAdded);
        Assert.IsType<WriteLine>(ifActivity.Else);
        Assert.Null(ifActivity.Then);
        Assert.Empty(inner.Activities);
        Assert.Null(service.DropTarget);
    }

    [Fact]
    public void WhileDesignerReplacesBodyAndClearsIt() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var activity = new While();
        var node = new WhileNode(service, activity);

        node.AddChild(new ActivityDesignerPair { Activity = new WriteLine() });
        var second = new Delay();
        node.AddChild(new ActivityDesignerPair { Activity = second });
        Assert.Same(second, activity.Body);

        node.RemoveChildEverywhere(second);
        Assert.Null(activity.Body);
    }

    [Fact]
    public void DoWhileAndForEachDesignersReplaceBodyAndRemoveIt() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var doWhile = new DoWhile();
        var doWhileNode = new DoWhileNode(service, doWhile);
        var doWhileBody = new Delay();
        doWhileNode.AddChild(new ActivityDesignerPair { Activity = doWhileBody });
        Assert.Same(doWhileBody, doWhile.Body);
        doWhileNode.RemoveChildEverywhere(doWhileBody);
        Assert.Null(doWhile.Body);

        var forEach = new ForEach<int>();
        var forEachNode = new ForEachNode<int>(service, forEach);
        var forEachBody = new WriteLine();
        forEachNode.AddChild(new ActivityDesignerPair { Activity = forEachBody });
        Assert.Same(forEachBody, forEach.Body.Handler);
        forEachNode.RemoveChildEverywhere(forEachBody);
        Assert.Null(forEach.Body.Handler);
    }

    [Fact]
    public void TryCatchDesignerReplacesAndRemovesTryCatchFinallySections() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var activity = new TryCatch();
        var node = new TryCatchNode(service, activity);

        node.SelectedSection = TryCatchSection.Try;
        node.AddChild(new ActivityDesignerPair { Activity = new WriteLine() });
        var replacement = new Delay();
        node.AddChild(new ActivityDesignerPair { Activity = replacement });
        Assert.Same(replacement, activity.Try);
        node.RemoveChildEverywhere(replacement);
        Assert.Null(activity.Try);

        node.SelectedSection = TryCatchSection.Finally;
        var final = new WriteLine();
        node.AddChild(new ActivityDesignerPair { Activity = final });
        Assert.Same(final, activity.Finally);
        node.RemoveChildEverywhere(final);
        Assert.Null(activity.Finally);
    }

    [Fact]
    public void TryCatchDesignerAddsAndRemovesCatchHandler() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var activity = new TryCatch();
        var node = new TryCatchNode(service, activity) { SelectedSection = TryCatchSection.CatchException };
        var handler = new WriteLine();

        node.AddChild(new ActivityDesignerPair { Activity = handler });

        Assert.Single(activity.Catches);
        Assert.Same(handler, node.CatchSlot.Held);

        node.RemoveChildEverywhere(handler);

        Assert.Null(node.CatchSlot.Held);
    }

    [Fact]
    public void DroppingOnParallelNodeAddsBranchInsteadOfOpenedContainer() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var sequence = new Sequence();
        service.SetActivityBuilder(new ActivityBuilder { Implementation = sequence });
        service.Open(service.Items.First(p => p.Activity == sequence).Node);

        var parallel = new Parallel();
        service.DropTarget = new ParallelNode(service, parallel);

        var (hasAdded, _) = service.AddActivity(typeof(WriteLine));

        Assert.True(hasAdded);
        Assert.Single(parallel.Branches);
        Assert.Empty(sequence.Activities);
    }

    [Fact]
    public void FlowchartDesignerAddsStepOnDropTargetAndTracksStart() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var sequence = new Sequence();
        service.SetActivityBuilder(new ActivityBuilder { Implementation = sequence });
        service.Open(service.Items.First(p => p.Activity == sequence).Node);

        var chart = new Flowchart();
        var node = new FlowchartNode(service, chart);
        service.DropTarget = node;

        var (hasAdded, _) = service.AddActivity(typeof(WriteLine));

        Assert.True(hasAdded);
        var step = Assert.IsType<FlowStep>(Assert.Single(chart.Nodes));
        Assert.Same(step, chart.StartNode);
        Assert.Equal(step.Action.DisplayName, node.StartLabel);
        Assert.NotNull(node.StepsSummary);
        Assert.Empty(sequence.Activities);
        Assert.Null(service.DropTarget);
    }

    [Fact]
    public void FlowchartStartPresentationTargetsTheSelectedStartElement() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var firstActivity = new WriteLine();
        var secondActivity = new Delay();
        var firstStep = new FlowStep { Action = firstActivity };
        var secondStep = new FlowStep { Action = secondActivity };
        var chart = new Flowchart {
            StartNode = firstStep,
            Nodes = { firstStep, secondStep }
        };
        service.SetActivityBuilder(new ActivityBuilder { Implementation = chart });
        var chartNode = service.Items.Single(p => ReferenceEquals(p.Activity, chart)).Node;

        service.Open(chartNode);

        Assert.True(service.ShowStartPresentation);
        Assert.Same(service.FindPair(firstActivity)!.Node, service.StartTargetNode);

        ((FlowchartNode)chartNode).StartIndex = 1;

        Assert.Same(service.FindPair(secondActivity)!.Node, service.StartTargetNode);
    }

    [Fact]
    public void EmptyFlowchartStartPresentationExplainsHowToCreateTheStartNode() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var chart = new Flowchart();
        service.SetActivityBuilder(new ActivityBuilder { Implementation = chart });
        var chartNode = service.Items.Single(p => ReferenceEquals(p.Activity, chart)).Node;

        service.Open(chartNode);

        Assert.True(service.ShowStartPresentation);
        Assert.Null(service.StartTargetNode);
        Assert.Equal("Add a node to create the flowchart start", service.StartHint);
    }

    [Fact]
    public void StateMachineDesignerAddsStateOnDropTargetAndTracksInitial() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var sequence = new Sequence();
        service.SetActivityBuilder(new ActivityBuilder { Implementation = sequence });
        service.Open(service.Items.First(p => p.Activity == sequence).Node);

        var machine = new StateMachine();
        var node = new StateMachineNode(service, machine);
        service.DropTarget = node;

        var (hasAdded, _) = service.AddActivity(typeof(State));

        Assert.True(hasAdded);
        var state = Assert.Single(machine.States);
        Assert.Same(state, machine.InitialState);
        Assert.Equal(state.DisplayName, node.InitialLabel);
        Assert.NotNull(node.StatesSummary);
    }

    [Fact]
    public void StateMachineDesignerNamesAddedStates() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var machine = new StateMachine();
        var node = new StateMachineNode(service, machine);

        node.AddChild(new ActivityDesignerPair { Element = new State(), Activity = null! });
        node.AddChild(new ActivityDesignerPair { Element = new State(), Activity = null! });

        Assert.Equal(new[] { "State1", "State2" }, machine.States.Select(s => s.DisplayName));
        Assert.Equal("State1", node.InitialLabel);
        Assert.Equal("State1, State2", node.StatesSummary);
    }

    [Fact]
    public void FlowchartStepConnectionDrawnOnDiagramUpdatesNext() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var one = new WriteLine { DisplayName = "one" };
        var two = new Delay { DisplayName = "two" };
        var chart = new Flowchart();
        chart.Nodes.Add(new FlowStep { Action = one });
        chart.Nodes.Add(new FlowStep { Action = two });
        chart.StartNode = chart.Nodes[0];
        service.SetActivityBuilder(new ActivityBuilder { Implementation = chart });
        service.Open(service.Items.First(p => p.Activity == chart).Node);

        var node = (FlowchartNode)service.Items.First(p => p.Activity == chart).Node;
        var from = service.Items.First(p => ReferenceEquals(p.Element, one));
        var to = service.Items.First(p => ReferenceEquals(p.Element, two));

        Assert.True(node.TryConnect(from, to));
        Assert.Same(chart.Nodes[1], ((FlowStep)chart.Nodes[0]).Next);

        Assert.True(node.TryDisconnect(from, to));
        Assert.Null(((FlowStep)chart.Nodes[0]).Next);
    }

    [Fact]
    public void FlowchartDecisionConnectionsFillTrueThenFalse() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var yes = new WriteLine { DisplayName = "yes" };
        var no = new Delay { DisplayName = "no" };
        var chart = new Flowchart();
        var decision = new FlowDecision();
        chart.Nodes.Add(decision);
        chart.Nodes.Add(new FlowStep { Action = yes });
        chart.Nodes.Add(new FlowStep { Action = no });
        chart.StartNode = decision;
        service.SetActivityBuilder(new ActivityBuilder { Implementation = chart });
        service.Open(service.Items.First(p => p.Activity == chart).Node);

        var node = (FlowchartNode)service.Items.First(p => p.Activity == chart).Node;
        var decisionPair = service.Items.First(p => ReferenceEquals(p.Element, decision));
        var yesPair = service.Items.First(p => ReferenceEquals(p.Element, yes));
        var noPair = service.Items.First(p => ReferenceEquals(p.Element, no));

        Assert.True(node.TryConnect(decisionPair, yesPair));
        Assert.True(node.TryConnect(decisionPair, noPair));

        Assert.Same(chart.Nodes[1], decision.True);
        Assert.Same(chart.Nodes[2], decision.False);
    }

    [Fact]
    public void StateMachineTransitionDrawnOnDiagramUpdatesTransitions() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var a = new State { DisplayName = "A" };
        var b = new State { DisplayName = "B" };
        var machine = new StateMachine { InitialState = a };
        machine.States.Add(a);
        machine.States.Add(b);
        service.SetActivityBuilder(new ActivityBuilder { Implementation = machine });
        service.Open(service.Items.First(p => p.Activity == machine).Node);

        var node = (StateMachineNode)service.Items.First(p => p.Activity == machine).Node;
        var aPair = service.Items.First(p => ReferenceEquals(p.Element, a));
        var bPair = service.Items.First(p => ReferenceEquals(p.Element, b));

        Assert.True(node.TryConnect(aPair, bPair));
        Assert.Same(b, Assert.Single(a.Transitions).To);

        Assert.True(node.TryDisconnect(aPair, bPair));
        Assert.Empty(a.Transitions);
    }

    [Fact]
    public void FlowchartSwitchConnectionAddsAndRemovesCases() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var sw = new FlowSwitch<string>();
        var s1 = new WriteLine { DisplayName = "one" };
        var s2 = new Delay { DisplayName = "two" };
        var chart = new Flowchart();
        chart.Nodes.Add(sw);
        chart.Nodes.Add(new FlowStep { Action = s1 });
        chart.Nodes.Add(new FlowStep { Action = s2 });
        chart.StartNode = sw;
        service.SetActivityBuilder(new ActivityBuilder { Implementation = chart });
        service.Open(service.Items.First(p => p.Activity == chart).Node);

        var node = (FlowchartNode)service.Items.First(p => p.Activity == chart).Node;
        var swPair = service.Items.First(p => ReferenceEquals(p.Element, sw));
        var s1Pair = service.Items.First(p => ReferenceEquals(p.Element, s1));
        var s2Pair = service.Items.First(p => ReferenceEquals(p.Element, s2));

        Assert.True(node.TryConnect(swPair, s1Pair));
        Assert.True(node.TryConnect(swPair, s2Pair));

        Assert.Equal(2, sw.Cases.Count);
        Assert.Contains("1", sw.Cases.Keys);
        Assert.Contains("2", sw.Cases.Keys);

        Assert.True(node.TryDisconnect(swPair, s1Pair));
        Assert.Single(sw.Cases);
    }

    [Fact]
    public void FlowchartSwitchConnectionUsesNumericKeysForNumericSwitch() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var sw = new FlowSwitch<int>();
        var s1 = new WriteLine();
        var chart = new Flowchart();
        chart.Nodes.Add(sw);
        chart.Nodes.Add(new FlowStep { Action = s1 });
        chart.StartNode = sw;
        service.SetActivityBuilder(new ActivityBuilder { Implementation = chart });
        service.Open(service.Items.First(p => p.Activity == chart).Node);

        var node = (FlowchartNode)service.Items.First(p => p.Activity == chart).Node;
        var swPair = service.Items.First(p => ReferenceEquals(p.Element, sw));
        var s1Pair = service.Items.First(p => ReferenceEquals(p.Element, s1));

        Assert.True(node.TryConnect(swPair, s1Pair));

        Assert.True(sw.Cases.ContainsKey(1));
    }

    [Fact]
    public void StateDesignerEditsEntryExitTriggerAndAction() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var state = new State();
        var node = new StateNode(service, state);

        node.SelectSlot(StateNode.Slot.Entry);
        node.AddChild(new ActivityDesignerPair { Activity = new WriteLine { DisplayName = "entry" } });
        Assert.Equal("entry", node.EntryName);

        node.SelectSlot(StateNode.Slot.Exit);
        node.AddChild(new ActivityDesignerPair { Activity = new Delay { DisplayName = "exit" } });
        Assert.Equal("exit", node.ExitName);

        node.ClearEntry();
        Assert.Null(state.Entry);
        Assert.False(node.HasEntry);

        var transition = node.AddTransition();
        node.SelectSlot(StateNode.Slot.Trigger, transition);
        node.AddChild(new ActivityDesignerPair { Activity = new WriteLine { DisplayName = "trigger" } });
        Assert.Equal("trigger", node.GetTrigger(transition));

        node.SelectSlot(StateNode.Slot.Action, transition);
        node.AddChild(new ActivityDesignerPair { Activity = new Delay { DisplayName = "action" } });
        Assert.Equal("action", node.GetAction(transition));

        node.ClearAction(transition);
        Assert.Null(transition.Action);
        Assert.NotNull(transition.Trigger);
        Assert.NotNull(state.Exit);
    }

    [Fact]
    public void AddActivityRejectsElementNotAcceptedByTarget() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var sequence = new Sequence();
        service.SetActivityBuilder(new ActivityBuilder { Implementation = sequence });
        service.Open(service.Items.First(p => p.Activity == sequence).Node);

        var machine = new StateMachine();
        service.DropTarget = new StateMachineNode(service, machine);

        var (hasAdded, _) = service.AddActivity(typeof(WriteLine));

        Assert.False(hasAdded);
        Assert.Empty(machine.States);
        Assert.Empty(sequence.Activities);
    }

    [Fact]
    public void CheckAddActivityAllowsGraphElementWhenGraphContainerIsPresent() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var sequence = new Sequence();
        service.SetActivityBuilder(new ActivityBuilder { Implementation = sequence });
        service.Open(service.Items.First(p => p.Activity == sequence).Node);

        Assert.False(service.CheckAddActivity(typeof(State)));

        Assert.True(service.AddActivity(typeof(StateMachine)).hasAdded);

        Assert.True(service.CheckAddActivity(typeof(State)));
    }

    [Fact]
    public void EmptyRootAcceptsExactlyOneImplementationActivity() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var builder = new ActivityBuilder();
        service.SetActivityBuilder(builder);

        Assert.Null(builder.Implementation);
        Assert.True(service.CheckAddActivity(typeof(WriteLine)));

        var (hasAdded, result) = service.AddActivity(typeof(WriteLine));

        Assert.True(hasAdded);
        Assert.Same(result.Activity, builder.Implementation);
        Assert.IsType<WriteLine>(builder.Implementation);
        Assert.False(service.CheckAddActivity(typeof(Delay)));
        Assert.False(service.AddActivity(typeof(Delay)).hasAdded);
        Assert.IsType<WriteLine>(builder.Implementation);
    }

    [Fact]
    public void AddActivityPlacesNodeAtTheSuppliedInitialPosition() {
        using var service = new Service(new BlazorDiagram(), () => { });
        service.SetActivityBuilder(new ActivityBuilder());
        var dropPosition = new Point(320, 180);

        var (hasAdded, result) = service.AddActivity(typeof(WriteLine), dropPosition);

        Assert.True(hasAdded);
        Assert.Equal(dropPosition, result.Node.CenterPosition);
    }

    [Fact]
    public void StartPresentationIsAvailableBeforeTheEmptyBuilderIsInitialized() {
        using var service = new Service(new BlazorDiagram(), () => { });

        Assert.True(service.ShowStartPresentation);
        Assert.Null(service.StartTargetNode);
        Assert.Equal("Drop the first activity here", service.StartHint);
    }

    [Fact]
    public void DeletingRootImplementationMakesTheRootAvailableAgain() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var builder = new ActivityBuilder { Implementation = new WriteLine() };
        service.SetActivityBuilder(builder);
        var rootNode = service.Items.Single(p => ReferenceEquals(p.Activity, builder.Implementation)).Node;

        service.Delete(rootNode);

        Assert.Null(builder.Implementation);
        Assert.True(service.CheckAddActivity(typeof(Delay)));
    }

    [Fact]
    public void RootDiagramDoesNotAddChildrenToAnExistingRootSequence() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var sequence = new Sequence();
        service.SetActivityBuilder(new ActivityBuilder { Implementation = sequence });

        Assert.False(service.CheckAddActivity(typeof(WriteLine)));
        Assert.False(service.AddActivity(typeof(WriteLine)).hasAdded);
        Assert.Empty(sequence.Activities);
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
        var owner = new Sequence {
            Variables = {
                new System.Activities.Variable<List<int>>("values"),
                new System.Activities.Variable<int>("nextValue")
            }
        };
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

        owner.Activities.Add(activity);
        var xaml = WorkflowXamlSerializer.SaveBuilder(new ActivityBuilder { Implementation = owner });
        var result = Assert.IsType<Sequence>(WorkflowXamlSerializer.LoadBuilder(xaml).Implementation);
        var restoredActivity = Assert.IsType<AddToCollection<int>>(Assert.Single(result.Activities));
        Assert.Equal("values", ((VisualBasicValue<ICollection<int>>)restoredActivity.Collection.Expression!).ExpressionText);
        Assert.Equal("nextValue", ((VisualBasicValue<int>)restoredActivity.Item.Expression!).ExpressionText);
    }

    [Fact]
    public void ReplacingWorkflowBuilderDoesNotAccumulateEditorNodes() {
        using var service = new Service(new BlazorDiagram(), () => { });

        service.SetActivityBuilder(new ActivityBuilder { Implementation = new Sequence() });
        Assert.Equal(2, service.Items.Count());
        Assert.False(service.CheckAddActivity(typeof(WriteLine)));

        service.SetActivityBuilder(new ActivityBuilder { Implementation = new Sequence() });
        Assert.Equal(2, service.Items.Count());
        Assert.False(service.CheckAddActivity(typeof(WriteLine)));
    }

    /// <summary>
    /// The root of the diagram is an ActivityBuilder wrapper (DynamicActivity) and the variables panel lists
    /// the variables of its implementation, so adding and renaming a variable from the root has to land in
    /// that collection instead of doing nothing.
    /// </summary>
    [Fact]
    public void VariablesAddedAtTheRootLandInTheImplementation() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var sequence = new Sequence();
        service.SetActivityBuilder(new ActivityBuilder { Implementation = sequence });

        //The panel passes the activity of the opened path item, which is the ActivityBuilder wrapper.
        var root = service.Path.Last().Activity;
        service.AddVariable(root, "counter", typeof(int), "1");
        service.RefreshVariables();

        var variable = Assert.Single(service.Variables);
        Assert.Equal("counter", variable.Name);
        Assert.Equal(typeof(int), variable.Type);
        Assert.Same(root, variable.Activity);

        //Renaming replaces the variable instead of adding a second one.
        service.UpdateVariable(root, "counter", "count", typeof(int), "2");
        service.RefreshVariables();

        variable = Assert.Single(service.Variables);
        Assert.Equal("count", variable.Name);
        Assert.Equal("count", Assert.Single(sequence.Variables).Name);
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
    public void SwitchDesignerEditsExpressionAndBranches() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var activity = new System.Activities.Statements.Switch<int>();
        var node = new SwitchNode<int>(service, activity);
        var modelChanges = 0;
        service.ModelChanged += () => modelChanges++;

        Assert.Contains(System.Activities.Validation.ActivityValidationServices.Validate(
                new Sequence { Activities = { activity } }).Errors,
            error => error.PropertyName == "Expression");

        node.Expression = "choice";
        Assert.Equal(1, modelChanges);
        Assert.Equal("choice", ((VisualBasicValue<int>)activity.Expression.Expression!).ExpressionText);
        Assert.DoesNotContain(System.Activities.Validation.ActivityValidationServices.Validate(
                new Sequence { Activities = { activity } }).Errors,
            error => error.PropertyName == "Expression");
        Assert.True(node.AddCase("01"));
        Assert.False(node.AddCase("1"));
        Assert.False(node.AddCase("invalid"));
        Assert.Equal("1", Assert.Single(node.CaseKeys));

        var caseBody = new WriteLine { DisplayName = "case 1" };
        Assert.True(node.SelectCase("1"));
        node.AddChild(new ActivityDesignerPair { Activity = caseBody });
        Assert.Same(caseBody, activity.Cases[1]);

        var defaultBody = new Delay { DisplayName = "default" };
        node.SelectDefault();
        node.AddChild(new ActivityDesignerPair { Activity = defaultBody });
        Assert.Same(defaultBody, activity.Default);

        node.RemoveChildEverywhere(caseBody);
        Assert.Contains("1", node.CaseKeys);
        Assert.Null(activity.Cases[1]);
        Assert.Null(node.CaseSlot("1").Held);
    }

    [Fact]
    public void SwitchDesignerLoadsAndRoundTripsBranches() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var activity = new System.Activities.Statements.Switch<int> {
            Expression = new InArgument<int>(new VisualBasicValue<int> { ExpressionText = "choice" }),
            Default = new WriteLine { Text = "other" }
        };
        activity.Cases.Add(1, new WriteLine { Text = "one" });
        activity.Cases.Add(2, new Delay());
        service.SetActivityBuilder(new ActivityBuilder { Implementation = activity });
        var node = Assert.IsType<SwitchNode<int>>(service.FindPair(activity)!.Node);

        Assert.Equal("choice", node.Expression);
        Assert.Equal(2, node.CaseKeys.Count);

        //Every branch is rendered inside the card, so all of them get a node without opening the Switch.
        Assert.Contains(service.Items, pair => ReferenceEquals(pair.Activity, activity.Default) && pair.Node.IsEmbedded);
        Assert.Contains(service.Items, pair => ReferenceEquals(pair.Activity, activity.Cases[1]) && pair.Node.IsEmbedded);
        Assert.Contains(service.Items, pair => ReferenceEquals(pair.Activity, activity.Cases[2]) && pair.Node.IsEmbedded);

        var xaml = WorkflowXamlSerializer.SaveBuilder(new ActivityBuilder { Implementation = activity });
        var loaded = Assert.IsType<System.Activities.Statements.Switch<int>>(
            WorkflowXamlSerializer.LoadBuilder(xaml).Implementation);
        Assert.Equal("choice",
            ((VisualBasicValue<int>)loaded.Expression.Expression!).ExpressionText);
        Assert.Equal(new[] { 1, 2 }, loaded.Cases.Keys.OrderBy(key => key));
        Assert.IsType<WriteLine>(loaded.Cases[1]);
        Assert.IsType<Delay>(loaded.Cases[2]);
        Assert.IsType<WriteLine>(loaded.Default);

        Assert.True(node.RemoveCase("1"));
        Assert.False(activity.Cases.ContainsKey(1));
        Assert.DoesNotContain(service.Items, pair => pair.Activity.DisplayName == "one");
    }

    [Fact]
    public void SwitchXamlRoundTripPreservesAnEmptyCase() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var activity = new System.Activities.Statements.Switch<int>();
        var node = new SwitchNode<int>(service, activity);

        Assert.True(node.AddCase("3"));

        var xaml = WorkflowXamlSerializer.SaveBuilder(new ActivityBuilder { Implementation = activity });
        var loaded = Assert.IsType<System.Activities.Statements.Switch<int>>(
            WorkflowXamlSerializer.LoadBuilder(xaml).Implementation);

        Assert.Contains(3, loaded.Cases.Keys);
        Assert.Null(loaded.Cases[3]);
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
    public void XamlRoundTripPreservesDesignerNotes() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var write = new WriteLine { DisplayName = "noted" };
        var node = new WriteLineNode(service, write) { Note = "Check the VAT rate" };

        Assert.True(node.HasNote);

        var xaml = WorkflowXamlSerializer.SaveBuilder(new ActivityBuilder {
            Implementation = new Sequence { Activities = { write } }
        });
        var sequence = Assert.IsType<Sequence>(WorkflowXamlSerializer.LoadBuilder(xaml).Implementation);
        var loaded = Assert.IsType<WriteLine>(Assert.Single(sequence.Activities));

        Assert.Equal("Check the VAT rate", Blazor.WorkflowEditor.Activity.State.Designer.GetNote(loaded));
    }

    [Fact]
    public void XamlLoaderAcceptsLeadingWhitespaceBeforeTheDeclaration() {
        var source = WorkflowXamlSerializer.SaveBuilder(new ActivityBuilder {
            Implementation = new Sequence { Activities = { new WriteLine { DisplayName = "round trip" } } }
        });

        //Documents pasted into the editor often start with a newline; the declaration must stay first.
        var builder = WorkflowXamlSerializer.LoadBuilder("\n\n  " + source + "\n");

        var sequence = Assert.IsType<Sequence>(builder.Implementation);
        Assert.IsType<WriteLine>(Assert.Single(sequence.Activities));
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

    [Fact]
    public void GraphContainersUseDirectionalPorts() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var one = new WriteLine { DisplayName = "one" };
        var chart = new Flowchart();
        chart.Nodes.Add(new FlowStep { Action = one });
        chart.StartNode = chart.Nodes[0];
        service.SetActivityBuilder(new ActivityBuilder { Implementation = chart });
        service.Open(service.Items.First(p => p.Activity == chart).Node);

        var node = service.Items.First(p => ReferenceEquals(p.Element, one)).Node;

        //Graph nodes offer several anchors: incoming on the left/top, outgoing on the right/bottom edges.
        Assert.Equal(4, node.Ports.Count);
        Assert.Equal(2, node.Ports.OfType<GraphInPort>().Count());
        Assert.Equal(2, node.Ports.OfType<GraphOutPort>().Count());
        Assert.IsType<GraphInPort>(node.IncomingPort);
        Assert.IsType<GraphOutPort>(node.OutcomingPort);
        Assert.Same(node.Ports[0], node.IncomingPort);
        Assert.Same(node.Ports[2], node.OutcomingPort);
        Assert.All(node.Ports, port => Assert.False(port.Locked));
        //Corner alignments are avoided on purpose: the orthogonal router cannot route them.
        Assert.All(node.Ports, port => Assert.True(port.Alignment is Blazor.Diagrams.Core.Models.PortAlignment.Left or Blazor.Diagrams.Core.Models.PortAlignment.Top or Blazor.Diagrams.Core.Models.PortAlignment.Right or Blazor.Diagrams.Core.Models.PortAlignment.Bottom));
    }

    [Fact]
    public void GraphPortsValidateConnectionDirection() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var one = new WriteLine { DisplayName = "one" };
        var two = new Delay { DisplayName = "two" };
        var chart = new Flowchart();
        chart.Nodes.Add(new FlowStep { Action = one });
        chart.Nodes.Add(new FlowStep { Action = two });
        chart.StartNode = chart.Nodes[0];
        service.SetActivityBuilder(new ActivityBuilder { Implementation = chart });
        service.Open(service.Items.First(p => p.Activity == chart).Node);

        var nodeOne = service.Items.First(p => ReferenceEquals(p.Element, one)).Node;
        var nodeTwo = service.Items.First(p => ReferenceEquals(p.Element, two)).Node;
        var outOne = nodeOne.Ports.OfType<GraphOutPort>().First();
        var inOne = nodeOne.Ports.OfType<GraphInPort>().First();
        var outTwo = nodeTwo.Ports.OfType<GraphOutPort>().First();
        var inTwo = nodeTwo.Ports.OfType<GraphInPort>().First();

        //Only output -> input is accepted; the reverse and output -> output are rejected.
        Assert.True(outOne.CanAttachTo(inTwo));
        Assert.False(inOne.CanAttachTo(outTwo));
        Assert.False(outOne.CanAttachTo(outTwo));
        Assert.False(inOne.CanAttachTo(inTwo));

        //Every anchor of the node follows the same rule, so any of them can be picked while drawing.
        Assert.All(nodeOne.Ports.OfType<GraphOutPort>(), port => Assert.True(port.CanAttachTo(inTwo)));
        Assert.All(nodeTwo.Ports.OfType<GraphInPort>(), port => Assert.True(outOne.CanAttachTo(port)));
        Assert.All(nodeOne.Ports.OfType<GraphInPort>(), port => Assert.False(port.CanAttachTo(outTwo)));
    }

    [Fact]
    public void StateMachineStatesUseDirectionalPorts() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var machine = new System.Activities.Statements.StateMachine();
        machine.States.Add(new State { DisplayName = "A" });
        machine.States.Add(new State { DisplayName = "B" });
        machine.InitialState = machine.States[0];
        service.SetActivityBuilder(new ActivityBuilder { Implementation = machine });
        service.Open(service.Items.First(p => p.Activity == machine).Node);

        foreach (var state in machine.States) {
            var node = service.FindPair(state)!.Node;

            Assert.Equal(4, node.Ports.Count);
            Assert.Equal(2, node.Ports.OfType<GraphInPort>().Count());
            Assert.Equal(2, node.Ports.OfType<GraphOutPort>().Count());
        }
    }

    [Fact]
    public void RedrawingTheSameConnectionDoesNotAddASecondLink() {
        var diagram = new BlazorDiagram();
        using var service = new Service(diagram, () => { });
        var one = new WriteLine { DisplayName = "one" };
        var two = new Delay { DisplayName = "two" };
        var chart = new Flowchart();
        chart.Nodes.Add(new FlowStep { Action = one });
        chart.Nodes.Add(new FlowStep { Action = two });
        chart.StartNode = chart.Nodes[0];
        service.SetActivityBuilder(new ActivityBuilder { Implementation = chart });
        service.Open(service.Items.First(p => p.Activity == chart).Node);

        var node = (FlowchartNode)service.Items.First(p => p.Activity == chart).Node;
        var from = service.Items.First(p => ReferenceEquals(p.Element, one));
        var to = service.Items.First(p => ReferenceEquals(p.Element, two));

        Assert.True(node.TryConnect(from, to));
        Assert.True(node.TryConnect(from, to));

        //Rebuilding the diagram links from the model yields a single connection.
        node.RebuildLinks();
        var link = Assert.Single(diagram.Links.OfType<Blazor.Diagrams.Core.Models.LinkModel>());
        measurePorts(from.Node, to.Node);
        link.Refresh();
        Assert.NotNull(link.PathGeneratorResult);
    }

    /// <summary>One link is anchored on the outgoing port, the other end on the incoming port.</summary>
    [Fact]
    public void FlowchartLinksAreAnchoredOnTheDirectionalPorts() {
        var diagram = new BlazorDiagram();
        using var service = new Service(diagram, () => { });
        var one = new WriteLine { DisplayName = "one" };
        var two = new Delay { DisplayName = "two" };
        var chart = new Flowchart();
        chart.Nodes.Add(new FlowStep { Action = one });
        chart.Nodes.Add(new FlowStep { Action = two });
        chart.StartNode = chart.Nodes[0];
        service.SetActivityBuilder(new ActivityBuilder { Implementation = chart });
        service.Open(service.Items.First(p => p.Activity == chart).Node);

        var node = (FlowchartNode)service.Items.First(p => p.Activity == chart).Node;
        Assert.True(node.TryConnect(service.Items.First(p => ReferenceEquals(p.Element, one)),
            service.Items.First(p => ReferenceEquals(p.Element, two))));

        //The diagram links mirror the model connection.
        node.RebuildLinks();
        var link = Assert.Single(diagram.Links.OfType<Blazor.Diagrams.Core.Models.LinkModel>());
        Assert.IsType<Blazor.Diagrams.Core.Anchors.SinglePortAnchor>(link.Source);
        Assert.IsType<Blazor.Diagrams.Core.Anchors.SinglePortAnchor>(link.Target);
        Assert.IsType<GraphOutPort>(link.Source.Model);
        Assert.IsType<GraphInPort>(link.Target.Model);
    }

    [Fact]
    public void FlowchartLinksAreBuiltAfterChildrenAreLaidOut() {
        var diagram = new BlazorDiagram();
        using var service = new Service(diagram, () => { });
        var one = new WriteLine { DisplayName = "one" };
        var two = new Delay { DisplayName = "two" };
        var chart = new Flowchart();
        //A connection that already exists in the model: it must be drawn as soon as the container is opened.
        var s2 = new FlowStep { Action = two };
        chart.Nodes.Add(new FlowStep { Action = one, Next = s2 });
        chart.Nodes.Add(s2);
        chart.StartNode = chart.Nodes[0];
        service.SetActivityBuilder(new ActivityBuilder { Implementation = chart });
        service.Open(service.Items.First(p => p.Activity == chart).Node);

        var link = Assert.Single(diagram.Links.OfType<Blazor.Diagrams.Core.Models.LinkModel>());
        var nodes = chart.Nodes.Select(n => service.FindPair(((FlowStep)n).Action)!.Node).ToList();

        //Children are laid out before links are created, so the ports of both nodes are usable.
        Assert.NotEqual(nodes[0].Position.X, nodes[1].Position.X);
        measurePorts(nodes[0], nodes[1]);
        link.Refresh();
        Assert.NotNull(link.PathGeneratorResult);
    }

    /// <summary>
    /// Rebuilds the port rectangles of the given nodes from their box, which is what the browser does after
    /// the layout changed.
    /// </summary>
    private static void measurePorts(params DefaultNode[] nodes) {
        foreach (var node in nodes)
            node.UpdatePortGeometry();
    }

    /// <summary>
    /// The library measures a port rectangle once, in the DOM, and never again, so a node that is moved or
    /// resized afterwards kept links attached to the old border point. The ports are placed from the node box
    /// instead, which makes the anchors follow the node.
    /// </summary>
    [Fact]
    public void PortGeometryIsComputedFromTheNodeBox() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var one = new WriteLine { DisplayName = "one" };
        var chart = new Flowchart();
        chart.Nodes.Add(new FlowStep { Action = one });
        chart.StartNode = chart.Nodes[0];
        service.SetActivityBuilder(new ActivityBuilder { Implementation = chart });
        service.Open(service.Items.First(p => p.Activity == chart).Node);

        var node = service.Items.First(p => ReferenceEquals(p.Element, one)).Node;
        var size = node.Size!;

        //A stale rectangle, like the one the library keeps after its single DOM measurement.
        node.OutcomingPort.Position = new Point(-1000, -1000);
        node.IncomingPort.Position = new Point(-1000, -1000);
        node.CenterPosition = new Point(500, 300);

        //The port circle sits on the border: its center is the middle of the right (out) and left (in) edge.
        Assert.Equal(node.Position.X + size.Width, node.OutcomingPort.MiddlePosition.X, 3);
        Assert.Equal(node.Position.Y + size.Height / 2, node.OutcomingPort.MiddlePosition.Y, 3);
        Assert.Equal(node.Position.X, node.IncomingPort.MiddlePosition.X, 3);
        Assert.Equal(node.Position.Y + size.Height / 2, node.IncomingPort.MiddlePosition.Y, 3);
        //And the anchors used by the links are on the outer edge of that circle.
        Assert.Equal(node.Position.X + size.Width + 10, node.OutcomingPort.GetShape().GetPointAtAngle(0)!.X, 3);
        Assert.Equal(node.Position.X - 10, node.IncomingPort.GetShape().GetPointAtAngle(180)!.X, 3);
        //The top and bottom anchors are the second choice offered by the node.
        Assert.Equal(node.Position.Y, node.Ports.Single(p => p.Alignment == Blazor.Diagrams.Core.Models.PortAlignment.Top).MiddlePosition.Y, 3);
        Assert.Equal(node.Position.Y + size.Height, node.Ports.Single(p => p.Alignment == Blazor.Diagrams.Core.Models.PortAlignment.Bottom).MiddlePosition.Y, 3);
        Assert.True(node.OutcomingPort.Initialized);
    }

    /// <summary>
    /// Every connection ends on a port of the node box, whatever the node does afterwards: this is what the
    /// Workflow Foundation designer does, and what keeps the routes attached when a node is expanded.
    /// </summary>
    [Fact]
    public void LinkEndsFollowTheNodeWhenItMovesOrIsResized() {
        var diagram = new BlazorDiagram();
        using var service = new Service(diagram, () => { });
        var one = new WriteLine { DisplayName = "one" };
        var two = new Delay { DisplayName = "two" };
        var chart = new Flowchart();
        var s2 = new FlowStep { Action = two };
        chart.Nodes.Add(new FlowStep { Action = one, Next = s2 });
        chart.Nodes.Add(s2);
        chart.StartNode = chart.Nodes[0];
        service.SetActivityBuilder(new ActivityBuilder { Implementation = chart });
        service.Open(service.Items.First(p => p.Activity == chart).Node);

        var from = service.Items.First(p => ReferenceEquals(p.Element, one)).Node;
        var to = service.Items.First(p => ReferenceEquals(p.Element, two)).Node;
        var link = Assert.Single(diagram.Links.OfType<Blazor.Diagrams.Core.Models.LinkModel>());

        //The card of the source grows (inline edit) and both nodes are moved.
        from.Size = new Blazor.Diagrams.Core.Geometry.Size(480, 260);
        from.CenterPosition = new Point(300, 200);
        to.CenterPosition = new Point(1200, 260);
        link.Refresh();

        var route = link.Route ?? Array.Empty<Point>();
        var source = link.Source.GetPosition(link, route);
        var target = link.Target.GetPosition(link, route);
        Assert.NotNull(source);
        Assert.NotNull(target);
        Assert.Equal(from.Position.X + from.Size!.Width + 10, source!.X, 3);
        Assert.Equal(from.Position.Y + from.Size.Height / 2, source.Y, 3);
        Assert.Equal(to.Position.X - 10, target!.X, 3);
        Assert.Equal(to.Position.Y + to.Size!.Height / 2, target.Y, 3);
    }

    [Fact]
    public void RedrawingADecisionConnectionDoesNotConsumeTheOtherBranch() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var decisionActivity = new FlowDecision();
        var yes = new WriteLine { DisplayName = "yes" };
        var no = new WriteLine { DisplayName = "no" };
        var chart = new Flowchart();
        chart.Nodes.Add(decisionActivity);
        chart.Nodes.Add(new FlowStep { Action = yes });
        chart.Nodes.Add(new FlowStep { Action = no });
        chart.StartNode = decisionActivity;
        service.SetActivityBuilder(new ActivityBuilder { Implementation = chart });
        service.Open(service.Items.First(p => p.Activity == chart).Node);

        var node = (FlowchartNode)service.Items.First(p => p.Activity == chart).Node;
        var from = service.Items.First(p => ReferenceEquals(p.Element, decisionActivity));
        var yesPair = service.Items.First(p => ReferenceEquals(p.Element, yes));
        var noPair = service.Items.First(p => ReferenceEquals(p.Element, no));

        Assert.True(node.TryConnect(from, yesPair));
        Assert.True(node.TryConnect(from, yesPair));

        Assert.Same(chart.Nodes[1], decisionActivity.True);
        Assert.Null(decisionActivity.False);

        Assert.True(node.TryConnect(from, noPair));
        Assert.Same(chart.Nodes[2], decisionActivity.False);
    }

    [Fact]
    public void RedrawingASwitchConnectionDoesNotAddASecondCase() {
        using var service = new Service(new BlazorDiagram(), () => { });
        var sw = new FlowSwitch<string>();
        var one = new WriteLine { DisplayName = "one" };
        var chart = new Flowchart();
        chart.Nodes.Add(sw);
        chart.Nodes.Add(new FlowStep { Action = one });
        chart.StartNode = sw;
        service.SetActivityBuilder(new ActivityBuilder { Implementation = chart });
        service.Open(service.Items.First(p => p.Activity == chart).Node);

        var node = (FlowchartNode)service.Items.First(p => p.Activity == chart).Node;
        var from = service.Items.First(p => ReferenceEquals(p.Element, sw));
        var to = service.Items.First(p => ReferenceEquals(p.Element, one));

        Assert.True(node.TryConnect(from, to));
        Assert.Equal("1", Assert.Single(sw.Cases).Key);

        Assert.True(node.TryConnect(from, to));
        Assert.Equal("1", Assert.Single(sw.Cases).Key);
    }

    [Fact]
    public void VisibleViewportAccountsForPanAndZoom() {
        var diagram = new BlazorDiagram();
        using var service = new Service(diagram, () => { });

        Assert.Null(service.VisibleViewport);

        diagram.SetContainer(new Rectangle(new Point(0, 0), new Size(800, 600)));
        diagram.SetZoom(2);
        diagram.SetPan(-200, -100);

        var view = service.VisibleViewport!.Value;

        Assert.Equal(100, view.Left);
        Assert.Equal(50, view.Top);
        Assert.Equal(400, view.Width);
        Assert.Equal(300, view.Height);
    }

    [Fact]
    public void FlowchartChildrenAreLaidOutInsideTheVisibleViewport() {
        var diagram = new BlazorDiagram();
        using var service = new Service(diagram, () => { });
        diagram.SetContainer(new Rectangle(new Point(0, 0), new Size(1400, 900)));
        //A panned and zoomed view: children must land in the visible area, not at the world origin.
        diagram.SetPan(-100, -50);

        var chart = new Flowchart();
        var actions = new List<WriteLine>();
        foreach (var name in new[] { "one", "two", "three", "four", "five" }) {
            var action = new WriteLine { DisplayName = name };
            actions.Add(action);
            chart.Nodes.Add(new FlowStep { Action = action });
        }
        chart.StartNode = chart.Nodes[0];
        service.SetActivityBuilder(new ActivityBuilder { Implementation = chart });
        service.Open(service.Items.First(p => p.Activity == chart).Node);

        var view = service.VisibleViewport!.Value;
        //A FlowStep is shown through its action, so the diagram node is found by the action.
        var children = actions.Select(a => service.FindPair(a)!.Node).ToList();

        Assert.Equal(5, children.Count);
        foreach (var child in children.Take(4)) {
            var size = child.Size!;

            Assert.InRange(child.Position.X, view.Left, view.Left + view.Width - size.Width);
            Assert.InRange(child.Position.Y, view.Top, view.Top + view.Height - size.Height);
        }
    }

    private sealed class InvalidActivity : CodeActivity {
        protected override void Execute(CodeActivityContext context) { }

        protected override void CacheMetadata(CodeActivityMetadata metadata) =>
            metadata.AddValidationError("Invalid test activity");
    }
}
