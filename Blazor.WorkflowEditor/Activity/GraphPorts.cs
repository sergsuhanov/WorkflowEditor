using Blazor.Diagrams.Core.Models;
using Blazor.Diagrams.Core.Models.Base;

namespace Blazor.WorkflowEditor.Activity;

/// <summary>
/// Incoming port of a graph node (Flowchart, StateMachine). It only accepts connections: a link can
/// never be drawn starting from this port.
/// </summary>
public class GraphInPort : PortModel {
    public GraphInPort(NodeModel parent, PortAlignment alignment) : base(parent, alignment) { }

    /// <summary>An incoming port is never a valid source, so <see cref="PortModel.CanAttachTo"/> is always false.</summary>
    public override bool CanAttachTo(ILinkable other) => false;
}

/// <summary>
/// Outgoing port of a graph node. Connections are drawn from here and may only target a
/// <see cref="GraphInPort"/>, which validates the connection direction.
/// </summary>
public class GraphOutPort : PortModel {
    public GraphOutPort(NodeModel parent, PortAlignment alignment) : base(parent, alignment) { }

    public override bool CanAttachTo(ILinkable other) =>
        base.CanAttachTo(other) && other is GraphInPort;
}
