// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Activities.Presentation;
using System.Activities.Presentation.Model;

namespace WorkflowEditor.Win {
    internal class ExpressionSelection : ContextItem {
        public ExpressionSelection() {
        }

        public ExpressionSelection(ModelItem modelItem) {
            this.ModelItem = modelItem;
        }

        public ModelItem ModelItem { get; }

        public override Type ItemType {
            get {
                return typeof(ExpressionSelection);
            }
        }
    }
}
