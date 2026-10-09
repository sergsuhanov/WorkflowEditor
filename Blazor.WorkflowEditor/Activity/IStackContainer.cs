namespace Blazor.WorkflowEditor.Activity;

/// <summary>
/// Container whose children form an ordered list (Sequence). Unlike a graph container (Flowchart,
/// StateMachine) it keeps no connections between its children: the order of the workflow model is the only
/// source of truth, and the child surface is a column of cards. A drop places the new element at the index of
/// the drop point, and a card the user drags inside the column takes a new index.
/// </summary>
public interface IStackContainer {
    /// <summary>Number of children the stack holds.</summary>
    int Count { get; }

    /// <summary>Index of a child element in the stack, or -1 when it does not belong to it.</summary>
    int IndexOf(object element);

    /// <summary>Inserts an element so that it becomes the child at the given index.</summary>
    void InsertChild(int index, ActivityDesignerPair child);

    /// <summary>
    /// Moves the child at <paramref name="from"/> so that it ends up at index <paramref name="to"/> of the
    /// list the child was taken out of first.
    /// </summary>
    void MoveChild(int from, int to);

    /// <summary>Places the children in the column, in model order.</summary>
    void LayoutChildren();
}
