using System.Activities;

namespace Blazor.WorkflowEditor.Activity;

[Pair(typeof(System.Activities.DynamicActivity), typeof(DefaultControl))]
public class DynamicActivityNode : DefaultNode {

    private readonly DynamicActivity dynamicActivity;

    public DynamicActivityNode(Service service, System.Activities.DynamicActivity dynamicActivity) : base(service, dynamicActivity) {
        this.dynamicActivity = dynamicActivity;
        this.IsContainer = true;
    }

    public override void LoadChilds(Func<System.Activities.Activity, ActivityDesignerPair> addActivity) {
        var activity = dynamicActivity.Implementation?.Invoke();
        if (activity != null)
            addActivity(activity);
    }

    /// <summary>The single root implementation activity, if one has been assigned.</summary>
    private DefaultNode? ImplementationNode {
        get {
            var activity = dynamicActivity.Implementation?.Invoke();
            if (activity == null)
                return null;

            var node = service.FindPair(activity)?.Node;
            return ReferenceEquals(node, this) ? null : node;
        }
    }

    public override bool CanAdd(Type elementType) =>
        dynamicActivity.Implementation?.Invoke() == null &&
        typeof(System.Activities.Activity).IsAssignableFrom(elementType);

    public override void AddChild(ActivityDesignerPair child) {
        if (dynamicActivity.Implementation?.Invoke() == null)
            service.SetRootImplementation(child.Activity);
    }

    public override void RemoveChild(System.Activities.Activity child) {
        if (ReferenceEquals(dynamicActivity.Implementation?.Invoke(), child))
            service.SetRootImplementation(null);
    }

    public override IEnumerable<Variable> GetVariables() {
        var result = new List<Variable>(GetVariables(dynamicActivity.Properties));

        //A workflow variable lives in the implementation (usually the root Sequence), but it belongs to the
        //root group of the variables panel, so it is listed with the same owner as the arguments. That owner
        //is also what Add/Update/RemoveVariable resolve back to the variables of the implementation.
        //When the implementation container is opened itself it owns its own group already, and listing the
        //variables here as well would show every row twice.
        if (ImplementationNode is { } implementation && !service.Path.Any(p => ReferenceEquals(p.Node, implementation))) {
            foreach (var variable in implementation.GetVariables()) {
                result.Add(new Variable {
                    Activity = dynamicActivity,
                    Name = variable.Name,
                    Type = variable.Type,
                    DefaultValue = variable.DefaultValue
                });
            }
        }

        return result;
    }

}
