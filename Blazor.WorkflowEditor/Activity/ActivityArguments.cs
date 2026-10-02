using System.Activities;
using System.Activities.Expressions;
using Microsoft.VisualBasic.Activities;

namespace Blazor.WorkflowEditor.Activity;

internal static class ActivityArguments {
    public static string GetText<T>(InArgument<T>? argument) {
        var expression = argument?.Expression;
        if (expression == null)
            return string.Empty;
        if (expression is Literal<T> literal)
            return Convert.ToString(literal.Value, System.Globalization.CultureInfo.InvariantCulture) ?? string.Empty;
        return expression.GetType().GetProperty("ExpressionText")?.GetValue(expression)?.ToString() ?? string.Empty;
    }

    public static void SetLiteral<T>(InArgument<T>? argument, Action<InArgument<T>> assign, T value) {
        argument ??= new InArgument<T>();
        if (argument.Expression is Literal<T> literal)
            literal.Value = value;
        else
            argument.Expression = new Literal<T> { Value = value };
        assign(argument);
    }

    public static string GetText(Argument? argument) {
        return GetText(argument?.Expression);
    }

    public static string GetText(ActivityWithResult? expression) {
        if (expression == null)
            return string.Empty;
        var expressionText = expression.GetType().GetProperty("ExpressionText")?.GetValue(expression)?.ToString();
        if (expressionText != null)
            return expressionText;
        var value = expression.GetType().GetProperty("Value")?.GetValue(expression);
        return Convert.ToString(value, System.Globalization.CultureInfo.InvariantCulture) ?? string.Empty;
    }

    public static void SetVisualBasicExpression(Argument? argument, Action<Argument> assign, string text, bool isReference = false, Type? argumentType = null) {
        if (argument == null) {
            if (argumentType == null)
                throw new InvalidOperationException("The workflow argument must be initialized before editing.");
            var argumentDefinition = isReference ? typeof(OutArgument<>) : typeof(InArgument<>);
            argument = (Argument?)Activator.CreateInstance(argumentDefinition.MakeGenericType(argumentType))
                ?? throw new InvalidOperationException($"Could not create a workflow argument for {argumentType}.");
        }
        var expressionType = (isReference ? typeof(VisualBasicReference<>) : typeof(VisualBasicValue<>))
            .MakeGenericType(argument.ArgumentType);
        var expression = Activator.CreateInstance(expressionType)
            ?? throw new InvalidOperationException($"Could not create {expressionType}.");
        expressionType.GetProperty("ExpressionText")?.SetValue(expression, text);
        argument.Expression = (ActivityWithResult)expression;
        assign(argument);
    }

    public static Activity<bool> CreateVisualBasicBooleanExpression(string text) =>
        new VisualBasicValue<bool> { ExpressionText = text };
}
