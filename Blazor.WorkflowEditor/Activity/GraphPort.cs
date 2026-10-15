using Blazor.Diagrams.Core.Models;
using Blazor.Diagrams.Core.Models.Base;

namespace Blazor.WorkflowEditor.Activity;

/// <summary>
/// Connection point of a graph node (Flowchart, StateMachine). Every edge of a card carries one and all of them
/// work the same way: a connection is started from one and dropped on another, and the card the drag started
/// from is the source of the connection, so no edge is reserved for one direction of a link.
/// <para>
/// A side of a card carries several points, so the connections that leave through it do not cover each other:
/// <see cref="Slot"/> says where on the side the point sits, as a fraction of its length.
/// </para>
/// <para>
/// A point refuses only what the base model refuses as well: a locked point, the point itself, and any point of
/// the card it belongs to — an activity does not run into itself, so a card is never connected to itself.
/// </para>
/// </summary>
public class GraphPort : PortModel {
    public GraphPort(NodeModel parent, PortAlignment alignment, double slot = 0.5) : base(parent, alignment) {
        Slot = slot;
    }

    /// <summary>Place of the point along its edge, as a fraction of the length of that edge.</summary>
    public double Slot { get; }
}
