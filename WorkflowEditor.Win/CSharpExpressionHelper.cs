// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Activities;
using System.Activities.Expressions;
using System.Activities.Presentation.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using Microsoft.CSharp.Activities;

namespace WorkflowEditor.Win {
    public static class CSharpExpressionHelper {
        private static readonly Type s_cSharpValueType = typeof(CSharpValue<>);
        private static readonly Type s_cSharpReferenceType = typeof(CSharpReference<>);
        private static readonly Type s_codeActivityType = typeof(CodeActivity);
        private static readonly Type s_asyncCodeActivityType = typeof(AsyncCodeActivity);
        private static readonly Type s_genericAsyncCodeActivityType = typeof(AsyncCodeActivity<>);
        private static readonly Type s_variablesCollectionType = typeof(Collection<Variable>);

        internal static ActivityWithResult CreateCSharpExpression(string expressionText, bool isLocationExpression, Type returnType) {
            var expressionType = isLocationExpression ? s_cSharpReferenceType.MakeGenericType(returnType) : s_cSharpValueType.MakeGenericType(returnType);
            return Activator.CreateInstance(expressionType, expressionText) as ActivityWithResult;
        }

        public static ActivityWithResult CreateExpressionFromString(string expressionText, bool useLocationExpression, Type resultType) {
            ActivityWithResult expression;
            if (!useLocationExpression) {
                if (!CSharpExpressionHelper.TryCreateLiteral(resultType, expressionText, out expression)) {
                    expression = CSharpExpressionHelper.CreateCSharpExpression(expressionText, useLocationExpression, resultType);
                }
            } else {
                expression = CSharpExpressionHelper.CreateCSharpExpression(expressionText, useLocationExpression, resultType);
            }

            return expression;
        }

        internal static bool TryCreateLiteral(Type type, string expressionText, out ActivityWithResult literalExpression) {
            literalExpression = null;

            // try easy way first - look if there is a type conversion which supports conversion between expression type and string
            TypeConverter literalValueConverter = null;
            var isQuotedString = false;
            if (IsLiteralExpressionSupported(type)) {
                bool shouldBeQuoted;
                if (typeof(char) == type) {
                    shouldBeQuoted = true;
                    isQuotedString = expressionText.StartsWith("'", StringComparison.CurrentCulture) &&
                            expressionText.EndsWith("'", StringComparison.CurrentCulture) &&
                            expressionText.IndexOf("'", 1, StringComparison.CurrentCulture) == expressionText.Length - 1;
                } else {
                    shouldBeQuoted = typeof(string) == type;

                    // whether string begins and ends with quotes '"'. also, if there are
                    // more quotes within than those begining and ending ones, do not bother with literal - assume this is an expression.
                    isQuotedString = shouldBeQuoted &&
                            expressionText.StartsWith("\"", StringComparison.CurrentCulture) &&
                            expressionText.EndsWith("\"", StringComparison.CurrentCulture) &&
                            expressionText.IndexOf("\"", 1, StringComparison.CurrentCulture) == expressionText.Length - 1 &&
                            expressionText.IndexOf("\\", StringComparison.CurrentCulture) == -1;
                }

                // if expression is a string, we must ensure it is quoted, in case of other types - just get the converter
                if ((shouldBeQuoted && isQuotedString) || !shouldBeQuoted) {
                    literalValueConverter = TypeDescriptor.GetConverter(type);
                }
            }

            // if there is converter - try to convert
            if (null != literalValueConverter && literalValueConverter.CanConvertFrom(null, typeof(string))) {
                try {
                    var valueToConvert = isQuotedString ? expressionText.Substring(1, expressionText.Length - 2) : expressionText;
                    var convertedValue = literalValueConverter.ConvertFrom(null, CultureInfo.CurrentCulture, valueToConvert);

                    // ok, succeeded - create literal of given type
                    var concreteExpType = typeof(Literal<>).MakeGenericType(type);
                    literalExpression = (ActivityWithResult)Activator.CreateInstance(concreteExpType, convertedValue);

                    // C# expression is case sensitive, if it's not exactly "true"/"false" with case matching, we don't generate Literal<bool>
                    if (type == typeof(bool) && (valueToConvert != "true") && (valueToConvert != "false")) {
                        literalExpression = null;
                    }
                } catch (Exception) {
                    // conversion failed - do nothing, let it continue to generate C# expression instead
                }
            }

            return literalExpression != null;
        }

        internal static bool IsLiteralExpressionSupported(Type type) {
            // type must be set and cannot be object
            return null != type && typeof(object) != type
&& (type.IsPrimitive || type == typeof(string) || type == typeof(TimeSpan) || type == typeof(DateTime));
        }

        internal static List<ModelItem> GetVariablesInScope(ModelItem ownerActivity) {
            var variablesInScope = new List<ModelItem>();
            if (ownerActivity != null) {
                var variableNames = new HashSet<string>();
                var currentItem = ownerActivity;
                var filterDelegate = new Func<ModelItem, bool>((variable) => {
                    var variableName = (string)variable.Properties["Name"].ComputedValue;
                    return !string.IsNullOrWhiteSpace(variableName) && !variableNames.Contains(variableName);
                });

                while (currentItem != null) {
                    var variables = new List<ModelItem>();
                    var variablesCollection = GetVariableCollection(currentItem);
                    if (variablesCollection != null) {
                        variables.AddRange(variablesCollection);
                    }

                    variables.AddRange(FindActivityDelegateArguments(currentItem));

                    // For the variables defined at the same level, shadowing doesn't apply. If there're multiple variables defined at the same level
                    // have duplicate names when case is ignored, all of these variables should bee added as variables in scope and let validation reports
                    // ambiguous reference error. So that we need to scan all variables defined at the same level first and then add names to the HashSet.                                        
                    var filteredVariables = variables.Where<ModelItem>(filterDelegate);
                    variablesInScope.AddRange(filteredVariables);
                    foreach (var variable in filteredVariables) {
                        _ = variableNames.Add((string)variable.Properties["Name"].ComputedValue);
                    }

                    currentItem = currentItem.Parent;
                }
            }

            return variablesInScope;
        }

        private static ModelItemCollection GetVariableCollection(ModelItem currentItem) {
            if (null != currentItem) {
                var elementType = currentItem.ItemType;
                if (!(s_codeActivityType.IsAssignableFrom(elementType) || s_genericAsyncCodeActivityType.IsAssignableFrom(elementType) ||
                    s_asyncCodeActivityType.IsAssignableFrom(elementType) || s_genericAsyncCodeActivityType.IsAssignableFrom(elementType))) {
                    var variablesProperty = currentItem.Properties["Variables"];
                    if ((variablesProperty != null) && (variablesProperty.PropertyType == s_variablesCollectionType)) {
                        return variablesProperty.Collection;
                    }
                }
            }

            return null;
        }

        private static IEnumerable<ModelItem> FindActivityDelegateArguments(ModelItem currentItem) {
            var delegateArguments = new List<ModelItem>();
            if (currentItem.GetCurrentValue() is ActivityDelegate) {
                delegateArguments.AddRange(currentItem.Properties
                    .Where<ModelProperty>(p => typeof(DelegateArgument).IsAssignableFrom(p.PropertyType) && null != p.Value)
                    .Select<ModelProperty, ModelItem>(p => p.Value));
            }

            return delegateArguments;
        }
    }
}
