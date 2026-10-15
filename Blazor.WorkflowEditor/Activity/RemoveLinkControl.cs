using Blazor.Diagrams.Core;
using Blazor.Diagrams.Core.Controls;
using Blazor.Diagrams.Core.Events;
using Blazor.Diagrams.Core.Geometry;
using Blazor.Diagrams.Core.Models;
using Blazor.Diagrams.Core.Models.Base;
using Blazor.Diagrams.Core.Positions;

namespace Blazor.WorkflowEditor.Activity;

/// <summary>
/// Command of a connection that removes it. It is drawn on the line at the middle of its route and its element is
/// as small as the disc it shows, so the pointer that comes along the line reaches the ends of the connection
/// beside it instead of the command.
/// </summary>
public class RemoveLinkControl : ExecutableControl {
    private readonly IPositionProvider positionProvider;

    public RemoveLinkControl(IPositionProvider positionProvider) => this.positionProvider = positionProvider;

    public override Point? GetPosition(Model model) => positionProvider.GetPosition(model);

    public override async ValueTask OnPointerDown(Diagram diagram, Model model, PointerEventArgs e) {
        if (model is not LinkModel link || link.Locked)
            return;

        if (await diagram.Options.Constraints.ShouldDeleteLink(link))
            diagram.Links.Remove(link);
    }
}
