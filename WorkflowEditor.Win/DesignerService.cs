using System;
using System.Activities;
using System.Activities.Core.Presentation.Factories;
using System.Activities.Expressions;
using System.Activities.Presentation.Toolbox;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Linq;

namespace WorkflowEditor.Win {
    public class DesignerService {

        public static void AddImports(ActivityBuilder builder) {
            TextExpression.SetNamespacesForImplementation(
               builder,
               new List<string>
                {
                    "System",
                    "System.Linq",
                    "System.Collections.Generic",
                });

            // Add assembly references for the assemblies that end user can reference in expressions.
            TextExpression.SetReferencesForImplementation(
                builder,
                new List<AssemblyReference>
                {
                    typeof(object).Assembly.GetName(), // mscorlib
                    typeof(Activity).Assembly.GetName(), // System.Activities
                });

        }

        public static bool IsSubclassOfRawGeneric(Type toCheck, Type baseType) {
            while (toCheck != typeof(object)) {
                var cur = toCheck.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck;
                if (baseType == cur) {
                    return true;
                }

                toCheck = toCheck.BaseType;
            }

            return false;
        }

        public static void FillToolBar(ToolboxControl toolbox) {

            var c4 = new ToolboxCategory("Other") {
                new ToolboxItemWrapper(typeof(Assign)),
                new ToolboxItemWrapper(typeof(TerminateWorkflow)),
            };
            toolbox.Categories.Add(c4);

            var c2 = new ToolboxCategory("Flowchart") {
                new ToolboxItemWrapper(typeof(Flowchart)),
                new ToolboxItemWrapper(typeof(FlowDecision)),
                new ToolboxItemWrapper(typeof(FlowSwitch<>), "FlowSwitch<T>")
            };
            toolbox.Categories.Add(c2);

            var c1 = new ToolboxCategory("Control Flow") {
                new ToolboxItemWrapper(typeof(Sequence)),
                new ToolboxItemWrapper(typeof(DoWhile)),
                new ToolboxItemWrapper(typeof(ForEachWithBodyFactory<>), "ForEach<T>"),
                new ToolboxItemWrapper(typeof(If)),
                new ToolboxItemWrapper(typeof(System.Activities.Statements.Parallel)),
                new ToolboxItemWrapper(typeof(ParallelForEachWithBodyFactory<>), "ParallelForEach<T>"),
                new ToolboxItemWrapper(typeof(PickWithTwoBranchesFactory), "Pick"),
                new ToolboxItemWrapper(typeof(PickBranch)),
                new ToolboxItemWrapper(typeof(Switch<>), "Switch<T>"),
                new ToolboxItemWrapper(typeof(Cast<,>), "Cast<T1,T2>"),
                new ToolboxItemWrapper(typeof(While)),
                new ToolboxItemWrapper(typeof(TryCatch))
            };
            toolbox.Categories.Add(c1);

            var c3 = new ToolboxCategory("StateMachine") {
                new ToolboxItemWrapper(typeof(StateMachineWithInitialStateFactory), "StateMachine"),
                new ToolboxItemWrapper(typeof(State)),
                new ToolboxItemWrapper(typeof(System.Activities.Core.Presentation.FinalState))
            };
            toolbox.Categories.Add(c3);

            var na = typeof(NativeActivity);
            var na1 = typeof(NativeActivity<>);
            var ca = typeof(CodeActivity);
            var ca1 = typeof(CodeActivity<>);

            {
                var types = System.Reflection.Assembly.GetAssembly(typeof(glassPeople.Model.BusinessRole)).GetTypes();
                foreach (var item in types.OrderBy(p => p.FullName)) {
                    if (item.IsAbstract == false && (item.IsSubclassOf(na) || IsSubclassOfRawGeneric(item, na1) || item.IsSubclassOf(ca) || IsSubclassOfRawGeneric(item, ca1))) {
                        var name = item.Name;

                        var categoryName = item.Namespace.Replace("glassPeople.ActivityLibrary.", "");
                        var category = toolbox.Categories.FirstOrDefault(p => p.CategoryName == categoryName);
                        if (category == null) {
                            category = new ToolboxCategory(categoryName);
                            toolbox.Categories.Add(category);
                        }
          
                        category.Add(new ToolboxItemWrapper(item, name));
                    }
                }
            }

            var misc = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"Resources\misc.png";
            toolbox
                .Categories
                .SelectMany(p => p.Tools)
                .ToList()
                .ForEach(p => p.BitmapName = misc);

        }
    }
}
