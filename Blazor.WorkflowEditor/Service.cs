using System.Activities;
using System.Collections.ObjectModel;
using Blazor.Diagrams;
using Blazor.Diagrams.Core;
using Blazor.Diagrams.Core.Models;
using Blazor.Diagrams.Core.Models.Base;
using Blazor.WorkflowEditor.Activity;
using System.Reflection;
using Microsoft.AspNetCore.Components.Web;

namespace Blazor.WorkflowEditor {

    public partial class Service : IDisposable {
        private class ActivityPairType {
            public Type Type;
            public PairAttribute PairAttribute;
            public ActivityPairType(Type type, PairAttribute pairAttribute) {
                Type = type;
                PairAttribute = pairAttribute;
            }
        }

        private ActivityBuilder activityBuilder = default!;
        private readonly BlazorDiagram designer = default!;
        private readonly Action updateState = default!;
        private readonly List<ActivityDesignerPair> items = new();
        private readonly List<ActivityDesignerPair> selectedItems = new();
        private readonly List<(ActivityDesignerPair, ActivityDesignerPair)> selectedLinks = new();
        private readonly Dictionary<Type, ActivityPairType> typePairAttributes = new();

        public IEnumerable<ActivityDesignerPair> Items => items;
        public IEnumerable<ActivityDesignerPair> SelectedItems => selectedItems;
        public IEnumerable<(ActivityDesignerPair source, ActivityDesignerPair target)> SelectedLinks => selectedLinks;

        public ObservableCollection<PathItem> Path = new();
        public ObservableCollection<Variable> Variables { get; set; } = new();

        public Diagrams.Core.Geometry.Rectangle? DiagramContainer => this.designer.Container;

        public int LinkCount => designer.Links.Count;

        public ToolBoxItem? DraggedToolboxItem { get; set; }

        public event Action? SelectedOnMove;

        public Service(BlazorDiagram designer, Action updateState) {
            this.designer = designer;

            this.designer.SelectionChanged += selectionChanged;
            this.designer.PointerDoubleClick += pointerDoubleClick;
            this.designer.PointerUp += pointerUp;
            this.designer.PanChanged += panChanged;
            this.designer.ZoomChanged += zoomChanged;

            this.updateState = updateState;
        }


        public void Dispose() {
            this.designer.SelectionChanged -= selectionChanged;
            this.designer.PointerDoubleClick -= pointerDoubleClick;

            this.designer.PointerUp -= pointerUp;

            this.designer.PanChanged -= panChanged;
            this.designer.ZoomChanged -= zoomChanged;

            GC.SuppressFinalize(this);
        }

        public void Delete(Activity.DefaultNode node) {
            var item = getById(node.Id);
            if (item is null)
                return;

            RemoveAllLinks(node);
            selectedLinks.RemoveAll(l => l.Item1 == item || l.Item2 == item);

            designer.Nodes.Remove(node);

            //Remove element in parent
            Path.Last()?.Reference?.Node?.RemoveElement(item.Element);

            selectedItems.Remove(item);
            items.Remove(item);
        }

        /// <summary>
        /// Add by activity type
        /// </summary>
        public (bool hasAdded, ActivityDesignerPair result) AddActivity(Type activityType, params Type[] types) {
            object? activityObject;
            if (types != null && types.Length > 0) {
                activityObject = Activator.CreateInstance(activityType.MakeGenericType(types));
            } else {
                activityObject = Activator.CreateInstance(activityType);
            }

            if (activityObject == null)
                return (false, default!);

            var result = addElement(activityObject);

            var lastNode = Path.LastOrDefault()?.Reference?.Node;
            lastNode?.AddChild(result);

            return (true, result);
        }

        public ActivityBuilder GetActivityBuilder() {
            return this.activityBuilder;
        }

        public void SetActivityBuilder(ActivityBuilder activityBuilder) {
            SelectedOnMove = null;
            designer.Nodes.Clear();
            designer.Links.Clear();
            items.Clear();
            selectedItems.Clear();
            selectedLinks.Clear();
            Path.Clear();
            Variables.Clear();
            this.activityBuilder = activityBuilder;

            var da = new DynamicActivity {
                Implementation = () => activityBuilder.Implementation,
                DisplayName = "ActivityBuilder"
            };
            activityBuilder.Properties.ToList().ForEach(p => da.Properties.Add(p));
            activityBuilder.Constraints.ToList().ForEach(p => da.Constraints.Add(p));
            activityBuilder.Attributes.ToList().ForEach(p => da.Attributes.Add(p));
            var pair = addActivity(da);

            Path.Clear();
            Path.Add(new(pair));
            updatePath();
        }

        public void Open(Activity.DefaultNode node) {
            var item = getById(node.Id);
            if (item is null)
                return;

            Path.Add(new PathItem(item));
            updatePath();

        }

        public void OpenPath(PathItem pathItem) {
            if (Path.Contains(pathItem) == false)
                return;

            while (Path.Last() != pathItem)
                Path.RemoveAt(Path.Count - 1);

            updatePath();
        }

        public bool CheckAddActivity(Type activityType) {
            if (activityBuilder?.Implementation == null || activityType == null)
                return false;

            var last = Path.Last();
            if (last.Reference == null)
                return false;

            if (last.Reference.Node.IsContainer == false)
                return false;

            var elementType = activityType.IsGenericType ? activityType.GetGenericTypeDefinition() : activityType;
            if (!last.Reference.Node.CanAdd(elementType))
                return false;

            return true;
        }

        internal void RemoveAllLinks(DefaultNode node) {
            foreach (var link in designer.Links.Where(l => l.SourceNode() == node || l.TargetNode() == node).ToList())
                designer.Links.Remove(link);
        }

        internal LinkModel LinkFromTo(ActivityDesignerPair from, ActivityDesignerPair to) {
            var linkModel = new LinkModel(from.Node.OutcomingPort, to.Node.IncomingPort) {
                TargetMarker = LinkMarker.Arrow
            };
            designer.Links.Add(linkModel);
            return linkModel;
        }
        internal void RemoveLinkFromTo(ActivityDesignerPair from, ActivityDesignerPair to) {
            var link = designer.Links.FirstOrDefault(p => p.SourceNode() == from.Node && p.TargetNode() == to.Node);
            if (link != null)
                designer.Links.Remove(link);

            selectedLinks.Remove((from, to));
        }

        public ActivityDesignerPair? FindPair(object element) => this.items.FirstOrDefault(p => ReferenceEquals(p.Element, element));
        internal ActivityDesignerPair GetPair(System.Activities.Activity source) => this.items.First(p => p.Activity == source);
        internal ActivityDesignerPair GetPair(DefaultNode node) => this.items.First(p => p.Node == node);

        private ActivityDesignerPair? getById(string id) => this.items.FirstOrDefault(p => p.Node.Id == id);

        private void selectionChanged(Diagrams.Core.Models.Base.SelectableModel obj) {
            if (obj is NodeModel) {
                var item = getById(obj.Id);
                if (item == null)
                    return;

                if (obj.Selected)
                    selectedItems.Add(item);
                else
                    selectedItems.Remove(item);

            } else
            if (obj is LinkModel link) {
                if (link.TargetNode() == null)
                    return;

                var source = getById(link.SourceNode()?.Id ?? string.Empty);
                var target = getById(link.TargetNode()?.Id ?? string.Empty);

                if (source == null || target == null)
                    return;

                if (obj.Selected) {
                    selectedLinks.Add((source, target));
                } else {
                    selectedLinks.Remove((source, target));
                }
            }
        }

        private void pointerDoubleClick(Model? arg1, Diagrams.Core.Events.PointerEventArgs arg2) {
            if(arg1 is null)
                return;

            var item = getById(arg1.Id);
            if (item == null || item.Node.IsContainer == false)
                return;

            Open(item.Node);
        }

        private void pointerUp(Model? model, Diagrams.Core.Events.PointerEventArgs arg) {
            if (model is null)
                return;

            if (arg.ClientX > 50 || arg.ClientY > 50) {
                if (model is DefaultNode node) {
                    SelectedOnMove?.Invoke();

                    node.UpdateViewState();
                }
            }
        }
        private void zoomChanged() {
            //this.Path.Last().Reference.Node.
            //throw new NotImplementedException();
        }

        private void panChanged() {
            //throw new NotImplementedException();
        }

        private void updatePath() {
            //TODO: for variable try use
            //System.Activities.ScopeUtils.GetLocals(this Activity activity) 

            this.designer.Nodes.Clear();
            this.designer.Links.Clear();

            this.selectedItems.Clear();
            this.selectedLinks.Clear();
            this.SelectedOnMove = null;

            //Keep only the pairs of the opened path; children are recreated by LoadChilds
            items.RemoveAll(p => !Path.Any(x => x.Reference == p));

            Variables.Clear();
            foreach (var item in Path.SelectMany(p => p.Node.GetVariables()))
                Variables.Add(item);

            Path.Last().Reference.Node.LoadElements(addElement);
            updateState();

        }

        private void discoverPairs() {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies()) {
                Type[] types;
                try {
                    types = assembly.GetTypes();
                } catch (ReflectionTypeLoadException ex) {
                    types = ex.Types.OfType<Type>().ToArray();
                } catch (Exception) {
                    continue;
                }

                foreach (var type in types) {
                    if (type.GetCustomAttributes(typeof(PairAttribute), true).FirstOrDefault() is not PairAttribute attr)
                        continue;

                    if (!typePairAttributes.ContainsKey(attr.Activity))
                        typePairAttributes.Add(attr.Activity, new ActivityPairType(type, attr));
                }
            }
        }

        private ActivityDesignerPair addActivity(System.Activities.Activity activity) => addElement(activity);

        private ActivityDesignerPair addElement(object activity) {
            if (!typePairAttributes.Any())
                discoverPairs();

            var activityType = activity.GetType();
            DefaultNode? node;
            if (typePairAttributes.TryGetValue(activityType.IsGenericType ? activityType.GetGenericTypeDefinition() : activityType, out var pairT)) {
                if (activityType.IsGenericType) {
                    var genericTypes = activityType.GenericTypeArguments;
                    node = (Activator.CreateInstance(pairT.Type.MakeGenericType(genericTypes), this, activity) as Activity.DefaultNode)!;
                    if (designer.GetComponent(node) == null) {
                        designer.RegisterComponent(pairT.Type.MakeGenericType(genericTypes), pairT.PairAttribute.Control.MakeGenericType(genericTypes));
                    }
                } else {
                    node = (Activator.CreateInstance(pairT.Type, this, activity) as Activity.DefaultNode)!;
                    if (designer.GetComponent(node) == null) {
                        designer.RegisterComponent(pairT.Type, pairT.PairAttribute.Control);
                    }
                }

            } else {
                node = new DefaultNode(this, activity);
                if (designer.GetComponent(node) == null) {
                    designer.RegisterComponent(typeof(DefaultNode), typeof(DefaultControl));
                }
            }
            designer.Nodes.Add(node);
            node.RestoreViewState();
            ActivityDesignerPair result = new() { Activity = (activity as System.Activities.Activity)!, Element = activity, Node = node };
            items.Add(result);
            return result;
        }

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
            _ => null
        };

        public virtual void AddVariable<TActivity>(TActivity activity, string name, Type type, string defaultValue) where TActivity : class {
            var genType = typeof(System.Activities.Variable<>).MakeGenericType(type);
            object?[] constructorParams;
            try {
                var defType = Convert.ChangeType(defaultValue, type);
                constructorParams = new object?[] { name, defType };
            } catch {
                constructorParams = new object?[] { name };
            }
            var variable = Activator.CreateInstance(genType, constructorParams);
            if (variable != null)
                getVariableCollection(activity)?.Add((System.Activities.Variable)variable);
        }

        public virtual void RemoveVariable<TActivity>(TActivity activity, string name) where TActivity : class {
            var collection = getVariableCollection(activity);
            var variable = collection?.FirstOrDefault(p => p.Name == name);
            if (variable != null)
                collection!.Remove(variable);
        }

        public virtual void UpdateVariable<TActivity>(TActivity activity, string oldName, string name, Type type, string defaultValue) where TActivity : class {
            RemoveVariable(activity, oldName);
            AddVariable(activity, name, type, defaultValue);
        }
    }
}
