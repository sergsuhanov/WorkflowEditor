using System.Activities;
using System.Activities.Statements;
using Blazor.Diagrams;
using Blazor.WorkflowEditor.Activity;
using Blazor.WorkflowEditor.Activity.Stack.ControlFlow;
using Bunit;

namespace Blazor.WorkflowEditor.Tests;

/// <summary>
/// The panel that edits the selected activity. It says where the activity it shows is edited, so an activity
/// whose branches are filled on the card, or whose children live on the surface the card opens, is not mistaken
/// for one with nothing to edit.
/// </summary>
public class PropertiesPanelComponentTests {
    private static IRenderedComponent<Components.ActivityPropertiesPanel> renderPanel(
        BunitContext context,
        Service service) =>
        context.Render<Components.ActivityPropertiesPanel>(parameters => parameters
            .Add(component => component.Service, service));

    private static Service select(Service service, DefaultNode node) {
        service.Select(node);
        return service;
    }

    [Fact]
    public void AContainerSaysItsChildrenAreEditedOnTheSurfaceTheCardOpens() {
        using var context = new BunitContext();
        var sequence = new Sequence { DisplayName = "Prepare" };
        using var service = new Service(new BlazorDiagram(), () => { });
        service.SetActivityBuilder(new ActivityBuilder { Implementation = sequence });
        select(service, service.FindPair(sequence)!.Node);

        var panel = renderPanel(context, service);

        Assert.Equal("Sequence", panel.Find(".we-properties-panel .text-muted").TextContent.Trim());
        Assert.Contains("Its children are edited on the surface the card opens", panel.Find(".we-editing-hint").TextContent);
    }

    /// <summary>An activity that holds one Activity per branch fills its branches on the card, and the panel
    /// edits the fields of the activity itself.</summary>
    [Fact]
    public void AnActivityThatHoldsBranchesSaysTheyAreEditedInsideTheCard() {
        using var context = new BunitContext();
        var conditional = new If();
        using var service = new Service(new BlazorDiagram(), () => { });
        service.SetActivityBuilder(new ActivityBuilder { Implementation = conditional });

        var ifNode = Assert.IsType<IfNode>(service.FindPair(conditional)!.Node);
        select(service, ifNode);

        var panel = renderPanel(context, service);

        Assert.Contains("Each branch of this activity is edited inside this card", panel.Find(".we-editing-hint").TextContent);
        Assert.NotNull(panel.Find("#we-if-condition"));
    }

    /// <summary>A card that is neither a container nor a holder keeps its fields on the card, and the panel
    /// states the fallback it offers instead of leaving the activity without a word about it.</summary>
    [Fact]
    public void AnActivityWithoutAnEditorKeepsTheExplicitFallback() {
        using var context = new BunitContext();
        var throwActivity = new Throw();
        using var service = new Service(new BlazorDiagram(), () => { });
        service.SetActivityBuilder(new ActivityBuilder { Implementation = throwActivity });
        select(service, service.FindPair(throwActivity)!.Node);

        var panel = renderPanel(context, service);

        Assert.Contains("Its fields are edited on the card", panel.Find(".we-editing-hint").TextContent);
        Assert.Contains("No property editor is available for this activity yet",
            panel.Find(".we-properties-panel .we-panel-body").TextContent);

        //The two fields the panel always edits stay reachable.
        Assert.NotNull(panel.Find("#we-activity-display-name"));
        Assert.NotNull(panel.Find("#we-activity-note"));
    }
}
