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

        /// <summary>
        /// The collection that holds the variables of an activity, or null when the activity holds none of its
        /// own. Every scope whose variables a node lists has to be here: the panel adds, renames and removes a
        /// variable through this collection, so a scope that is missing here would show its variables and refuse
        /// to change them without a word.
        /// </summary>
        private static ICollection<System.Activities.Variable>? getVariableCollection(object? activity) => activity switch {
            System.Activities.Statements.Sequence sequence => sequence.Variables,
            System.Activities.Statements.Flowchart flowchart => flowchart.Variables,
            System.Activities.Statements.DoWhile doWhile => doWhile.Variables,
            System.Activities.Statements.While whileLoop => whileLoop.Variables,
            System.Activities.Statements.TryCatch tryCatch => tryCatch.Variables,
            System.Activities.Statements.Parallel parallel => parallel.Variables,
            System.Activities.Statements.StateMachine stateMachine => stateMachine.Variables,
            //The editor shows the root as an ActivityBuilder wrapper (DynamicActivity) and its panel lists the
            //variables of the implementation (usually the root Sequence), so adds have to go there as well.
            System.Activities.DynamicActivity dynamicActivity => getVariableCollection(dynamicActivity.Implementation?.Invoke()),
            _ => null
        };

        /// <summary>Whether an activity holds variables of its own: a scope the variables panel can add one to.</summary>
        public static bool CanHoldVariables(object? activity) => getVariableCollection(activity) != null;

        /// <summary>
        /// The scope a variable added in the panel belongs to: the innermost activity of the opened path that
        /// holds variables. A surface without variables of its own — a branch region holds none, and the root
        /// only holds them while its implementation is a scope — resolves outwards to the nearest scope that
        /// does, and the panel says so when the path holds none at all.
        /// </summary>
        public DefaultNode? VariableScope =>
            Path.Select(pathItem => pathItem.Node).LastOrDefault(node => CanHoldVariables(node.Element));

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
