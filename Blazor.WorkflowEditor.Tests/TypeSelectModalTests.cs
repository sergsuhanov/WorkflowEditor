using Blazor.WorkflowEditor.Components.Modals;
using Bunit;

namespace Blazor.WorkflowEditor.Tests;

/// <summary>
/// The one dialog that asks for a type: it completes the generic parameters of an activity that is dropped and
/// chooses the type of a variable. A field of an activity offers the types that meet the constraints of the
/// parameter it fills — a type the activity cannot take would make the closed activity fail to build — and the
/// dialog refuses a type that only the whole choice shows not to fill its parameter.
/// </summary>
public class TypeSelectModalTests {
    private static IRenderedComponent<TypeSelectModal> renderDialog(
        BunitContext context,
        List<Type?> types,
        params TypeSelectModal.TypeField[] fields) {
        var dialog = context.Render<TypeSelectModal>(parameters => parameters
            .Add(component => component.TypeCollection, types)
            .Add(component => component.Fields, fields.ToList()));

        //Show() completes when the dialog is closed, so the render is what the test waits on, not the task.
        _ = dialog.InvokeAsync(() => dialog.Instance.Show());
        return dialog;
    }

    private static TypeSelectModal.TypeField field(Type parameter) =>
        new() { Label = parameter.Name, Parameter = parameter };

    /// <summary>Every type the list holds is offered when the field asks for a type nothing constrains, which is
    /// what the dialog does for the type of a variable.</summary>
    [Fact]
    public void AFieldNothingConstrainsOffersEveryTypeOfTheList() {
        using var context = new BunitContext();
        var offered = new List<Type?> { typeof(string), typeof(int), typeof(List<>) };

        var dialog = renderDialog(context, offered, new TypeSelectModal.TypeField());

        Assert.Equal(offered.Select(type => type!.ToString()),
            dialog.FindAll(".option-text").Select(option => option.TextContent.Trim()));
    }

    /// <summary>The picker of a field offers the types that meet the constraints of the parameter the field
    /// fills, so a type that the activity could not be completed with is never chosen.</summary>
    [Fact]
    public void AFieldOfAnActivityOffersTheTypesItsParameterAccepts() {
        using var context = new BunitContext();
        var offered = new List<Type?> { typeof(string), typeof(int), typeof(List<>), typeof(bool) };

        var dialog = renderDialog(context, offered,
            field(TestGenerics.Parameter(typeof(TestGenerics.ValueOnly<>))));

        Assert.Equal(new[] { typeof(int), typeof(bool) }.Select(type => type.ToString()),
            dialog.FindAll(".option-text").Select(option => option.TextContent.Trim()));
    }

    /// <summary>A type that is put together in the dialog is judged on the whole type: `List&lt;int&gt;` fills a
    /// parameter that takes any type, but not one that only takes a list of text, and the dialog says so with the
    /// parameter it does not fill instead of letting the drop fail.</summary>
    [Fact]
    public void ATypeTheWholeChoiceShowsNotToFillTheParameterIsRefused() {
        using var context = new BunitContext();
        var offered = new List<Type?> { typeof(List<>), typeof(int), typeof(string) };

        var dialog = renderDialog(context, offered,
            field(TestGenerics.Parameter(typeof(TestGenerics.TextOnly<>))));

        //Only the type that is still open is offered: it is the one that can still become a list of text.
        Assert.Equal(new[] { typeof(List<>) }.Select(type => type.ToString()),
            dialog.FindAll(".option-text").Select(option => option.TextContent.Trim()));

        //The element of the list is the field of the list itself, which takes any type.
        dialog.FindAll("li.option").First(option => option.TextContent.Contains("List", StringComparison.Ordinal)).Click();
        dialog.Find(".we-vtc-options a").Click();
        dialog.FindAll("li.option").First(option => option.TextContent.Trim() == typeof(int).ToString()).Click();

        dialog.Find("button.btn-primary").Click();

        var error = dialog.Find(".alert").TextContent;
        Assert.Contains(typeof(List<int>).ToString()!, error);
        Assert.Contains("does not meet the constraints of T", error);
        Assert.Contains($"it has to be a type assignable to {typeof(IEnumerable<string>)}", error);
    }

    /// <summary>A complete choice that fills its parameter is applied, and the dialog hands the types over.</summary>
    [Fact]
    public void AChoiceThatFillsEveryParameterIsApplied() {
        using var context = new BunitContext();
        var offered = new List<Type?> { typeof(List<>), typeof(int), typeof(string) };

        var dialog = renderDialog(context, offered,
            field(TestGenerics.Parameter(typeof(TestGenerics.TextOnly<>))));

        dialog.FindAll("li.option").First(option => option.TextContent.Contains("List", StringComparison.Ordinal)).Click();
        dialog.Find(".we-vtc-options a").Click();
        dialog.FindAll("li.option").First(option => option.TextContent.Trim() == typeof(string).ToString()).Click();

        dialog.Find("button.btn-primary").Click();

        Assert.Empty(dialog.FindAll(".alert"));
        Assert.Equal(new[] { typeof(List<string>) }, dialog.Instance.BuildedTypes);
    }

    /// <summary>The dialog keeps asking until every field has a type, and says what is missing meanwhile.</summary>
    [Fact]
    public void AFieldLeftEmptyIsRefusedWithTheMessageThatAsksForAType() {
        using var context = new BunitContext();
        var offered = new List<Type?> { typeof(int), typeof(string) };

        var dialog = renderDialog(context, offered, new TypeSelectModal.TypeField());

        dialog.Find("button.btn-primary").Click();

        Assert.Equal("Select a type.", dialog.Find(".alert").TextContent);
    }
}
