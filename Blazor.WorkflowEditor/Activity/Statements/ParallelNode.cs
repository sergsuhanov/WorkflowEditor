namespace Blazor.WorkflowEditor.Activity.Statements;

[Pair(typeof(System.Activities.Statements.Parallel), typeof(ParallelControl))]
public class ParallelNode : DefaultNode {
    private readonly System.Activities.Statements.Parallel activity;

    public ParallelNode(Service service, System.Activities.Statements.Parallel activity) : base(service, activity) {
        this.activity = activity;
        IsContainer = true;
    }

    public override IEnumerable<Variable> GetVariables() => GetVariables(activity.Variables);

    public override void LoadChilds(Func<System.Activities.Activity, ActivityDesignerPair> addActivity) =>
        ArrangeRow(activity.Branches.Select(addActivity).ToList());

    public override void AddChild(ActivityDesignerPair child) {
        activity.Branches.Add(child.Activity);
        ArrangeRow(new[] { child }, activity.Branches.Count - 1);
    }

    public override void RemoveChild(System.Activities.Activity child) => activity.Branches.Remove(child);
}
