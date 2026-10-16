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
    /// The cards of the surface: what a drop does with an activity, how a card the user drags changes what
    /// draws it, the commands that copy one (duplicate and the clipboard), and the order of the cards a
    /// container lays out.
    /// </summary>
    public partial class Service {
        /// <summary>How far a copy of a card is put from the card it copies.</summary>
        private const double CopyOffset = 40;

        /// <summary>How far a pasted element is put from the middle of the view.</summary>
        private const double PasteOffset = 24;

        public ToolBoxItem? DraggedToolboxItem { get; set; }

        /// <summary>
        /// Node that should receive the next dropped activity (for example an If branch region).
        /// Null means the currently opened container. Cleared after the next add.
        /// </summary>
        public DefaultNode? DropTarget { get; set; }

        /// <summary>
        /// Slot that should receive the next dropped activity (the branch region of an activity that holds one
        /// Activity per branch). Cleared after the next add. Takes precedence over <see cref="DropTarget"/>.
        /// </summary>
        public IActivityHolder? DropSlot { get; set; }

        /// <summary>
        /// Index a new element takes in the column of the opened stack container (Sequence) when it is dropped
        /// at the current pointer place. Null while no stack is opened or the pointer is over another surface.
        /// Set while an activity is dragged over the canvas, so the column can show where the element lands.
        /// </summary>
        public int? DropInsertIndex { get; private set; }

        /// <summary>
        /// Card the user drags with the mouse, or null. A card can be dragged when another card draws it
        /// inside itself (a branch child, a card of an inline list) or when the opened ordered container draws
        /// it in its column; the card keeps the activity it shows and the drop only changes what draws it.
        /// </summary>
        public DefaultNode? DraggedCard { get; private set; }

        public void Delete(Activity.DefaultNode node) {
            var item = getById(node.Id);
            if (item is null)
                return;

            RemoveAllLinks(node);
            selectedLinks.RemoveAll(l => l.Item1 == item || l.Item2 == item);
            //The port a connection was drawn from is remembered per pair of cards; a card that is gone keeps
            //no such choice.
            foreach (var key in linkPlaces.Keys.Where(k => k.from == item || k.to == item).ToList())
                linkPlaces.Remove(key);

            designer.Nodes.Remove(node);

            //A branch child belongs to the card that renders it, not to the opened container.
            if (node.EmbeddedOwner is { } owner)
                owner.RemoveElement(item.Element);
            else
                Path.LastOrDefault()?.Reference?.Node?.RemoveElement(item.Element);

            removeEmbeddedDescendants(node);

            selectedItems.Remove(item);
            items.Remove(item);
            notifyModelChanged();
            updateState();
        }

        /// <summary>
        /// Adds a copy of the selected element right behind it, in the container that already holds it, and
        /// selects the copy: the card the user selected last is the one copied, and the copy takes the selection
        /// over. Nothing is added without a selection, by a place that holds a single element already — the root
        /// of the workflow, the branch of a card — or by an element whose card holds no activity of its own
        /// (a `FlowDecision`, a `FlowSwitch<T>`, a `State`).
        /// </summary>
        public bool DuplicateSelected() {
            if (selectedItems.Count == 0)
                return false;

            var (hasAdded, copy) = copyBehind(selectedItems[^1]);
            if (!hasAdded)
                return false;

            //The copy is the card the editor goes on with, so the cards selected before it are dropped.
            clearSelection();
            Select(copy.Node);
            updateState();
            return true;
        }

        /// <summary>
        /// Copies the element the selected card shows, so that it can be pasted into another container. The card
        /// selected last is the one copied, exactly like the copy command.
        /// </summary>
        public bool CopySelected() {
            if (selectedItems.Count == 0)
                return false;

            if (activityOf(selectedItems[^1]) is not { } activity)
                return false;

            clipboard = activity;
            return true;
        }

        /// <summary>
        /// Adds the copied element to the opened container and selects it. The element stays in the clipboard, so
        /// it can be pasted more than once, and every paste is a copy of its own. Nothing is added without a
        /// clipboard, or when the opened container does not take the element (the root of the workflow holds one
        /// activity, and a container of another kind does not hold it at all).
        /// </summary>
        public bool PasteCopied() {
            if (clipboard is not { } copied)
                return false;

            var target = Path.LastOrDefault()?.Reference?.Node;
            var elementType = copied.GetType();
            if (target == null || !target.CanAdd(elementType.IsGenericType ? elementType.GetGenericTypeDefinition() : elementType))
                return false;

            if (cloneActivity(copied) is not { } copy)
                return false;

            //A paste has no pointer to land on, so a card of a graph surface goes in the middle of what the user
            //sees; a container that lays out its children gives it a place of its own.
            var position = VisibleViewport is { } viewport
                ? new Diagrams.Core.Geometry.Point(
                    viewport.Left + (viewport.Width / 2) + PasteOffset,
                    viewport.Top + (viewport.Height / 2) + PasteOffset)
                : null;

            var (hasAdded, placed) = placeActivity(copy, existing: null, existingOwner: null, initialPosition: position);
            if (!hasAdded)
                return false;

            clearSelection();
            Select(placed.Node);
            updateState();
            return true;
        }

        /// <summary>Whether a card holds an element as one of the branches it draws, which hold one element each.</summary>
        private static bool holdsAsSlot(DefaultNode owner, object element) =>
            owner.Slots.Any(slot => ReferenceEquals(slot.Held, element));

        /// <summary>
        /// A copy of the activity a card shows: the element of the card when it is an Activity itself, or the
        /// activity a graph surface wrapped into a node of its own (the step a `Flowchart` runs holds one). An
        /// element of any other kind — a decision, a switch, a state — has no schema of its own, so it is not
        /// copied, and neither are the connections of the card it was made from: a copy joins nothing.
        /// </summary>
        private static System.Activities.Activity? cloneActivityOf(ActivityDesignerPair card) =>
            activityOf(card) is { } activity ? cloneActivity(activity) : null;

        /// <summary>The activity a card shows, or null when the card holds an element that is not an activity.</summary>
        private static System.Activities.Activity? activityOf(ActivityDesignerPair card) =>
            card.Element is System.Activities.Activity element ? element : card.Activity;

        /// <summary>
        /// A copy of an activity: it is written as a schema of its own and read back, so the copy carries the
        /// arguments and the variables of the original and shares nothing with it.
        /// </summary>
        private static System.Activities.Activity? cloneActivity(System.Activities.Activity activity) {
            var xaml = WorkflowXamlSerializer.SaveBuilder(new ActivityBuilder { Implementation = activity });
            return WorkflowXamlSerializer.LoadBuilder(xaml).Implementation;
        }

        /// <summary>
        /// Marks a card as drawn inside the card of <paramref name="owner"/> instead of by a surface of its own,
        /// so a card taken out of the column of an opened container leaves the canvas.
        /// </summary>
        private void adoptEmbedded(DefaultNode node, DefaultNode owner) {
            node.IsEmbedded = true;
            node.EmbeddedOwner = owner;
            node.IsStackChild = false;
            designer.Nodes.Remove(node);
        }

        /// <summary>
        /// Marks a card as drawn by the surface of the opened container, so a card that comes out of a branch or
        /// an inline list appears on the canvas.
        /// </summary>
        private void adoptSurface(DefaultNode node) {
            node.IsEmbedded = false;
            node.EmbeddedOwner = null;
            node.IsStackChild = false;

            if (!designer.Nodes.Contains(node))
                designer.Nodes.Add(node);
        }

        /// <summary>Takes a card out of whatever draws it, so that the target can take it.</summary>
        private void detachFromOwner(ActivityDesignerPair? card, DefaultNode? owner) {
            if (card == null || owner == null)
                return;

            owner.RemoveElement(card.Element);
            card.Node.IsStackChild = false;
        }

        /// <summary>Whether a card is the target itself, or one the target draws, which would close a cycle.</summary>
        private static bool wouldCarryItself(DefaultNode target, DefaultNode card) =>
            ReferenceEquals(target, card) || isCarriedBy(target, card);

        /// <summary>
        /// Selects a node from the UI. A branch child is rendered inside another card instead of the diagram,
        /// so the diagram selection never picks it up.
        /// </summary>
        public void Select(DefaultNode node) {
            var item = getById(node.Id);
            if (item is null)
                return;

            designer.SelectModel(node, true);

            if (!item.Node.IsEmbedded)
                clearEmbeddedSelection();

            if (!selectedItems.Contains(item))
                selectedItems.Add(item);

            updateState();
        }

        /// <summary>Drops the whole selection, so that the card selected next is the only one selected.</summary>
        private void clearSelection() {
            foreach (var item in selectedItems.ToList())
                designer.UnselectModel(item.Node);

            selectedItems.Clear();
        }

        /// <summary>Clears the selection of the branch children, which the diagram does not track.</summary>
        private void clearEmbeddedSelection() {
            foreach (var item in selectedItems.Where(i => i.Node.IsEmbedded).ToList()) {
                designer.UnselectModel(item.Node);
                selectedItems.Remove(item);
            }
        }

        /// <summary>Forgets the card drag and the drop place an interaction showed.</summary>
        private void resetStackInteraction() {
            DraggedCard = null;
            DropInsertIndex = null;
        }

        /// <summary>The displayed children of a stack container, in model order.</summary>
        private IEnumerable<ActivityDesignerPair> stackChildren(IStackContainer stack) =>
            items.Where(p => p.Node.IsStackChild && stack.IndexOf(p.Element) >= 0)
                .OrderBy(p => stack.IndexOf(p.Element));

        /// <summary>
        /// Place a new element dropped at the given diagram point takes in the opened stack container: before the
        /// first card whose middle is below the point, or at the end of the column. Null when no ordered
        /// container is opened, which is also how the column learns that the caret has to disappear. The place
        /// counts every card of the column, so it is the same number the caret is drawn from; a card that is
        /// dragged inside the column is taken out of it first, which is why the drop shifts the place by one.
        /// </summary>
        public void UpdateDropInsertIndex(Diagrams.Core.Geometry.Point position) {
            //A card that owns the drop (a branch region, or the list a container draws inside itself) decides the
            //place itself, so the surface must not overwrite it with a place of its own.
            if (DropTarget != null || DropSlot != null)
                return;

            var index = OpenedStack is { } stack
                ? stackChildren(stack).Count(p => position.Y >= p.Node.CenterPosition.Y)
                : (int?)null;

            if (DropInsertIndex == index)
                return;

            DropInsertIndex = index;
            updateState();
        }

        /// <summary>Shows the place a dropped element takes in the list of an ordered container.</summary>
        public void SetDropInsertIndex(int index) {
            if (DropInsertIndex == index)
                return;

            DropInsertIndex = index;
            updateState();
        }

        /// <summary>Forgets the place the column showed for a drop, once the drag or the drop is over.</summary>
        public void ClearDropInsertIndex() {
            if (DropInsertIndex is null)
                return;

            DropInsertIndex = null;
            updateState();
        }

        /// <summary>Whether the column draws the place of a new element above the given card.</summary>
        public bool StackCaretAbove(DefaultNode node) {
            if (DropTarget != null || DropSlot != null)
                return false;

            var index = StackIndexOf(node);
            if (index < 0)
                return false;

            return DropInsertIndex == index;
        }

        /// <summary>Whether the column draws the place of a new element below the given card.</summary>
        public bool StackCaretBelow(DefaultNode node) {
            if (DropTarget != null || DropSlot != null)
                return false;

            var index = StackIndexOf(node);
            if (index < 0 || index != StackCount - 1)
                return false;

            return DropInsertIndex == StackCount;
        }

        /// <summary>Moves a card of an ordered container one place up or down.</summary>
        public bool MoveInStack(DefaultNode node, int delta) {
            if (stackOf(node) is not { } stack)
                return false;

            var index = stack.IndexOf(node.Element);
            if (index < 0)
                return false;

            var target = index + delta;
            if (target < 0 || target >= stack.Count)
                return false;

            stack.MoveChild(index, target);
            updateState();
            return true;
        }

        /// <summary>
        /// Ordered container a card belongs to: the card that draws it inside itself (the list of a container
        /// shown on a surface), or the container that is opened and draws it in its column.
        /// </summary>
        private IStackContainer? stackOf(DefaultNode node) {
            if (node.EmbeddedOwner is IStackContainer owner)
                return owner;

            return node.IsStackChild ? Path.LastOrDefault()?.Reference?.Node as IStackContainer : null;
        }

        /// <summary>Whether a card is drawn inside the card of another one, anywhere below it.</summary>
        private static bool isCarriedBy(DefaultNode node, DefaultNode ancestor) {
            for (var owner = node.EmbeddedOwner; owner != null; owner = owner.EmbeddedOwner) {
                if (ReferenceEquals(owner, ancestor))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Whether a card can be dragged as a card: one that a card draws inside itself (a branch child, a card
        /// of an inline list) or one the opened ordered container draws in its column. Every other card is drawn
        /// by a surface of its own, which is what the user drags.
        /// </summary>
        public bool CanDragCard(DefaultNode node) =>
            node.IsEmbedded || StackIndexOf(node) >= 0;

        /// <summary>
        /// Starts dragging a card the user picked up. The card keeps the activity it shows; the drop only
        /// changes what draws it (a list, a branch region, the column of the opened container).
        /// </summary>
        public void StartCardDrag(DefaultNode node) {
            if (!CanDragCard(node))
                return;

            DraggedCard = node;
            DropTarget = null;
            DropSlot = null;

            //A new drag shows a place of its own, so the one the last interaction left is forgotten.
            ClearDropInsertIndex();
        }

        /// <summary>Ends a card drag, whether or not the card was dropped on a place.</summary>
        public void EndCardDrag() {
            if (DraggedCard is null)
                return;

            DraggedCard = null;

            //A card drag has no toolbox item behind it, so nothing else needs the place the drag showed:
            //forgetting it here keeps the caret of a finished drag from staying on a target.
            DropTarget = null;
            DropSlot = null;
            ClearDropInsertIndex();
        }

        /// <summary>
        /// Card that draws the given one: the node whose inline list or branch region holds it, or the ordered
        /// container that is opened and draws it in its column. Null when nothing draws it.
        /// </summary>
        private DefaultNode? ownerOf(DefaultNode card) {
            if (card.EmbeddedOwner is { } owner)
                return owner;

            return StackIndexOf(card) >= 0 ? OpenedStack as DefaultNode : null;
        }

        /// <summary>
        /// Moves the card the user drags to the place the drag showed, and ends the drag: a branch region or a
        /// container that takes the activity, the list of a card (which the list itself handles through
        /// <see cref="MoveInlineChild"/>), or the column of the opened ordered container. The card leaves what
        /// draws it and the target draws it from then on. A drop that points at no place leaves the schema as
        /// it is.
        /// </summary>
        public bool MoveDraggedActivity(Diagrams.Core.Geometry.Point? initialPosition = null) {
            if (DraggedCard is null)
                return false;

            var moved = moveDraggedCard(initialPosition);

            //The drag is over either way, so the place it showed is forgotten.
            DraggedCard = null;
            DropTarget = null;
            DropSlot = null;
            ClearDropInsertIndex();

            return moved;
        }

        private bool moveDraggedCard(Diagrams.Core.Geometry.Point? initialPosition) {
            if (DraggedCard is not { } dragged)
                return false;

            if (FindPair(dragged.Element) is not { } card || ownerOf(dragged) is not { } owner)
                return false;

            //The drag has to point at a card that takes the activity: a drop anywhere else leaves the card where
            //it is instead of placing it in the opened container by accident. The column of the opened ordered
            //container is the exception, because the place it showed (DropInsertIndex) is a target of its own.
            if (DropTarget is null && DropSlot is null && DropInsertIndex is null)
                return false;

            return placeActivity(dragged.Element, card, owner, initialPosition).hasAdded;
        }

        /// <summary>
        /// Makes a card the drop target and shows the place a dropped element takes in its inline list: the gap
        /// before the child at the given index. Used by the card that draws the list, and by its gaps.
        /// </summary>
        public void SetInlineDropTarget(DefaultNode owner, int index) {
            DropTarget = owner;
            DropSlot = null;
            SetDropInsertIndex(index);
        }

        /// <summary>
        /// Moves a card to the place a drop showed on the inline list of <paramref name="owner"/>: the gap
        /// before the child at the given index. The gap counts the children of the list that took the drop as
        /// they are now, so a card of that same list is taken out of it first, while a card that another list,
        /// branch or column draws leaves it and is inserted at the gap.
        /// </summary>
        public bool MoveInlineChild(DefaultNode owner, DefaultNode dragged, int gapIndex) {
            if (owner is not IStackContainer target)
                return false;

            //A container cannot hold itself: a card dropped on its own list, or on the list of a container it
            //carries, would close a cycle in the model.
            if (ReferenceEquals(owner, dragged) || isCarriedBy(owner, dragged))
                return false;

            if (FindPair(dragged.Element) is not { } pair || ownerOf(dragged) is not { } sourceOwner)
                return false;

            //A card of the list that takes the drop only changes its place in that list.
            if (ReferenceEquals(sourceOwner, owner)) {
                var from = target.IndexOf(dragged.Element);
                if (from < 0)
                    return false;

                var to = gapIndex > from ? gapIndex - 1 : gapIndex;
                if (to == from)
                    return false;

                target.MoveChild(from, to);
                updateState();
                return true;
            }

            //The card leaves what drew it, and the list that took the drop draws it from then on.
            detachFromOwner(pair, sourceOwner);
            adoptEmbedded(dragged, owner);
            target.InsertChild(gapIndex, pair);
            updateState();
            return true;
        }

        private ActivityDesignerPair addActivity(System.Activities.Activity activity) => addElement(activity);

    }
}
