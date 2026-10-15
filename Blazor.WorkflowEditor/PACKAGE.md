# Blazor.WorkflowEditor

A Razor component library that edits Windows Workflow Foundation schemas in the browser.

The library renders a workflow as cards that are dragged, connected and edited on a diagram, and keeps the
workflow model of the [UiPath.Workflow](https://www.nuget.org/packages/UiPath.Workflow) runtime in step with what
the user does. The schema is opened and saved as WF XAML (`ActivityBuilder`), so a workflow written by the
classic desktop designer opens in the editor and the other way round; the view state the editor adds (card
positions, notes, the expanded state of a card) travels in `bwas:Designer` attached properties.

## What it holds

- A toolbox of activities that a host page supplies (`ToolBoxGroup`), covering the stack activities
  (`Sequence`, `If`, `While`, `DoWhile`, `ForEach<T>`, `Parallel`, `TryCatch`, `Switch<T>`, `Assign`,
  `WriteLine`, `Delay`, `Throw`, `TerminateWorkflow`, the collection activities) and the graph surfaces
  (`Flowchart`, `StateMachine`).
- A specialized card per activity, with the fields of the activity it edits, the branches it holds and the
  container it opens; an activity without a card of its own falls back to editing its display name.
- Workflow validation (`ValidationReport`), variables per scope, notes, and an undo/redo history.

## Use it

```razor
<Blazor.WorkflowEditor.Editor ToolBoxGroups="groups" TypeCollection="types" />
```

`ToolBoxGroups` lists the activities the toolbox offers, `TypeCollection` the types a generic parameter is
chosen from. `DirtyChanged`, `ContentChanged`, `HistoryChanged` and `OperationFailed` tell the page what
happened, and `New`, `Load`, `Save`, `Validate`, `Undo` and `Redo` drive the editor from a host toolbar.
