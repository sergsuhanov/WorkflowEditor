using Blazor.WorkflowEditor;

namespace Blazor.WorkflowEditor.Tests;

/// <summary>
/// The name the editor shows a type under. The user chooses a type in the dialog that completes an activity or
/// that sets the type of a variable, and reads it again on the card or in the row of the variable: the CLR name
/// of a generic type definition is for a developer and belongs in a tooltip.
/// </summary>
public class ExtensionsTests {
    [Theory]
    [InlineData(typeof(int), "Int32")]
    [InlineData(typeof(string), "String")]
    [InlineData(typeof(int[]), "Int32[]")]
    [InlineData(typeof(List<int>), "List<Int32>")]
    [InlineData(typeof(List<>), "List<T>")]
    [InlineData(typeof(Nullable<int>), "Nullable<Int32>")]
    [InlineData(typeof(Dictionary<string, List<int>>), "Dictionary<String, List<Int32>>")]
    public void ATypeIsNamedTheWayItIsShown(Type type, string expected) =>
        Assert.Equal(expected, type.DisplayName());

    [Fact]
    public void ATypeThatIsNotThereHasNoName() =>
        Assert.Equal(string.Empty, ((Type?)null).DisplayName());
}
