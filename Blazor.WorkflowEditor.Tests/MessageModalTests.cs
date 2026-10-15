using Blazor.WorkflowEditor.Components.Modals;
using Bunit;

namespace Blazor.WorkflowEditor.Tests;

/// <summary>
/// The dialog the page tells the user something with. A validation run hands it the messages of the run, so the
/// dialog is where a workflow's errors and warnings are read one by one.
/// </summary>
public class MessageModalTests {
    [Fact]
    public void ListsEveryMessageUnderTheLineThatIntroducesThem() {
        using var context = new BunitContext();
        var messages = new List<string> { "Error: Exception: not supplied", "Warning: unused variable" };

        var dialog = context.Render<MessageModal>(parameters => parameters
            .Add(component => component.Title, "Validation")
            .Add(component => component.Message, "Validation found 1 error and 1 warning.")
            .Add(component => component.Issues, messages));

        //Show() completes when the dialog is closed, so the render is what the test waits on, not the task.
        _ = dialog.InvokeAsync(() => dialog.Instance.Show());

        Assert.Equal("Validation", dialog.Find(".modal-header").TextContent.Trim());
        Assert.Equal("Validation found 1 error and 1 warning.", dialog.Find(".modal-body p").TextContent);
        Assert.Equal(messages, dialog.FindAll(".we-message-list li").Select(item => item.TextContent));
    }

    [Fact]
    public void ShowsTheLineAloneWhenThereIsNothingToList() {
        using var context = new BunitContext();
        var dialog = context.Render<MessageModal>(parameters => parameters
            .Add(component => component.Message, "The workflow is valid."));

        _ = dialog.InvokeAsync(() => dialog.Instance.Show());

        Assert.Empty(dialog.FindAll(".we-message-list"));
        Assert.Equal("The workflow is valid.", dialog.Find(".modal-body p").TextContent);
    }
}
