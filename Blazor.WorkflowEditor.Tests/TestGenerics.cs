namespace Blazor.WorkflowEditor.Tests;

/// <summary>
/// Generic declarations the tests put one kind of constraint on: the dialog that completes the generic
/// parameters of an activity offers a type per parameter, and each of these stands for a constraint an activity
/// can ask of the type it is completed with.
/// </summary>
internal static class TestGenerics {
    internal abstract class Base { }

    internal sealed class ReferenceOnly<T> where T : class { }

    internal sealed class ValueOnly<T> where T : struct { }

    internal sealed class NewOnly<T> where T : new() { }

    internal sealed class DerivedOnly<T> where T : Base { }

    /// <summary>A constraint of a type that a declaration completes: `List<int>` is one, `string` is not.</summary>
    internal sealed class NumbersOnly<T> where T : IEnumerable<int> { }

    /// <summary>A constraint of a type that only the completed choice can be judged by: `List<>` is offered
    /// before its element is chosen, and `List<int>` is what the activity is finally asked to take.</summary>
    internal sealed class TextOnly<T> where T : IEnumerable<string> { }

    /// <summary>A constraint that names another parameter of the same activity: the type chosen for `T` has to
    /// be the type chosen for `U`. The constraint is on `T`, which is the parameter that asks for a type.</summary>
    internal sealed class Related<T, U> where T : U { }

    internal static Type Parameter(Type declaration, int index = 0) =>
        declaration.GetGenericArguments()[index];
}
