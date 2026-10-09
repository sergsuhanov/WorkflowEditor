namespace Blazor.WorkflowEditor.Activity;

/// <summary>
/// Container whose child elements are connected as a graph (Flowchart, StateMachine).
/// Child elements are addressed by index so that forms can pick link targets, and connections
/// drawn on the diagram are translated into the workflow model.
/// </summary>
public interface IGraphContainer {
    int Count { get; }
    string LabelAt(int index);

    /// <summary>Connects two child elements in the workflow model. Returns false when the connection is not allowed.</summary>
    bool TryConnect(ActivityDesignerPair from, ActivityDesignerPair to);

    /// <summary>Removes the connection between two child elements in the workflow model.</summary>
    bool TryDisconnect(ActivityDesignerPair from, ActivityDesignerPair to);

    /// <summary>Rebuilds the diagram links from the workflow model.</summary>
    void Refresh();

    /// <summary>Short label of a connection (True/False, switch case, transition trigger) or null.</summary>
    string? LinkLabel(ActivityDesignerPair from, ActivityDesignerPair to);
}
