namespace WorkflowEditor.TestActivities;

/// <summary>
/// A class a workflow can carry as its data. It is the type the generic activities of this library are closed
/// over, and the one the editor offers in the dialog that asks for a type parameter of an activity.
/// </summary>
public sealed class TestInput {
    public string Name { get; set; } = "test";

    public int Amount { get; set; } = 1;

    public override string ToString() => $"{Name}: {Amount}";
}
