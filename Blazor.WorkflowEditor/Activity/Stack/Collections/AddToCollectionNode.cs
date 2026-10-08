namespace Blazor.WorkflowEditor.Activity.Stack.Collections;

[Pair(typeof(System.Activities.Statements.AddToCollection<>), typeof(AddToCollectionControl<>))]
public class AddToCollectionNode<T> : DefaultNode {
    private readonly System.Activities.Statements.AddToCollection<T> activity;

    public AddToCollectionNode(Service service, System.Activities.Statements.AddToCollection<T> activity) : base(service, activity) {
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
