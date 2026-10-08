namespace Blazor.WorkflowEditor.Activity.Stack.Collections;

[Pair(typeof(System.Activities.Statements.RemoveFromCollection<>), typeof(RemoveFromCollectionControl<>))]
public class RemoveFromCollectionNode<T> : DefaultNode {
    private readonly System.Activities.Statements.RemoveFromCollection<T> activity;

    public RemoveFromCollectionNode(Service service, System.Activities.Statements.RemoveFromCollection<T> activity) : base(service, activity) {
        this.activity = activity;
        this.activity.Collection ??= new System.Activities.InArgument<ICollection<T>>();
        this.activity.Item ??= new System.Activities.InArgument<T>();
        this.IsGeneric = true;
    }

    public Variable? Collection {
        get => service.Variables.FirstOrDefault(variable =>
            variable.Name == ActivityArguments.GetText(activity.Collection));
        set {
            if (value == null || ActivityArguments.GetText(activity.Collection) == value.Name)
                return;

            ActivityArguments.SetVisualBasicExpression(activity.Collection, argument => activity.Collection = (System.Activities.InArgument<ICollection<T>>)argument, value.Name);
            service.NotifyStateChanged();
        }
    }

    public Variable? Item {
        get => service.Variables.FirstOrDefault(variable =>
            variable.Name == ActivityArguments.GetText(activity.Item));
        set {
            if (value == null || ActivityArguments.GetText(activity.Item) == value.Name)
                return;

            ActivityArguments.SetVisualBasicExpression(activity.Item, argument => activity.Item = (System.Activities.InArgument<T>)argument, value.Name);
            service.NotifyStateChanged();
        }
    }
}
