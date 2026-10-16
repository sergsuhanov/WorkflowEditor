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
    /// Workflow validation: the messages a run reports, per activity and for the tree, which the cards and the
    /// properties panel show.
    /// </summary>
    public partial class Service {
        /// <summary>Validation messages per activity (key = the model object that produced the error).</summary>
        private readonly Dictionary<object, List<string>> validationErrors = new();

        /// <summary>Elements that hold validation messages, in themselves or in a nested element.</summary>
        private readonly HashSet<object> elementsWithErrors = new(ReferenceEqualityComparer.Instance);

        /// <summary>Replaces the per-activity validation messages with the last validation results.</summary>
        public void SetValidationErrors(System.Activities.Activity? implementation, IEnumerable<System.Activities.Validation.ValidationError> errors) {
            validationErrors.Clear();
            foreach (var error in errors) {
                if (error.Source == null)
                    continue;

                if (!validationErrors.TryGetValue(error.Source, out var list))
                    validationErrors[error.Source] = list = new List<string>();

                var message = string.IsNullOrWhiteSpace(error.PropertyName) ? error.Message : $"{error.PropertyName}: {error.Message}";
                if (!list.Contains(message))
                    list.Add(message);
            }

            elementsWithErrors.Clear();
            if (implementation != null)
                markElementsWithErrors(implementation, new HashSet<object>(ReferenceEqualityComparer.Instance));

            updateState();
        }

        /// <summary>
        /// Marks the elements that hold a validation error, in themselves or in a nested element. A card
        /// without nodes for its content (a container that is not opened, for example) shows an error this
        /// way, so a broken element can always be reached from the outside.
        /// </summary>
        private bool markElementsWithErrors(object element, HashSet<object> visited) {
            if (!visited.Add(element))
                return elementsWithErrors.Contains(element);

            var hasErrors = ErrorCount(element) > 0;
            foreach (var child in ModelTree.Children(element))
                if (markElementsWithErrors(child, visited))
                    hasErrors = true;

            if (hasErrors)
                elementsWithErrors.Add(element);

            return hasErrors;
        }

        /// <summary>Validation messages of one model element (an activity, a State, a FlowNode, ...).</summary>
        public IReadOnlyList<string> ErrorsFor(object? element) =>
            element != null && validationErrors.TryGetValue(element, out var list) ? list : Array.Empty<string>();

        public int ErrorCount(object? element) => ErrorsFor(element).Count;

        /// <summary>Whether the element itself or anything inside it has validation messages.</summary>
        public bool HasErrorsInTree(object? element) =>
            element != null && elementsWithErrors.Contains(element);

    }
}
