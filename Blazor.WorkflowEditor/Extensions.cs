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
    }
}
