namespace Blazor.WorkflowEditor.Activity;

/// <summary>
/// A single-activity slot of a node: an If branch, a loop body, a catch handler, a switch case. Unlike a
/// container (Sequence, Parallel) a slot holds at most one activity, so it has no children of its own: the
/// card renders the activity the slot holds, and a drop into the slot replaces that activity.
/// </summary>
public interface IActivityHolder {
    /// <summary>Node that owns the slot.</summary>
    DefaultNode Owner { get; }

    /// <summary>Label shown on the branch region and in the breadcrumb ("Then", "Body", "Case 1").</summary>
    string SlotLabel { get; }

    /// <summary>The activity attached to the slot, if any.</summary>
    System.Activities.Activity? Held { get; }

    /// <summary>Attaches an activity to the slot, replacing the one it currently holds.</summary>
    void Attach(ActivityDesignerPair child);
}
