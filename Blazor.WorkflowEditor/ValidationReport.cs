using System.Activities.Validation;

namespace Blazor.WorkflowEditor;

/// <summary>
/// The outcome of one validation run: the errors the editor marks on the cards, and the warnings it only
/// reports. A run that reports nothing is valid.
/// </summary>
public sealed class ValidationReport {
    /// <summary>A run that reported nothing, also the answer the editor gives for a schema without a root.</summary>
    public static ValidationReport Empty { get; } = new(Array.Empty<string>(), Array.Empty<string>());

    private ValidationReport(IReadOnlyList<string> errors, IReadOnlyList<string> warnings) {
        Errors = errors;
        Warnings = warnings;
    }

    /// <summary>Messages that stop the workflow from running; each one is shown on the card it belongs to.</summary>
    public IReadOnlyList<string> Errors { get; }

    /// <summary>Messages the workflow can run with, which the user is told about without marking a card.</summary>
    public IReadOnlyList<string> Warnings { get; }

    /// <summary>Whether the run reported anything at all.</summary>
    public bool HasIssues => Errors.Count > 0 || Warnings.Count > 0;

    /// <summary>
    /// Reads the result of <see cref="ActivityValidationServices"/>. The name of the argument a message belongs
    /// to is put in front of it, because a message of an activity with several arguments does not say which one
    /// it is about.
    /// </summary>
    public static ValidationReport From(ValidationResults? results) =>
        results == null
            ? Empty
            : new ValidationReport(messages(results.Errors), messages(results.Warnings));

    private static string[] messages(IEnumerable<ValidationError> errors) =>
        errors.Select(error => string.IsNullOrWhiteSpace(error.PropertyName)
            ? error.Message
            : $"{error.PropertyName}: {error.Message}").ToArray();
}
