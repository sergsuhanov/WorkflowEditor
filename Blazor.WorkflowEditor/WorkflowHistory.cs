namespace Blazor.WorkflowEditor;

/// <summary>
/// A bounded history of the schema, one step per state. A state is the schema as XAML, so an undo brings back
/// the view properties of the cards (position, note, the name of a branch) together with the activities.
/// </summary>
public sealed class WorkflowHistory {
    /// <summary>Steps the history keeps, and the amount of text they may hold together: a large schema is
    /// dropped sooner than a small one, so the history cannot grow without a bound.</summary>
    private const int MaxStates = 20;
    private const int MaxCharacters = 2 * 1024 * 1024;

    private readonly List<string> states = new();
    private int index = -1;
    private string savedState = string.Empty;

    /// <summary>Whether there is a step before the current one to go back to.</summary>
    public bool CanUndo => index > 0;

    /// <summary>Whether the step an undo took back can be applied again.</summary>
    public bool CanRedo => index >= 0 && index < states.Count - 1;

    /// <summary>Whether the current state is the one the schema was opened or last saved with.</summary>
    public bool IsAtSavedState => index >= 0 && states[index] == savedState;

    /// <summary>Starts a new history with the state the editor opens a schema in.</summary>
    public void Reset(string state) {
        states.Clear();
        states.Add(state);
        index = 0;
        savedState = state;
    }

    /// <summary>
    /// Adds the state the schema is in now. The state the history already holds is not added again, so a burst
    /// of edits is one step, and an edit that follows an undo drops the steps that were taken back.
    /// </summary>
    /// <returns>True when the state was added as a new step.</returns>
    public bool Push(string state) {
        if (index < 0) {
            Reset(state);
            return true;
        }

        if (states[index] == state)
            return false;

        states.RemoveRange(index + 1, states.Count - index - 1);
        states.Add(state);
        index++;
        trim();
        return true;
    }

    /// <summary>State to restore for an undo, or null when there is no step before the current one.</summary>
    public string? Undo() => index > 0 ? states[--index] : null;

    /// <summary>State to restore for a redo, or null when no step was taken back.</summary>
    public string? Redo() => index < states.Count - 1 ? states[++index] : null;

    /// <summary>Remembers the state the schema was saved with, so that undoing back to it clears the flag.</summary>
    public void MarkSaved(string state) => savedState = state;

    /// <summary>
    /// Says that the schema is not saved anywhere (a draft restored after a reload), so no state of the history
    /// is the saved one and the editor keeps offering to save it.
    /// </summary>
    public void MarkUnsaved() => savedState = string.Empty;

    private void trim() {
        while (states.Count > 1 && (states.Count > MaxStates || states.Sum(state => state.Length) > MaxCharacters)) {
            states.RemoveAt(0);
            index--;
        }
    }
}
