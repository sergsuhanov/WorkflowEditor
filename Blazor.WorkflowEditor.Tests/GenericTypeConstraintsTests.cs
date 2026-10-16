using Blazor.WorkflowEditor.Activity;

namespace Blazor.WorkflowEditor.Tests;

/// <summary>
/// The constraints of the generic parameter a type fills. A type the activity cannot take makes the closed
/// activity fail to build, so the list the drop dialog offers leaves it out, and the dialog refuses a type that
/// only the whole choice shows not to fill its parameter.
/// </summary>
public class GenericTypeConstraintsTests {
    private static Type parameter(Type declaration, int index = 0) => TestGenerics.Parameter(declaration, index);

    [Fact]
    public void AParameterNothingConstrainsTakesAnyType() {
        Assert.True(GenericTypeConstraints.Meets(typeof(int), null));
        Assert.True(GenericTypeConstraints.Meets(null, parameter(typeof(TestGenerics.ReferenceOnly<>))));
        Assert.True(GenericTypeConstraints.Meets(typeof(string), typeof(int)));
        Assert.Null(GenericTypeConstraints.Describe(null));
        Assert.Null(GenericTypeConstraints.Describe(parameter(typeof(List<>))));
    }

    [Theory]
    [InlineData(typeof(string), true)]
    [InlineData(typeof(object), true)]
    [InlineData(typeof(List<>), true)]
    [InlineData(typeof(List<int>), true)]
    [InlineData(typeof(int), false)]
    [InlineData(typeof(bool), false)]
    public void AReferenceTypeParameterTakesOnlyReferenceTypes(Type candidate, bool meets) =>
        Assert.Equal(meets, GenericTypeConstraints.Meets(candidate, parameter(typeof(TestGenerics.ReferenceOnly<>))));

    [Theory]
    [InlineData(typeof(int), true)]
    [InlineData(typeof(bool), true)]
    [InlineData(typeof(string), false)]
    [InlineData(typeof(object), false)]
    [InlineData(typeof(List<>), false)]
    public void AValueTypeParameterTakesOnlyValueTypes(Type candidate, bool meets) =>
        Assert.Equal(meets, GenericTypeConstraints.Meets(candidate, parameter(typeof(TestGenerics.ValueOnly<>))));

    /// <summary>A nullable type is a value type, but not one a `struct` constraint takes: the runtime refuses
    /// `Nullable&lt;int&gt;` and the `Nullable&lt;&gt;` definition itself wherever a parameter asks for a value
    /// type, so the picker does not offer them.</summary>
    [Theory]
    [InlineData(typeof(int?), false)]
    [InlineData(typeof(bool?), false)]
    [InlineData(typeof(Nullable<>), false)]
    [InlineData(typeof(int), true)]
    public void AValueTypeParameterDoesNotTakeANullableType(Type candidate, bool meets) {
        Assert.Equal(meets, GenericTypeConstraints.Meets(candidate, parameter(typeof(TestGenerics.ValueOnly<>))));
        Assert.Equal(meets, GenericTypeConstraints.Meets(candidate, parameter(typeof(Nullable<>))));
    }

    /// <summary>A nullable type is not a reference type either, so a parameter that asks for one does not take
    /// it, while a parameter that asks for nothing takes it like any other type.</summary>
    [Fact]
    public void ANullableTypeIsTakenOnlyWhereNothingConstrainsTheParameter() {
        Assert.False(GenericTypeConstraints.Meets(typeof(int?), parameter(typeof(TestGenerics.ReferenceOnly<>))));
        Assert.True(GenericTypeConstraints.Meets(typeof(int?), null));
        Assert.True(GenericTypeConstraints.Meets(typeof(int?), parameter(typeof(List<>))));
    }

    [Theory]
    [InlineData(typeof(object), true)]
    [InlineData(typeof(List<>), true)]
    [InlineData(typeof(string), false)]
    public void AParameterThatHasToBeConstructibleTakesATypeWithAParameterlessConstructor(Type candidate, bool meets) =>
        Assert.Equal(meets, GenericTypeConstraints.Meets(candidate, parameter(typeof(TestGenerics.NewOnly<>))));

    [Theory]
    [InlineData(typeof(List<int>), true)]
    [InlineData(typeof(string), false)]
    [InlineData(typeof(int), false)]
    public void AConstraintOfAnInterfaceIsCheckedOnTheWholeType(Type candidate, bool meets) =>
        Assert.Equal(meets, GenericTypeConstraints.Meets(candidate, parameter(typeof(TestGenerics.NumbersOnly<>))));

    /// <summary>A type that is not complete yet (`List&lt;&gt;`, before its element is chosen) is judged by what a
    /// definition can be judged by: the type it is, not the interface only its completed form implements.</summary>
    [Fact]
    public void ATypeThatIsNotCompleteYetIsJudgedByTheTypeItIs() {
        Assert.True(GenericTypeConstraints.Meets(typeof(List<>), parameter(typeof(TestGenerics.NumbersOnly<>))));
        Assert.False(GenericTypeConstraints.Meets(typeof(List<>), parameter(typeof(TestGenerics.ValueOnly<>))));
    }

    /// <summary>A constraint that names another parameter of the same activity (`where T : U`) cannot be judged
    /// before that other type is chosen, so the dialog offers the types and the activity refuses what it cannot
    /// build.</summary>
    [Fact]
    public void AConstraintOfAnotherParameterIsLeftToTheActivity() {
        Assert.True(GenericTypeConstraints.Meets(typeof(string), parameter(typeof(TestGenerics.Related<,>))));
        Assert.Equal("the type chosen for U", GenericTypeConstraints.Describe(parameter(typeof(TestGenerics.Related<,>))));
    }

    [Fact]
    public void TheTypesThatPassAreOfferedInTheOrderTheyComeIn() {
        var offered = new List<Type> { typeof(string), typeof(int), typeof(List<>), typeof(bool) };

        Assert.Equal(new[] { typeof(string), typeof(List<>) },
            GenericTypeConstraints.Accepts(offered, parameter(typeof(TestGenerics.ReferenceOnly<>))));
        Assert.Equal(new[] { typeof(int), typeof(bool) },
            GenericTypeConstraints.Accepts(offered, parameter(typeof(TestGenerics.ValueOnly<>))));
        Assert.Equal(offered, GenericTypeConstraints.Accepts(offered, null));
    }

    /// <summary>A list with nothing left falls back to every type it holds: an empty picker would leave the
    /// field unfillable, while a type that is offered can be refused with a reason.</summary>
    [Fact]
    public void AListWithNothingToOfferKeepsEveryTypeItHolds() {
        var offered = new List<Type> { typeof(string), typeof(int) };

        Assert.Equal(offered, GenericTypeConstraints.Accepts(offered, parameter(typeof(TestGenerics.DerivedOnly<>))));
        Assert.Empty(GenericTypeConstraints.Accepts(new List<Type>(), null));
    }

    [Fact]
    public void WhatAParameterRequiresIsNamedTheWayTheRefusalNamesIt() {
        Assert.Equal("a reference type", GenericTypeConstraints.Describe(parameter(typeof(TestGenerics.ReferenceOnly<>))));
        Assert.Equal("a value type", GenericTypeConstraints.Describe(parameter(typeof(TestGenerics.ValueOnly<>))));
        Assert.Equal("a type with a public parameterless constructor",
            GenericTypeConstraints.Describe(parameter(typeof(TestGenerics.NewOnly<>))));
        Assert.Equal($"a type assignable to {typeof(IEnumerable<int>)}",
            GenericTypeConstraints.Describe(parameter(typeof(TestGenerics.NumbersOnly<>))));
        Assert.Null(GenericTypeConstraints.Describe(parameter(typeof(TestGenerics.Related<,>), 1)));
    }
}
