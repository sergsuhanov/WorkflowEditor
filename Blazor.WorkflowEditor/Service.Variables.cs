using System.Activities;
using System.Collections.ObjectModel;
using System.Reflection;
using Blazor.Diagrams;
using Blazor.Diagrams.Core;
using Blazor.Diagrams.Core.Anchors;
using Blazor.Diagrams.Core.Behaviors;
using Blazor.Diagrams.Core.Controls;
using Blazor.Diagrams.Core.Controls.Default;
using Blazor.Diagrams.Core.Geometry;
using Blazor.Diagrams.Core.Models;
using Blazor.Diagrams.Core.Models.Base;
using Blazor.Diagrams.Core.Positions;
using Blazor.WorkflowEditor.Activity;
using Blazor.WorkflowEditor.Activity.Flow;
using Microsoft.AspNetCore.Components.Web;

namespace Blazor.WorkflowEditor {
    /// <summary>
    /// The variables of the workflow scopes: the collection the panel lists and the commands that add, rename
    /// and remove one.
    /// </summary>
    public partial class Service {
        public void RefreshVariables() {
            Variables.Clear();
            foreach (var item in Path.SelectMany(p => p.Node.GetVariables()))
                Variables.Add(item);
        }

        private static ICollection<System.Activities.Variable>? getVariableCollection(object? activity) => activity switch {
            System.Activities.Statements.Sequence sequence => sequence.Variables,
            System.Activities.Statements.Flowchart flowchart => flowchart.Variables,
            System.Activities.Statements.DoWhile doWhile => doWhile.Variables,
            System.Activities.Statements.StateMachine stateMachine => stateMachine.Variables,
            //The editor shows the root as an ActivityBuilder wrapper (DynamicActivity) and its panel lists the
            //variables of the implementation (usually the root Sequence), so adds have to go there as well.
            System.Activities.DynamicActivity dynamicActivity => getVariableCollection(dynamicActivity.Implementation?.Invoke()),
            _ => null
        };

        private static int indexOf(ICollection<System.Activities.Variable>? collection, string name) {
            if (collection == null)
                return -1;

            var index = 0;
            foreach (var item in collection) {
                if (item.Name == name)
                    return index;
                index++;
            }
            return -1;
        }
    }
}
