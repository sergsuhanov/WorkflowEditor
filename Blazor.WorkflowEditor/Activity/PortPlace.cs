using System.Globalization;
using Blazor.Diagrams.Core.Models;

namespace Blazor.WorkflowEditor.Activity;

/// <summary>
/// Place of a connection end on a card: the edge it sits on and where on that edge it lies, as a fraction of the
/// length of that edge. A card offers several points per edge, so the edge alone does not say which of them a
/// connection was put on.
/// </summary>
public readonly record struct PortPlace(PortAlignment Edge, double Slot) {
    /// <summary>Place of the point of a card a connection end is anchored on.</summary>
    public static PortPlace Of(PortModel port) =>
        new(port.Alignment, port is GraphPort graph ? graph.Slot : Middle);

    /// <summary>Place in the middle of an edge, which is the only point a card without spread points offers.</summary>
    public const double Middle = 0.5;

    /// <summary>Whether the given point of a card is the point at this place.</summary>
    public bool IsOn(PortModel port) =>
        port.Alignment == Edge && Math.Abs(Of(port).Slot - Slot) < 0.001;

    /// <summary>Compact form the place is written in, e.g. <c>Left@0.25</c>.</summary>
    public override string ToString() =>
        $"{Edge}@{Slot.ToString("0.##", CultureInfo.InvariantCulture)}";

    /// <summary>Reads the compact form of a place, or returns null when the text is not one.</summary>
    public static PortPlace? Parse(string text) {
        var parts = text.Split('@');
        if (!Enum.TryParse<PortAlignment>(parts[0], out var edge))
            return null;

        var slot = Middle;
        if (parts.Length > 1 && !double.TryParse(parts[1], NumberStyles.Float, CultureInfo.InvariantCulture, out slot))
            return null;

        return new PortPlace(edge, slot);
    }
}
