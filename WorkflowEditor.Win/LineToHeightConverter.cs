﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using System.Windows.Media;

namespace WorkflowEditor.Win {
    internal sealed class LineToHeightConverter : IMultiValueConverter {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) {
            var convertedValue = double.NaN;
            var isDefault = true;

            // Calculate the height for the textblock as ExpressionTextBox exposes lines properties,
            // and TextBlock doesn't have lines properties.
            var fontFamily = values.OfType<FontFamily>().FirstOrDefault();
            var lines = values.OfType<int>().FirstOrDefault();
            var doubleArray = values.OfType<double>().ToArray<double>();

            if (doubleArray.Length == 2) {
                var height = doubleArray[0]; // The first element of the array is going to be the height
                var fontSize = doubleArray[1]; // The seconed element of the array is going to be the fontSize

                // 0.0 is default for MinHeight, PositiveInfinity is default for MaxHeight
                if (string.Equals(parameter as string, "MinHeight")) {
                    isDefault = height == 0.0;
                } else if (string.Equals(parameter as string, "MaxHeight")) {
                    isDefault = double.IsPositiveInfinity(height);
                }

                // If the height value we are evaluating is default, use Lines for sizing...
                // If no heights (height or lines) have been explicitly specified, we would rather default the height
                // as if the Line was 1 - so use the line heights, rather than 0.0 and/or PositiveInfinity.
                if (isDefault) {
                    var lineHeight = fontSize * fontFamily.LineSpacing;

                    if (fontFamily != null) {
                        convertedValue = (lineHeight * lines) + 4;
                    }
                } else {
                    convertedValue = height;
                }
            }

            return convertedValue;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) {
            throw new NotSupportedException();
        }
    }
}
