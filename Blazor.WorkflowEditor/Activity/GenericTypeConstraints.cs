using System.Reflection;

namespace Blazor.WorkflowEditor.Activity;

/// <summary>
/// The constraints of the generic parameter a type fills. The dialog that completes the generic parameters of
/// an activity asks for one type per parameter, and a type that does not meet the constraints of its parameter
/// makes the closed activity fail to build (`MakeGenericType` refuses it): a type that cannot fill a parameter
/// is not offered, and a type that only the completed choice can be judged by is refused when the dialog is
/// applied.
/// </summary>
public static class GenericTypeConstraints {

    /// <summary>
    /// The types of <paramref name="types"/> that can fill <paramref name="parameter"/>, in the order they are
    /// offered. A collection with nothing left falls back to all of its types: an empty picker would leave the
    /// user with a field that cannot be filled at all, while a type that is offered can be refused with a
    /// reason the message of the dialog gives.
    /// </summary>
    public static List<Type> Accepts(IEnumerable<Type>? types, Type? parameter) {
        var all = types == null ? new List<Type>() : types.ToList();
        if (parameter == null || !parameter.IsGenericParameter)
            return all;

        var accepted = all.Where(type => Meets(type, parameter)).ToList();
        return accepted.Count == 0 ? all : accepted;
    }

    /// <summary>
    /// Whether a type meets the constraints of a generic parameter. A type that is not complete yet (`List&lt;&gt;`
    /// while its element is not chosen) is judged by what a definition can be judged by — the kind of type it is
    /// — and a constraint that names another parameter of the same activity (`where T2 : T1`) is left to the
    /// activity that is built from both, so the caller checks the completed type before it is used.
    /// </summary>
    public static bool Meets(Type? type, Type? parameter) {
        if (type == null || parameter == null || !parameter.IsGenericParameter)
            return true;

        var attributes = parameter.GenericParameterAttributes & GenericParameterAttributes.SpecialConstraintMask;

        if (attributes.HasFlag(GenericParameterAttributes.ReferenceTypeConstraint) && type.IsValueType)
            return false;

        if (attributes.HasFlag(GenericParameterAttributes.NotNullableValueTypeConstraint) && !isNonNullableValueType(type))
            return false;

        if (attributes.HasFlag(GenericParameterAttributes.DefaultConstructorConstraint)
            && !type.IsValueType && type.GetConstructor(Type.EmptyTypes) == null)
            return false;

        foreach (var constraint in parameter.GetGenericParameterConstraints()) {
            //A constraint that is the parameter of the activity itself, and a type that is still open, are
            //decided on the completed type and not here.
            if (constraint.IsGenericParameter || type.ContainsGenericParameters)
                continue;

            if (!constraint.IsAssignableFrom(type))
                return false;
        }

        return true;
    }

    /// <summary>
    /// What a generic parameter requires, named the way the message of a refusal names it ("a value type", "a
    /// type assignable to System.IComparable"), or null when it requires nothing.
    /// </summary>
    public static string? Describe(Type? parameter) {
        if (parameter == null || !parameter.IsGenericParameter)
            return null;

        var attributes = parameter.GenericParameterAttributes & GenericParameterAttributes.SpecialConstraintMask;
        var requirements = new List<string>();

        if (attributes.HasFlag(GenericParameterAttributes.ReferenceTypeConstraint))
            requirements.Add("a reference type");

        if (attributes.HasFlag(GenericParameterAttributes.NotNullableValueTypeConstraint))
            requirements.Add("a value type");
        else if (attributes.HasFlag(GenericParameterAttributes.DefaultConstructorConstraint))
            requirements.Add("a type with a public parameterless constructor");

        foreach (var constraint in parameter.GetGenericParameterConstraints()) {
            //A `struct` constraint also arrives as the value type of the parameter, which the attribute above
            //already names.
            if (constraint == typeof(ValueType))
                continue;

            requirements.Add(constraint.IsGenericParameter
                ? $"the type chosen for {constraint.Name}"
                : $"a type assignable to {constraint}");
        }

        return requirements.Count == 0 ? null : string.Join(", ", requirements);
    }

    /// <summary>
    /// Whether a type is a value type a `struct` constraint takes. A nullable type is not one, although it is a
    /// value type: the runtime refuses `Nullable&lt;int&gt;` and the `Nullable&lt;&gt;` definition itself wherever
    /// a parameter asks for a value type.
    /// </summary>
    private static bool isNonNullableValueType(Type type) =>
        type.IsValueType && type != typeof(Nullable<>) && Nullable.GetUnderlyingType(type) == null;
}
