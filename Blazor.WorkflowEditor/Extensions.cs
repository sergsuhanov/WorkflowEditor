// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Blazor.Diagrams.Core.Anchors;
using Blazor.Diagrams.Core.Models;
using Blazor.Diagrams.Core.Models.Base;
using Blazor.WorkflowEditor.Activity;

namespace Blazor.WorkflowEditor {

    internal static class Extensions {

        public static DefaultNode? TargetNode(this BaseLinkModel model) {
            return model.TargetPort()?.Parent as DefaultNode;
        }

        public static PortModel? TargetPort(this BaseLinkModel model) {
            return model.Target is SinglePortAnchor pa ? pa.Port : null;
        }

        public static DefaultNode? SourceNode(this BaseLinkModel model) {
            return model.SourcePort()?.Parent as DefaultNode;
        }

        public static PortModel? SourcePort(this BaseLinkModel model) {
            return model.Source is SinglePortAnchor pa ? pa.Port : null;
        }

        /// <summary>
        /// The name of a type as the editor shows it to the user: the name of the type alone, with the types
        /// that complete it (`List&lt;Int32&gt;`, `List&lt;T&gt;` while it is not complete). The CLR name
        /// (`System.Collections.Generic.List`1[System.Int32]`) is what a tooltip shows where the short name
        /// could belong to two types of different namespaces.
        /// </summary>
        public static string DisplayName(this Type? type) {
            if (type == null)
                return string.Empty;

            var name = type.Name;
            if (!type.IsGenericType)
                return name;

            var separator = name.IndexOf('`');
            var arguments = string.Join(", ", type.GetGenericArguments().Select(argument => argument.DisplayName()));
            return separator < 0 ? name : $"{name[..separator]}<{arguments}>";
        }
    }
}
