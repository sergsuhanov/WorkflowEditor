using Blazor.Diagrams.Core.Models;

namespace Blazor.WorkflowEditor.Activity;

/// <summary>
/// Container whose child elements are connected as a graph (Flowchart, StateMachine).
/// Child elements are addressed by index so that forms can pick link targets, and connections
/// drawn on the diagram are translated into the workflow model.
/// </summary>
public interface IGraphContainer {
    int Count { get; }
    string LabelAt(int index);

    /// <summary>
    /// Connects two child elements in the workflow model. Returns false when the connection is not allowed.
    /// <paramref name="source"/> is the edge of the source card the user drew from: an element that keeps
    /// several outgoing branches (a `FlowDecision`, a `FlowSwitch`) uses it to name the branch the drawn
    /// connection replaces, so re-drawing a connection moves it instead of adding one more.
    /// </summary>
    bool TryConnect(ActivityDesignerPair from, ActivityDesignerPair to, PortAlignment source);

    /// <summary>Removes the connection between two child elements in the workflow model.</summary>
    bool TryDisconnect(ActivityDesignerPair from, ActivityDesignerPair to);

    /// <summary>Rebuilds the diagram links from the workflow model.</summary>
    void Refresh();

    /// <summary>
    /// Draws the connections of the canvas again from the workflow model, leaving the model untouched: it puts a
    /// connection back after a drag the container refused, without reporting a change of the workflow.
    /// </summary>
    void RebuildLinks();

    /// <summary>Short label of a connection (True/False, switch case, transition trigger) or null.</summary>
    string? LinkLabel(ActivityDesignerPair from, ActivityDesignerPair to);
}
