using System.Activities;
using System.Collections.ObjectModel;
using System.Reflection;
using Blazor.Diagrams;
using Blazor.Diagrams.Core;
using Blazor.Diagrams.Core.Anchors;
using Blazor.Diagrams.Core.Behaviors;
using Blazor.Diagrams.Core.Controls;
using Blazor.Diagrams.Core.Controls.Default;
using Blazor.Diagrams.Core.Geometry;
using Blazor.Diagrams.Core.Models;
using Blazor.Diagrams.Core.Models.Base;
using Blazor.Diagrams.Core.Positions;
using Blazor.WorkflowEditor.Activity;
using Blazor.WorkflowEditor.Activity.Flow;
using Microsoft.AspNetCore.Components.Web;

namespace Blazor.WorkflowEditor {
    /// <summary>
    /// The graph surfaces themselves: the start node a `Flowchart` chooses through its badge, the band a route
    /// is laid out in, and what the surface reports about its geometry.
    /// </summary>
    public partial class Service {
        /// <summary>
        /// What the current canvas asks for, or null when it asks for nothing: every surface but a Flowchart is
        /// started by its first element, so it asks for that element only while it holds none, and a Flowchart
        /// asks for its start node until one is chosen.
        /// </summary>
        public string? StartHint {
            get {
                if (IsRootCanvas)
                    return activityBuilder?.Implementation == null ? "Drop the first activity here" : null;

                if (Path.LastOrDefault()?.Reference?.Node is not { } container)
                    return "Drop the first activity here";

                //A container that holds nothing asks for its first element exactly like the empty root does; a
                //Flowchart also asks for the start node while it is not chosen yet, and the START badge of the
                //canvas is what re-binds it.
                return container switch {
                    FlowchartNode { Count: 0 } => "Add a node to create the flowchart start",
                    FlowchartNode flowchart => flowchart.StartElement == null ? "Drag START onto the node that runs first" : null,
                    _ => container.EmptyHint
                };
            }
        }

        /// <summary>
        /// Card that carries the start badge of the opened container, or null when the surface marks no start
        /// element. Only a Flowchart does: its start node is a choice of the user, while every other surface —
        /// the root, a `Sequence`, a `StateMachine` — is started by its first element and needs no mark.
        /// </summary>
        public DefaultNode? StartBadgeNode {
            get {
                if (Path.LastOrDefault()?.Reference?.Node is not FlowchartNode flowchart
                    || flowchart.StartElement is not { } element)
                    return null;

                return items.FirstOrDefault(p => ReferenceEquals(p.Element, element))?.Node;
            }
        }

        /// <summary>
        /// Takes the START badge of the opened Flowchart: the next card the drag points at becomes the start
        /// node, so the first activity of the flowchart is re-bound without leaving the canvas.
        /// </summary>
        public void BeginStartRebind() {
            if (OpenedGraph is not FlowchartNode)
                return;

            IsRebindingStart = true;
            StartDropTarget = null;
            updateState();
        }

        /// <summary>Card the START drag currently points at; null clears the highlight.</summary>
        public void HoverStartTarget(DefaultNode? node) {
            if (!IsRebindingStart || ReferenceEquals(StartDropTarget, node))
                return;

            StartDropTarget = node;
            updateState();
        }

        /// <summary>Ends the START drag, whether or not the badge was dropped on a card.</summary>
        public void EndStartRebind() {
            if (!IsRebindingStart && StartDropTarget == null)
                return;

            IsRebindingStart = false;
            StartDropTarget = null;
            updateState();
        }

        /// <summary>
        /// Makes the card the START badge was dropped on the start of the opened Flowchart. Returns false when
        /// no drag was running or the card is not a node of that flowchart (or already starts it).
        /// </summary>
        public bool RebindStart(DefaultNode node) {
            var flowchart = IsRebindingStart ? OpenedGraph as FlowchartNode : null;
            if (flowchart == null) {
                EndStartRebind();
                return false;
            }

            IsRebindingStart = false;
            StartDropTarget = null;

            //Setting the start notifies the view, which also drops the highlight; the same card leaves it to a
            //plain refresh.
            var changed = flowchart.SetStartElement(node.Element);
            if (!changed)
                updateState();

            return changed;
        }

        /// <summary>
        /// Recomputes the port rectangles and the link routes of every displayed node. Ports are placed from
        /// the node box (see <see cref="DefaultNode.UpdatePortGeometry"/>) instead of the DOM measurement of
        /// the library, so a node that was moved, expanded or resized keeps its links attached.
        /// </summary>
        public void RefreshPortGeometry() {
            portGeometryDirty = false;

            foreach (var item in items.Where(i => i.Node != null)) {
                //A card of the column of an ordered container has no ports and no connections to refresh.
                if (item.Node.IsStackChild || !IsDisplayed(item.Node))
                    continue;

                item.Node.UpdatePortGeometry();
            }

            foreach (var item in items.Where(i => i.Node != null)) {
                if (!item.Node.IsStackChild)
                    item.Node.RefreshLinks();
            }

            //A card that grew (an expanded node, a branch holding an activity) is laid out again so it does not
            //overlap the next one; the layout only moves nodes it placed itself.
            Path.LastOrDefault()?.Reference?.Node.RelayoutChildren();

            updateState();
        }

        private void onContainerChanged() {
            CompletePendingInitialLayout();
            requestPortGeometryRefresh();
        }

        /// <summary>Re-measures the ports and rebuilds the link routes after the node card changed its size.</summary>
        private void onNodeSizeChanged(NodeModel model) {
            if (model is not DefaultNode)
                return;

            requestPortGeometryRefresh();
        }

        /// <summary>The graph container currently opened in the editor, if any (Flowchart, StateMachine).</summary>
        private IGraphContainer? currentGraphContainer => Path.LastOrDefault()?.Reference?.Node as IGraphContainer;

    }
}
