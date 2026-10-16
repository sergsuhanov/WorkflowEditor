using System.Activities;
using System.Activities.Statements;
using Blazor.Diagrams;
using Bunit;

namespace Blazor.WorkflowEditor.Tests;

/// <summary>
/// The panel that lists the variables of the scopes the user opened. A variable belongs to a scope, so the
/// panel says which activity owns every group, which of them a new variable lands in, and why there is nothing
/// to add to when no scope of the path holds variables.
/// </summary>
public class VariablesPanelComponentTests {
    private static IRenderedComponent<Components.VariablesPanelComponent> renderPanel(
        BunitContext context,
        Service service) =>
        context.Render<Components.VariablesPanelComponent>(parameters => parameters
            .Add(component => component.Service, service)
            .Add(component => component.TypeCollection, new List<Type> { typeof(int), typeof(string) }));

    /// <summary>
    /// A workflow of two Sequences, the second one a child of the first, with both surfaces opened: the panel
    /// then lists one group per scope, the outer one first.
    /// </summary>
    private static Service openTwoSequences(Sequence outer, Sequence inner) {
        outer.Activities.Add(inner);
        var service = new Service(new BlazorDiagram(), () => { });
        service.SetActivityBuilder(new ActivityBuilder { Implementation = outer });
        service.Open(service.FindPair(outer)!.Node);
        service.Open(service.FindPair(inner)!.Node);

        service.AddVariable(outer, "counter", typeof(int), "1");
        service.AddVariable(inner, "total", typeof(int), "2");
        service.RefreshVariables();
        return service;
    }

    /// <summary>The scope of a group is named by the kind of activity that holds it, not only by the display
    /// name two scopes of the same kind share; the scope a new variable lands in is marked as well.</summary>
    [Fact]
    public void NamesTheScopeOfEveryGroupAndMarksTheOneTheAddCommandFills() {
        using var context = new BunitContext();
        var outer = new Sequence { DisplayName = "Prepare" };
        var inner = new Sequence { DisplayName = "Loop" };
        using var service = openTwoSequences(outer, inner);

        var panel = renderPanel(context, service);

        Assert.Equal(new[] { "Prepare", "Loop" },
            panel.FindAll(".we-variable-group-header .we-panel-title").Select(title => title.TextContent.Trim()));
        Assert.Equal(new[] { "Sequence", "Sequence" },
            panel.FindAll(".we-variable-group-kind").Select(kind => kind.TextContent.Trim()));

        var marked = Assert.Single(panel.FindAll(".we-variable-group-header.is-add-scope"));
        Assert.Equal("Loop", marked.QuerySelector(".we-panel-title")!.TextContent.Trim());
        Assert.Contains("The add command above fills this scope.", marked.GetAttribute("title"));

        //The add command says where the variable it adds goes.
        Assert.Equal("Add a variable to Loop (Sequence)", panel.Find(".we-panel-action").GetAttribute("aria-label"));
    }

    /// <summary>The add command fills the scope it names: a branch surface holds no variables of its own, so the
    /// variable goes to the nearest scope of the path that holds them.</summary>
    [Fact]
    public void TheAddCommandFillsTheScopeItNames() {
        using var context = new BunitContext();
        var outer = new Sequence { DisplayName = "Prepare" };
        var inner = new Sequence { DisplayName = "Loop" };
        using var service = openTwoSequences(outer, inner);

        var panel = renderPanel(context, service);
        panel.Find(".we-panel-action").Click();

        Assert.Equal(new[] { "counter" }, outer.Variables.Select(variable => variable.Name));
        Assert.Equal(new[] { "total", "variable1" }, inner.Variables.Select(variable => variable.Name));

        var grids = panel.FindAll(".we-variables-grid");
        Assert.Equal(2, grids.Count);
        Assert.Equal(2, grids[1].QuerySelectorAll(".we-variable-row").Length);
    }

    /// <summary>
    /// A scope of many variables is read in the space the panel has: the rows of a scope form one grid, which
    /// flows into as many columns as the width of the panel allows, the header of each scope says how many
    /// variables it holds (also while it is collapsed), and a row keeps the four controls of a variable in the
    /// order they are read and tabbed through.
    /// </summary>
    [Fact]
    public void TheRowsOfAScopeFormOneGridAndTheHeaderSaysHowManyAreThere() {
        using var context = new BunitContext();
        var outer = new Sequence { DisplayName = "Prepare" };
        var inner = new Sequence { DisplayName = "Loop" };
        using var service = openTwoSequences(outer, inner);

        var panel = renderPanel(context, service);
        panel.Find(".we-panel-action").Click();

        Assert.Equal(new[] { "1", "2" },
            panel.FindAll(".we-variable-group-count").Select(count => count.TextContent.Trim()));
        Assert.Contains("1 variable.", panel.FindAll(".we-variable-group-header")[0].GetAttribute("aria-label"));
        Assert.Contains("2 variables.", panel.FindAll(".we-variable-group-header")[1].GetAttribute("aria-label"));

        var grid = panel.FindAll(".we-variables-grid")[1];
        var rows = grid.QuerySelectorAll(".we-variable-row");
        Assert.Equal(2, rows.Length);

        //The four controls of a row are read and tabbed through in the order they are named for the screen
        //reader: the name, the type it is changed through, the default value and the delete command.
        Assert.Equal(new[] { "we-variable-name", "we-variable-type", "we-variable-value", "we-variable-actions" },
            rows[0].QuerySelectorAll("input, button")
                .Select(control => control.ClassList.First(name => name.StartsWith("we-variable", StringComparison.Ordinal))));
    }

    /// <summary>A workflow whose path holds no scope that keeps variables says why the add command is
    /// unavailable instead of leaving a button that changes nothing.</summary>
    [Fact]
    public void AWorkflowWithoutAScopeSaysWhyThereIsNothingToAddTo() {
        using var context = new BunitContext();
        using var service = new Service(new BlazorDiagram(), () => { });
        service.SetActivityBuilder(new ActivityBuilder { Implementation = new If() });

        var panel = renderPanel(context, service);

        Assert.True(panel.Find(".we-panel-action").HasAttribute("disabled"));
        Assert.Empty(panel.FindAll(".we-variable-group"));
        Assert.Contains("No scope here holds variables", panel.Find(".we-variables-hint").TextContent);
        Assert.Equal("Add a variable", panel.Find(".we-panel-action").GetAttribute("aria-label"));
    }

    /// <summary>Two scopes of the same kind carry the same display name, so the state of a collapsed group
    /// belongs to the scope and not to the name.</summary>
    [Fact]
    public void CollapsingOneScopeLeavesAnotherOfTheSameKindOpen() {
        using var context = new BunitContext();
        var outer = new Sequence();
        var inner = new Sequence();
        using var service = openTwoSequences(outer, inner);

        var panel = renderPanel(context, service);
        Assert.Equal(2, panel.FindAll(".we-variables-grid").Count);

        panel.FindAll(".we-variable-group-header")[0].Click();

        Assert.Single(panel.FindAll(".we-variables-grid"));
        Assert.Equal(new[] { "false", "true" },
            panel.FindAll(".we-variable-group-header").Select(header => header.GetAttribute("aria-expanded")));
    }

    /// <summary>The panel lists the variables of every scope the user opened, and the root group keeps the
    /// variables of the workflow until its implementation surface is opened itself.</summary>
    [Fact]
    public void ListsTheVariablesOfTheOpenedScopesUnderTheirOwnScope() {
        using var context = new BunitContext();
        var sequence = new Sequence { DisplayName = "Workflow body" };
        using var service = new Service(new BlazorDiagram(), () => { });
        service.SetActivityBuilder(new ActivityBuilder { Implementation = sequence });
        service.AddVariable(service.VariableScope!.Element, "counter", typeof(int), "1");
        service.RefreshVariables();

        var panel = renderPanel(context, service);

        //The root surface holds the variables of its implementation, so the group carries the name of the
        //workflow root and the kind of the wrapper the editor shows for it.
        Assert.Equal("ActivityBuilder",
            Assert.Single(panel.FindAll(".we-variable-group-header .we-panel-title")).TextContent.Trim());
        Assert.Equal("ActivityBuilder",
            Assert.Single(panel.FindAll(".we-variable-group-kind")).TextContent.Trim());
        Assert.Equal("counter",
            Assert.Single(panel.FindAll("input.we-variable-name")).GetAttribute("value"));
    }
}
