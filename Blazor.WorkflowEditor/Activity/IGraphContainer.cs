namespace Blazor.WorkflowEditor.Activity;

/// <summary>
/// Container whose child elements are connected as a graph (Flowchart, StateMachine).
/// Child elements are addressed by index so that forms can pick link targets.
/// </summary>
public interface IGraphContainer {
    int Count { get; }
    string LabelAt(int index);
}
