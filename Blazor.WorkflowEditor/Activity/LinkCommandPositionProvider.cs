using Blazor.Diagrams.Core.Geometry;
using Blazor.Diagrams.Core.Models.Base;
using Blazor.Diagrams.Core.Positions;

namespace Blazor.WorkflowEditor.Activity;

/// <summary>
/// Position of a command drawn on a connection: the point of its route at the middle, moved along the route by
/// the given distance, so the commands of one link sit next to each other on the line they belong to instead of
/// floating beside it, where the pointer would have left the link before reaching them.
/// </summary>
public class LinkCommandPositionProvider : IPositionProvider {
    private readonly double shift;

    /// <param name="shift">Distance along the route from its middle: a negative one moves towards its start.</param>
    public LinkCommandPositionProvider(double shift) => this.shift = shift;

    public Point? GetPosition(Model model) {
        if (model is not BaseLinkModel link || link.PathGeneratorResult is not { } result)
            return null;

        var path = result.FullPath;
        var length = path.Length;
        if (length <= 0)
            return null;

        var point = path.GetPointAtLength(Math.Clamp(length / 2 + shift, 0, length));
        return new Point(point.X, point.Y);
    }
}
