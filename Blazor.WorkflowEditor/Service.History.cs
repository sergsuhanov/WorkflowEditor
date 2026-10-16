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
    /// The undo and redo history of the schema, the clipboard the copy commands keep, and the flag that says
    /// whether the schema holds changes that are not saved.
    /// </summary>
    public partial class Service {
        private bool isDirty;

        /// <summary>Steps the user can go back and forward through with the undo and redo commands.</summary>
        private readonly WorkflowHistory history = new();

        /// <summary>Element the copy command put on the clipboard, kept as the activity it was copied as.</summary>
        private System.Activities.Activity? clipboard;

        /// <summary>Raised when the unsaved-changes flag changes.</summary>
        public event Action? DirtyChanged;

        /// <summary>Raised when an undo or a redo becomes available or unavailable.</summary>
        public event Action? HistoryChanged;

        /// <summary>True when the schema contains changes that are not saved to XAML yet.</summary>
        public bool IsDirty => isDirty;

        /// <summary>Whether an edit can be taken back.</summary>
        public bool CanUndo => history.CanUndo;

        /// <summary>Whether the edit an undo took back can be applied again.</summary>
        public bool CanRedo => history.CanRedo;

        /// <summary>Clears the unsaved-changes flag (after saving or after loading a schema).</summary>
        public void MarkSaved() {
            if (!isDirty)
                return;

            isDirty = false;
            DirtyChanged?.Invoke();
        }

        /// <summary>
        /// Remembers the schema that was just saved as the state the history compares against, so that undoing
        /// back to it clears the unsaved-changes flag again instead of asking for a save that was made.
        /// </summary>
        public void CaptureSavedState() {
            if (activityBuilder == null)
                return;

            var state = WorkflowXamlSerializer.SaveBuilder(activityBuilder);
            history.Push(state);
            history.MarkSaved(state);
            HistoryChanged?.Invoke();
        }

        /// <summary>
        /// Sets the unsaved-changes flag without editing the schema: a draft the page restored after a reload was
        /// never saved, so the editor keeps offering to save it.
        /// </summary>
        public void MarkDirty() {
            if (isDirty)
                return;

            isDirty = true;
            DirtyChanged?.Invoke();
        }

        /// <summary>
        /// Records the schema as a step of the history. The editor calls it once a burst of edits has settled, so
        /// a burst is one step instead of one step per keystroke.
        /// </summary>
        public void CaptureHistory() {
            if (activityBuilder == null)
                return;

            if (history.Push(WorkflowXamlSerializer.SaveBuilder(activityBuilder)))
                HistoryChanged?.Invoke();
        }

        /// <summary>
        /// Starts a new history. A schema that is restored as a draft was never saved, so the history is told that
        /// it has no saved state to compare against.
        /// </summary>
        public void ResetHistory(bool saved = true) {
            if (activityBuilder == null)
                return;

            history.Reset(WorkflowXamlSerializer.SaveBuilder(activityBuilder));
            if (!saved)
                history.MarkUnsaved();

            HistoryChanged?.Invoke();
        }

        /// <summary>Takes the last step of the history back, when there is one.</summary>
        public void Undo() => restoreHistory(history.Undo());

        /// <summary>Applies the step an undo took back, when there is one.</summary>
        public void Redo() => restoreHistory(history.Redo());

        /// <summary>
        /// Puts the schema of a step back in place. The step carries the view properties, so cards return to the
        /// places and notes they had, while the surface goes back to the root of the workflow: the step is opened
        /// as a schema of its own, and the path belonged to the schema that was left.
        /// </summary>
        private void restoreHistory(string? state) {
            if (state == null)
                return;

            SetActivityBuilder(WorkflowXamlSerializer.LoadBuilder(state));

            //A step is not necessarily the state the schema was saved in, so the flag follows the history.
            if (history.IsAtSavedState)
                MarkSaved();
            else
                MarkDirty();

            HistoryChanged?.Invoke();
        }

    }
}
