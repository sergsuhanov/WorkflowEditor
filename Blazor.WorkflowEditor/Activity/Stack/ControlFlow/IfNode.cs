using System.Activities;
using System.Activities.Statements;

namespace Blazor.WorkflowEditor.Activity.Stack.ControlFlow;

public enum IfBranch {
    Then,
    Else
}

[Pair(typeof(System.Activities.Statements.If), typeof(IfControl))]
public class IfNode : DefaultNode {
    private readonly System.Activities.Statements.If activity;

    public IfNode(Service service, System.Activities.Statements.If activity) : base(service, activity) {
        this.activity = activity;
        IsContainer = true;
    }

    public string Condition {
        get => ActivityArguments.GetText(activity.Condition);
        set => ActivityArguments.SetVisualBasicExpression(activity.Condition, argument => activity.Condition = (InArgument<bool>)argument, value, argumentType: typeof(bool));
    }

    public string? ThenName => activity.Then?.DisplayName;
    public string? ElseName => activity.Else?.DisplayName;

    public bool HasThen => activity.Then != null;
    public bool HasElse => activity.Else != null;

    public IfBranch SelectedBranch { get; set; } = IfBranch.Then;

    public override void LoadChilds(Func<System.Activities.Activity, ActivityDesignerPair> addActivity) {
        var then = activity.Then != null ? addActivity(activity.Then) : null;
        var els = activity.Else != null ? addActivity(activity.Else) : null;

        //WF-like layout: Then on the left, Else on the right, side by side.
        (var thenX, var elseX) = branchPositions(then?.Node.Size?.Width ?? els?.Node.Size?.Width ?? 250);

        var view = service.VisibleViewport;
        var rowY = view.HasValue ? view.Value.Top + Math.Max(60, view.Value.Height * 0.4) : 150;

        if (then != null && !then.Node.HasViewState)
            place(then, thenX, rowY);
        if (els != null && !els.Node.HasViewState)
            place(els, elseX, rowY);
    }

    private (double thenX, double elseX) branchPositions(double nodeWidth) {
        if (service.VisibleViewport is { } view && view.Width > 0) {
            var center = view.Left + view.Width / 2;
            var offset = Math.Min(nodeWidth / 2 + 30, view.Width / 4);
            return (center - offset, center + offset);
        }

        return (150, 150 + nodeWidth + 40);
    }

    private static void place(ActivityDesignerPair pair, double x, double y) {
        pair.Node.CenterPosition = new Diagrams.Core.Geometry.Point(x, y);
        pair.Node.UpdateViewState();
    }

    /// <summary>Removes the child of the given branch, whether or not it is currently shown on the diagram.</summary>
    public void ClearBranch(IfBranch branch) {
        var child = branch == IfBranch.Then ? activity.Then : activity.Else;
        if (child == null)
            return;

        RemoveChildEverywhere(child);
        service.NotifyStateChanged();
    }

    public override void AddChild(ActivityDesignerPair child) {
        var branch = SelectedBranch;
        var existing = branch == IfBranch.Then ? activity.Then : activity.Else;

        //A branch holds a single activity: replace it.
        ReplaceChild(existing, child);

        if (branch == IfBranch.Then)
            activity.Then = child.Activity;
        else
            activity.Else = child.Activity;

        service.NotifyStateChanged();
    }

    public override void RemoveChild(System.Activities.Activity child) {
        if (activity.Then == child)
            activity.Then = null;
        if (activity.Else == child)
            activity.Else = null;
    }
}
