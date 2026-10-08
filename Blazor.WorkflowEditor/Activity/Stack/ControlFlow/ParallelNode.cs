namespace Blazor.WorkflowEditor.Activity.Stack.ControlFlow;

[Pair(typeof(System.Activities.Statements.Parallel), typeof(ParallelControl))]
public class ParallelNode : DefaultNode {
    private readonly System.Activities.Statements.Parallel activity;

    public ParallelNode(Service service, System.Activities.Statements.Parallel activity) : base(service, activity) {
        this.activity = activity;
        IsContainer = true;
    }

    public override IEnumerable<Variable> GetVariables() => GetVariables(activity.Variables);

    /// <summary>Short summary of the parallel branches shown on the collapsed node.</summary>
    public string? BranchesSummary {
        get {
            var count = activity.Branches.Count;
            if (count == 0)
                return null;

            var names = string.Join(", ", activity.Branches.Take(3).Select(a => a.DisplayName));
            return count > 3 ? $"{names} +{count - 3}" : names;
        }
    }

    public override void LoadChilds(Func<System.Activities.Activity, ActivityDesignerPair> addActivity) =>
        ArrangeRow(activity.Branches.Select(addActivity).ToList());

    public override void AddChild(ActivityDesignerPair child) {
        activity.Branches.Add(child.Activity);
        ArrangeRow(new[] { child }, activity.Branches.Count - 1);
        service.NotifyStateChanged();
    }

    public override void RemoveChild(System.Activities.Activity child) => activity.Branches.Remove(child);
}
