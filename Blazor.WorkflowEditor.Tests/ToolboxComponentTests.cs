using System.Activities.Statements;
using Blazor.Diagrams;
using Bunit;
using Microsoft.AspNetCore.Components.Web;

namespace Blazor.WorkflowEditor.Tests;

/// <summary>
/// The panel the page hands the toolbox to: the groups it draws, the search that narrows them, and the header
/// that collapses it. The activities of a group are the ones the page put there, so most of what the panel
/// draws comes from its parameters.
/// </summary>
public class ToolboxComponentTests {
    private static ToolBoxGroup group(string name, params Type[] activities) {
        var result = new ToolBoxGroup { Name = name };
        foreach (var activity in activities)
            result.Add(activity);

        return result;
    }

    private static List<ToolBoxGroup> groups() => new() {
        group("Control Flow", typeof(Sequence), typeof(If)),
        group("Primitives", typeof(WriteLine))
    };

    private static IRenderedComponent<Components.ToolboxComponent> renderPanel(
        BunitContext context,
        Service service,
        IEnumerable<ToolBoxGroup> toolboxGroups,
        bool collapsed = false,
        Action<bool>? onCollapsed = null) =>
        context.Render<Components.ToolboxComponent>(parameters => parameters
            .Add(component => component.Service, service)
            .Add(component => component.ToolBoxGroups, toolboxGroups)
            .Add(component => component.Collapsed, collapsed)
            .Add(component => component.CollapsedChanged, value => onCollapsed?.Invoke(value)));

    [Fact]
    public void DrawsEveryGroupWithTheActivitiesThePageSupplied() {
        using var context = new BunitContext();
        using var service = new Service(new BlazorDiagram(), () => { });

        var panel = renderPanel(context, service, groups());

        Assert.Equal(new[] { "Control Flow", "Primitives" },
            panel.FindAll(".groupName").Select(name => name.TextContent.Trim()));
        Assert.Equal(new[] { "Sequence", "If", "WriteLine" },
            panel.FindAll(".items li").Select(item => item.TextContent.Trim()));
    }

    /// <summary>A group is a closed list until its name is clicked, which keeps a long toolbox short.</summary>
    [Fact]
    public void EveryGroupStartsClosedAndOpensOnItsName() {
        using var context = new BunitContext();
        using var service = new Service(new BlazorDiagram(), () => { });

        var panel = renderPanel(context, service, groups());

        Assert.All(panel.FindAll(".items"), items => Assert.Contains("collapse", items.ClassName));

        panel.FindAll(".groupName")[1].Click();

        Assert.DoesNotContain("collapse", panel.FindAll(".items")[1].ClassName);
        Assert.Contains("collapse", panel.FindAll(".items")[0].ClassName);
    }

    /// <summary>The search keeps the activities whose name holds what was typed, and the groups that hold them.</summary>
    [Fact]
    public void SearchingKeepsTheMatchingActivitiesAndTheGroupsThatHoldThem() {
        using var context = new BunitContext();
        using var service = new Service(new BlazorDiagram(), () => { });

        var panel = renderPanel(context, service, groups());
        panel.Find("input[aria-label=\"Search activities\"]").Change("write");

        Assert.Equal(new[] { "Primitives" }, panel.FindAll(".groupName").Select(name => name.TextContent.Trim()));
        Assert.Equal(new[] { "WriteLine" }, panel.FindAll(".items li").Select(item => item.TextContent.Trim()));
        //A group the search keeps is shown open, so what matched is visible without another click.
        Assert.DoesNotContain("collapse", panel.Find(".items").ClassName);
    }

    [Fact]
    public void ClearingTheSearchBringsEveryGroupBack() {
        using var context = new BunitContext();
        using var service = new Service(new BlazorDiagram(), () => { });

        var panel = renderPanel(context, service, groups());
        panel.Find("input[aria-label=\"Search activities\"]").Change("write");
        panel.Find("button[aria-label=\"Clear the search\"]").Click();

        Assert.Equal(new[] { "Control Flow", "Primitives" },
            panel.FindAll(".groupName").Select(name => name.TextContent.Trim()));
        Assert.Equal(3, panel.FindAll(".items li").Count);
    }

    /// <summary>A search that matches nothing leaves the panel empty rather than showing every activity again.</summary>
    [Fact]
    public void ASearchWithoutAMatchDrawsNoGroup() {
        using var context = new BunitContext();
        using var service = new Service(new BlazorDiagram(), () => { });

        var panel = renderPanel(context, service, groups());
        panel.Find("input[aria-label=\"Search activities\"]").Change("nothing matches this");

        Assert.Empty(panel.FindAll(".groupName"));
        Assert.Empty(panel.FindAll(".items li"));
    }

    /// <summary>The header of the panel collapses it, by click or by the keys a button answers to.</summary>
    [Theory]
    [InlineData(null)]
    [InlineData("Enter")]
    [InlineData(" ")]
    public void TheHeaderCollapsesThePanel(string? key) {
        using var context = new BunitContext();
        using var service = new Service(new BlazorDiagram(), () => { });
        bool? collapsed = null;

        var panel = renderPanel(context, service, groups(), onCollapsed: value => collapsed = value);
        var header = panel.Find(".we-panel-header");
        if (key == null)
            header.Click();
        else
            header.KeyDown(new KeyboardEventArgs { Key = key });

        Assert.True(collapsed);
    }

    /// <summary>A collapsed panel is the rail that opens it again, and it draws none of the activities.</summary>
    [Fact]
    public void TheRailOfACollapsedPanelOpensItAgain() {
        using var context = new BunitContext();
        using var service = new Service(new BlazorDiagram(), () => { });
        bool? collapsed = null;

        var panel = renderPanel(context, service, groups(), collapsed: true, onCollapsed: value => collapsed = value);

        Assert.Empty(panel.FindAll(".items li"));
        panel.Find(".we-panel-rail").Click();

        Assert.False(collapsed);
    }
}
