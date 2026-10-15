using System.Activities;
using System.Activities.Statements;
using Bunit;

namespace Blazor.WorkflowEditor.Tests;

/// <summary>
/// The editor component a page hosts: what it draws for a workflow that has no root activity yet, and what it
/// reports about the schema it holds. The browser is faked, so nothing is measured from the DOM — these tests
/// cover what the component decides, not what the browser paints.
/// </summary>
public class EditorComponentTests {
    private static BunitContext newContext() {
        var context = new BunitContext();
        context.JSInterop.Mode = JSRuntimeMode.Loose;
        //The component watches the viewport through a module of its own, which has no browser behind it here.
        context.JSInterop.SetupModule("./_content/Blazor.WorkflowEditor/panelLayout.js");
        //A diagram asks the browser for the rectangle of its canvas, which decides where a card lands.
        context.JSInterop
            .Setup<Diagrams.Core.Geometry.Rectangle>("ZBlazorDiagrams.getBoundingClientRect", _ => true)
            .SetResult(new Diagrams.Core.Geometry.Rectangle(
                new Diagrams.Core.Geometry.Point(0, 0), new Diagrams.Core.Geometry.Size(1200, 800)));
        return context;
    }

    private static List<ToolBoxGroup> toolboxGroups() {
        var primitives = new ToolBoxGroup { Name = "Primitives" };
        primitives.Add(typeof(WriteLine));
        primitives.Add(typeof(Delay));
        return new List<ToolBoxGroup> { primitives };
    }

    private static IRenderedComponent<Editor> renderEditor(BunitContext context, Action<bool>? onDirty = null) =>
        context.Render<Editor>(parameters => parameters
            .Add(component => component.ToolBoxGroups, toolboxGroups())
            .Add(component => component.TypeCollection, new List<Type> { typeof(int), typeof(string) })
            .Add(component => component.DirtyChanged, value => onDirty?.Invoke(value)));

    private static string sequenceXaml() =>
        WorkflowXamlSerializer.SaveBuilder(new ActivityBuilder {
            Implementation = new Sequence {
                DisplayName = "Seq",
                Activities = { new WriteLine { Text = new InArgument<string>("one") } }
            }
        });

    /// <summary>A workflow without a root activity asks for the first one instead of showing an empty canvas.</summary>
    [Fact]
    public async Task AnEmptyWorkflowAsksForItsFirstActivity() {
        using var context = newContext();
        var editor = renderEditor(context);

        await editor.InvokeAsync(editor.Instance.New);

        Assert.Contains("Drop the first activity here", editor.Markup);
        Assert.Empty(editor.FindAll(".we-custom-node"));
    }

    /// <summary>New clears the schema and the history, so there is nothing to take back after it.</summary>
    [Fact]
    public async Task ANewWorkflowHasNothingToUndoAndNothingToSave() {
        using var context = newContext();
        var editor = renderEditor(context);

        await editor.InvokeAsync(editor.Instance.New);

        Assert.False(editor.Instance.CanUndo);
        Assert.False(editor.Instance.CanRedo);
        Assert.False(editor.Instance.HasUnsavedChanges);
    }

    /// <summary>The validation of a schema without a root activity reports nothing to the page.</summary>
    [Fact]
    public async Task ValidatingAnEmptyWorkflowReportsNoIssue() {
        using var context = newContext();
        var editor = renderEditor(context);

        await editor.InvokeAsync(editor.Instance.New);
        var report = await editor.InvokeAsync(editor.Instance.Validate);

        Assert.False(report.HasIssues);
        Assert.Empty(report.Errors);
        Assert.Empty(report.Warnings);
    }

    /// <summary>
    /// A schema that was opened is the first step of the history: it is saved, it draws its root activity, and
    /// there is nothing to take back.
    /// </summary>
    [Fact]
    public async Task AnOpenedSchemaIsTheFirstStepOfTheHistory() {
        using var context = newContext();
        var editor = renderEditor(context);

        await editor.InvokeAsync(() => editor.Instance.Load(sequenceXaml()));

        Assert.Contains("Seq", editor.Markup);
        Assert.False(editor.Instance.HasUnsavedChanges);
        Assert.False(editor.Instance.CanUndo);
        Assert.False(editor.Instance.CanRedo);
    }

    /// <summary>A draft restored from the browser is a schema with unsaved work, which the page is told about.</summary>
    [Fact]
    public async Task ARestoredDraftCountsAsUnsavedWork() {
        using var context = newContext();
        bool? dirty = null;
        var editor = renderEditor(context, value => dirty = value);

        await editor.InvokeAsync(() => editor.Instance.Load(sequenceXaml(), markAsChanged: true));

        Assert.True(editor.Instance.HasUnsavedChanges);
        Assert.True(dirty);

        await editor.InvokeAsync(editor.Instance.MarkSaved);

        Assert.False(editor.Instance.HasUnsavedChanges);
        Assert.False(dirty);
    }

    /// <summary>The editor reports a validation run that found an error, and keeps the messages of the run.</summary>
    [Fact]
    public async Task AWorkflowWithAnErrorReportsIt() {
        using var context = newContext();
        var editor = renderEditor(context);
        var xaml = WorkflowXamlSerializer.SaveBuilder(new ActivityBuilder {
            Implementation = new Sequence { Activities = { new Throw() } }
        });

        await editor.InvokeAsync(() => editor.Instance.Load(xaml));
        var report = await editor.InvokeAsync(editor.Instance.Validate);

        Assert.True(report.HasIssues);
        Assert.Contains(report.Errors, message => message.Contains("Exception"));
    }
}
