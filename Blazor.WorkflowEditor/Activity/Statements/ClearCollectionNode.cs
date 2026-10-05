namespace Blazor.WorkflowEditor.Activity.Statements;

[Pair(typeof(System.Activities.Statements.ClearCollection<>), typeof(ClearCollectionControl<>))]
public class ClearCollectionNode<T> : DefaultNode {
    private readonly System.Activities.Statements.ClearCollection<T> activity;

    public ClearCollectionNode(Service service, System.Activities.Statements.ClearCollection<T> activity) : base(service, activity) {
        this.activity = activity;
        this.activity.Collection ??= new System.Activities.InArgument<ICollection<T>>();
        this.IsGeneric = true;
    }

    public Variable? Collection {
        get => service.Variables.FirstOrDefault(variable =>
            variable.Name == ActivityArguments.GetText(activity.Collection));
        set {
            if (value != null)
                ActivityArguments.SetVisualBasicExpression(activity.Collection, argument => activity.Collection = (System.Activities.InArgument<ICollection<T>>)argument, value.Name);
        }
    }
}
