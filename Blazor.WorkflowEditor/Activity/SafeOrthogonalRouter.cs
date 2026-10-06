using Blazor.Diagrams.Core;
using Blazor.Diagrams.Core.Geometry;
using Blazor.Diagrams.Core.Models.Base;
using Blazor.Diagrams.Core.Routers;

namespace Blazor.WorkflowEditor.Activity;

/// <summary>
/// Workflow Foundation style router: right-angled routes with rounded corners.
/// <para>
/// The stock <see cref="OrthogonalRouter"/> throws <see cref="NotImplementedException"/> as soon as a link
/// is anchored on a port alignment it does not know (the corner alignments TopRight/BottomRight/...).
/// Since the route is generated while the user drags a new connection, that would take the whole editor
/// down, so the fallback (straight line) router is used instead of propagating the exception.
/// </para>
/// </summary>
public class SafeOrthogonalRouter : Router {
    private readonly OrthogonalRouter orthogonal = new();
    private readonly NormalRouter straight = new();

    public override Point[] GetRoute(Diagram diagram, BaseLinkModel link) {
        try {
            return orthogonal.GetRoute(diagram, link);
        } catch (NotImplementedException) {
            return straight.GetRoute(diagram, link);
        }
    }
}
