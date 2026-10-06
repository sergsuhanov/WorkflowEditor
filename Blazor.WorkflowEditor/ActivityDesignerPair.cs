namespace Blazor.WorkflowEditor {

    public class TypeActivityDesignerPair {
        public Type Activity { get; set; } = default!;
        public Type Node { get; set; } = default!;
        public Type Designer { get; set; } = default!;
    }

    public class ActivityDesignerPair {
        private object? element;

        /// <summary>Activity shown by the node; null for editor elements that are not activities (FlowDecision, State, ...).</summary>
        public System.Activities.Activity Activity { get; set; } = default!;

        /// <summary>The workflow model object shown by the node (the Activity, or a non-activity element).</summary>
        public object Element { get => element ?? Activity; set => element = value; }

        public Activity.DefaultNode Node { get; set; } = default!;
    }

}
