using System.Activities.Statements;
using Blazor.Diagrams.Core.Geometry;

namespace Blazor.WorkflowEditor.Activity.Stack.ControlFlow;

[Pair(typeof(System.Activities.Statements.Sequence), typeof(SequenceControl))]
public class SequenceNode : DefaultNode, IStackContainer {
    /// <summary>Vertical room the column leaves between two cards, so a grown card does not touch the next.</summary>
    public const double CardGap = 28;

    private readonly Sequence sequenceActivity;

    /// <summary>
    /// Place of the column: taken from the viewport when the container is opened and kept afterwards, because
    /// panning the diagram or resizing a panel must not move the cards of an opened container.
    /// </summary>
    private double? columnTop;
    private double? columnCenterX;

    public SequenceNode(Service service, System.Activities.Statements.Sequence sequenceActivity) : base(service, sequenceActivity) {
        this.sequenceActivity = sequenceActivity;
        this.IsContainer = true;

        //The card draws the list of its children unless the user collapses it with the chevron of the card.
        this.IsExpanded = true;
    }

    public override IEnumerable<Variable> GetVariables() {
        return GetVariables(sequenceActivity.Variables);
    }

    /// <summary>An empty sequence has nothing on its canvas, so it asks for the first activity.</summary>
    public override string? EmptyHint =>
        sequenceActivity.Activities.Count == 0 ? "Drop the first activity here" : null;

    public int Count => sequenceActivity.Activities.Count;

    /// <summary>
    /// The children of the sequence are drawn inside its card, one under another in model order, so the whole
    /// sequence is edited in place. Opening the container shows the same children on a surface of their own.
    /// </summary>
    public override IReadOnlyList<object> InlineChildren => sequenceActivity.Activities;

    /// <summary>A sequence card holds a list of cards, so it uses the wider card layout.</summary>
    public override string NodeLayoutClass => "we-node-wide";

    public override void LoadChilds(Func<System.Activities.Activity, ActivityDesignerPair> addActivity) {
        foreach (var activity in this.sequenceActivity.Activities) {
            var result = addActivity(activity);

            //A child of the column takes its place from its index: it has no ports, no connections and no
            //position of its own to keep.
            result.Node.IsStackChild = true;
        }

        LayoutChildren();
    }

    public override void RelayoutChildren() => LayoutChildren();

    public int IndexOf(object element) {
        for (var index = 0; index < sequenceActivity.Activities.Count; index++) {
            if (ReferenceEquals(sequenceActivity.Activities[index], element))
                return index;
        }

        return -1;
    }

    public void InsertChild(int index, ActivityDesignerPair child) {
        var position = Math.Clamp(index, 0, sequenceActivity.Activities.Count);
        child.Node.IsStackChild = true;
        sequenceActivity.Activities.Insert(position, child.Activity);
        LayoutChildren();
        service.NotifyStateChanged();
    }

    public void MoveChild(int from, int to) {
        if (from < 0 || from >= sequenceActivity.Activities.Count)
            return;

        var position = Math.Clamp(to, 0, sequenceActivity.Activities.Count - 1);
        if (from == position)
            return;

        var activity = sequenceActivity.Activities[from];
        sequenceActivity.Activities.RemoveAt(from);
        sequenceActivity.Activities.Insert(position, activity);
        LayoutChildren();
        service.NotifyStateChanged();
    }

    /// <summary>
    /// Lays the children out in a column, in model order, using the height the browser measured for each card
    /// so a tall card does not overlap the next one. The place of the column is taken once, when the container
    /// is opened and its cards are measured; a later pan, zoom or resize leaves the column where it is.
    /// </summary>
    public void LayoutChildren() {
        if (service.VisibleViewport is { } viewport) {
            //The column starts below the start cue an empty container draws at the top of its surface, which is
            //where its first element has to appear (the cue box sits between 72 and 130 pixels of the surface).
            columnTop ??= viewport.Top + 72;
            columnCenterX ??= viewport.Left + viewport.Width / 2;
        }

        var centerX = columnCenterX ?? 160;
        var y = columnTop ?? 0;

        foreach (var activity in this.sequenceActivity.Activities) {
            if (service.FindPair(activity)?.Node is not { } node)
                continue;

            var height = node.Size?.Height ?? 0;
            y += height / 2;

            var center = new Point(centerX, y);
            if (center.DistanceTo(node.CenterPosition) > 0.5)
                node.CenterPosition = center;

            y += height / 2 + CardGap;
        }
    }

    public override void AddChild(ActivityDesignerPair child) => InsertChild(Count, child);

    public override void RemoveChild(System.Activities.Activity child) {
        sequenceActivity.Activities.Remove(child);
        LayoutChildren();
    }
}
