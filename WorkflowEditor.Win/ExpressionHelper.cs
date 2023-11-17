// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Activities;
using System.Activities.Expressions;
using System.Activities.Presentation.Model;
using System.ComponentModel;
using System.Globalization;

namespace WorkflowEditor.Win {
    internal static class ExpressionHelper {
        internal static string GetExpressionString(Activity expression) {
            return ExpressionHelper.GetExpressionString(expression, null as ParserContext);
        }

        internal static string GetExpressionString(Activity expression, ModelItem owner) {
            var context = new ParserContext(owner);
            return ExpressionHelper.GetExpressionString(expression, context);
        }

        internal static string GetExpressionString(Activity expression, ParserContext context) {
            string expressionString = null;
            if (expression != null) {
                var expressionType = expression.GetType();
                var expressionArgumentType = expressionType.IsGenericType ? expressionType.GetGenericArguments()[0] : typeof(object);
                var isLiteral = expressionType.IsGenericType && Type.Equals(typeof(Literal<>), expressionType.GetGenericTypeDefinition());

                //handle ITextExpression
                if (expression is ITextExpression) {
                    var textExpression = expression as ITextExpression;
                    expressionString = textExpression.ExpressionText;
                }
                //handle Literal Expression
                else if (isLiteral) {
                    var converter = XamlUtilities.GetConverter(expressionArgumentType);
                    if (converter != null && converter.CanConvertTo(context, typeof(string))) {
                        var literalValueProperty = expressionType.GetProperty("Value");
                        var literalValue = literalValueProperty.GetValue(expression, null);
                        string convertedString = null;
                        if (literalValue != null) {
                            try {
                                convertedString = converter.ConvertToString(context, literalValue);
                            } catch (ArgumentException) {
                                convertedString = literalValue.ToString();
                            }
                        }
                        expressionString = expressionArgumentType == typeof(string) ? ("\"" + convertedString + "\"") : convertedString;
                    }
                } else if (expressionType.IsGenericType &&
                  (expressionType.GetGenericTypeDefinition() == typeof(VariableValue<>) ||
                  expressionType.GetGenericTypeDefinition() == typeof(VariableReference<>))) {
                    var variableProperty = expression.GetType().GetProperty("Variable");
                    if (variableProperty.GetValue(expression, null) is Variable variable) {
                        expressionString = variable.Name;
                    }
                }
            }

            return expressionString;
        }

        internal static ActivityWithResult TryCreateLiteral(Type type, string expressionText, ParserContext context) {
            //try easy way first - look if there is a type conversion which supports conversion between expression type and string
            TypeConverter literalValueConverter = null;
            var isQuotedString = false;
            if (CanTypeBeSerializedAsLiteral(type)) {
                var shouldBeQuoted = typeof(string) == type;

                //whether string begins and ends with quotes '"'. also, if there are
                //more quotes within than those begining and ending ones, do not bother with literal - assume this is an expression.
                isQuotedString = shouldBeQuoted &&
                        expressionText.StartsWith("\"", StringComparison.CurrentCulture) &&
                        expressionText.EndsWith("\"", StringComparison.CurrentCulture) &&
                        expressionText.IndexOf("\"", 1, StringComparison.CurrentCulture) == expressionText.Length - 1;

                //if expression is a string, we must ensure it is quoted, in case of other types - just get the converter
                if ((shouldBeQuoted && isQuotedString) || !shouldBeQuoted) {
                    literalValueConverter = TypeDescriptor.GetConverter(type);
                }
            }

            //if there is converter - try to convert
            if (null != literalValueConverter && literalValueConverter.CanConvertFrom(context, typeof(string))) {
                try {
                    var valueToConvert = isQuotedString ? expressionText.Substring(1, expressionText.Length - 2) : expressionText;
                    var converterValue = literalValueConverter.ConvertFrom(context, CultureInfo.CurrentCulture, valueToConvert);
                    //ok, succeeded - create literal of given type
                    var concreteExpType = typeof(Literal<>).MakeGenericType(type);
                    return (ActivityWithResult)Activator.CreateInstance(concreteExpType, converterValue);
                } catch (Exception) { }
            }

            return null;
        }

        internal static bool CanTypeBeSerializedAsLiteral(Type type) {
            //type must be set and cannot be object
            return null != type && typeof(object) != type
&& (type.IsPrimitive || type == typeof(string) || type == typeof(TimeSpan) || type == typeof(DateTime));
        }

        // Test whether this activity is Expression
        internal static bool IsExpression(this Activity activity) {
            return activity is ActivityWithResult;
        }

        internal static bool IsGenericLocationExpressionType(ActivityWithResult expression) {
            var expressionType = expression.ResultType;
            return expressionType.IsGenericType && typeof(Location<>) == expressionType.GetGenericTypeDefinition();
        }
    }
}
