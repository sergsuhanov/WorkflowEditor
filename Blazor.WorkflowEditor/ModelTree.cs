using System.Activities;
using System.Activities.Statements;
using System.Collections;
using System.Reflection;

namespace Blazor.WorkflowEditor;

/// <summary>
/// Walks the workflow model itself. The diagram only has nodes for the opened container and for the
/// activities its cards render, so a card has to look at the model to find out that something inside it
/// (a container that was not opened, a branch child, a state entry) is broken.
/// </summary>
internal static class ModelTree {
    /// <summary>
    /// Links between elements of the same level. Following them would report a whole flowchart or state
    /// machine as broken as soon as a single one of its elements is, so the walk stays inside the
    /// containment tree.
    /// </summary>
    private static readonly string[] siblingLinks = new[] { "Next", "To" };

    /// <summary>The elements directly contained by another element.</summary>
    public static IEnumerable<object> Children(object element) {
        //A delegate keeps its body out of reach: it is the wrapped handler that holds the activities.
        if (element is ActivityDelegate activityDelegate) {
            if (activityDelegate.Handler is { } handler)
                yield return handler;
            yield break;
        }

        foreach (var property in element.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)) {
            if (property.GetIndexParameters().Length > 0 || siblingLinks.Contains(property.Name))
                continue;

            object? value;
            try {
                value = property.GetValue(element);
            } catch (Exception) {
                //A property that cannot be read yet (an argument that was not supplied) holds no element.
                continue;
            }

            foreach (var child in childrenOf(value))
                yield return child;
        }
    }

    /// <summary>
    /// The element itself and everything below it. Guarded against the cycles the model allows, such as a
    /// state machine that returns to its initial state.
    /// </summary>
    public static IEnumerable<object> DescendantsAndSelf(object element) {
        var visited = new HashSet<object>(ReferenceEqualityComparer.Instance);
        var pending = new Stack<object>();
        pending.Push(element);

        while (pending.Count > 0) {
            var current = pending.Pop();
            if (!visited.Add(current))
                continue;

            yield return current;
            foreach (var child in Children(current))
                pending.Push(child);
        }
    }

    private static IEnumerable<object> childrenOf(object? value) {
        switch (value) {
            case null:
            case string:
                yield break;

            //Switch cases hang off the dictionary values, their keys are plain data.
            case IDictionary map:
                foreach (var item in map.Values)
                    if (isElement(item))
                        yield return item!;
                yield break;

            //Collections of children: Sequence.Activities, Parallel.Branches, StateMachine.States, ...
            case IEnumerable sequence:
                foreach (var item in sequence)
                    if (isElement(item))
                        yield return item!;
                yield break;

            default:
                if (isElement(value))
                    yield return value;
                yield break;
        }
    }

    private static bool isElement(object? value) =>
        value is System.Activities.Activity or ActivityDelegate or FlowNode or Transition or Catch;
}
