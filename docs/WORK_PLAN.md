# Web editor implementation guide

Use this file for current implementation state and engineering rules. The visual UX backlog is in [VISUAL_EDITOR_PLAN.md](VISUAL_EDITOR_PLAN.md).

## Boundaries

- Change `WorkflowEditor.Web` and projects required by its build only.
- Do not change or migrate `WorkflowEditor.Win` or `glassPeople`.
- Preserve WF XAML load/save behavior. Keep user Activity separate from the legacy Windows library.
- Web projects target .NET 10; do not upgrade unrelated solution projects.

## Current state

- Dependency graph: `WorkflowEditor.Web` → `Blazor.WorkflowEditor`; tests reference the editor library. The Web graph has no `glassPeople` reference or toolbox scan.
- `WorkflowEditor.Web`, `Blazor.WorkflowEditor`, and `Blazor.WorkflowEditor.Tests` target `net10.0`. Package versions are pinned in their project files; a separate review of newer compatible stable versions remains.
- XAML open/save, workflow validation, unsaved-change confirmation, and browser file download are implemented. A new `ActivityBuilder` starts empty and holds one root implementation Activity; root and Flowchart `START` cues are presentation-only. Web view state and notes use `bwas:Designer` attached properties.
- Specialized designers cover `Sequence`, `If`, `While`, `DoWhile`, `ForEach<T>`, `Parallel`, `TryCatch`, `Switch<T>`, `Assign`/`Assign<T>`, `WriteLine`, `Delay`, `Throw`, `TerminateWorkflow`, collection activities, `Flowchart`/`FlowDecision`/`FlowSwitch<T>`, and `StateMachine`/`State`.
- Activities that hold one Activity per branch expose those branches as `IActivityHolder` slots (`DefaultNode.Slots`) and are not containers, so they never place their children on the parent surface and are never opened. Each branch renders the control of the activity it holds as an embedded node (`EmbeddedActivity` + `DynamicComponent`), created by `Service` in `updatePath`; the child can be selected to edit its properties, and a container child keeps its `Open` action and is then edited through the path. `Sequence` and `Parallel` stay containers that list several children on their own surface. `Sequence` is an ordered container (`IStackContainer`): it lays its children out in model order, both as a column on its own surface and as a list drawn inside its card (`DefaultNode.InlineChildren` rendered through `SequenceControl`), a drop lands at the index of the drop point, and a dragged card or `Alt+↑/↓` moves an element to another index. Its children have no ports or connections and keep no position of their own; a card drawn inside a card is an embedded node (`IsEmbedded`), exactly like a branch child. The card header opens and closes that detail with a chevron in the place of the activity icon (`ActivityControl.hasDetail`: the `Content` fragment of a container, or the `Edit` fragment of a custom control). `Parallel` keeps a row of unordered branches with drops and deletes only.
- `Rethrow` and other unpaired loaded activities use the generic fallback: only the display name is editable. Do not describe them as having type-specific editors.
- Compared with the base Windows toolbox, remaining candidates are `ParallelForEach<T>`, `Pick`/`PickBranch`, and `Cast<T1,T2>`. `FinalState` needs XAML investigation before adding: Web already supports `State.IsFinal`.

## Adding or changing an Activity

1. Add the open generic Activity to the appropriate toolbox group in `WorkflowEditor.Web/Shared/MainLayout.razor`.
2. Implement a paired `DefaultNode` and Razor control using `[Pair(typeof(Activity), typeof(Control))]`. Keep workflow-model mutations in the node and UI in the control.
3. For containers, implement child loading, add, remove, and clear behavior. When the activity holds one Activity per branch, expose the branches as `IActivityHolder` slots (`DefaultNode.Slots`) instead of loading children, and render each one with `EmbeddedActivity`, so a drop fills the branch it landed on.
4. Add tests for editing, child management, invalid input, and XAML round-trip. Update the coverage list here when behavior changes.
5. Build and test the Web graph, then restart the local host before browser verification.

## Verification

From the repository root:

```sh
dotnet test Blazor.WorkflowEditor.Tests/Blazor.WorkflowEditor.Tests.csproj -c Release
dotnet build WorkflowEditor.Web/WorkflowEditor.Web.csproj -c Release
```

Run the host with:

```sh
dotnet run --project WorkflowEditor.Web/WorkflowEditor.Web.csproj --urls http://localhost:5199
```

After any rebuild, restart it and verify XAML open → edit → save → reopen in the browser.

## Deferred

- Windows `sap2010:WorkflowViewState` interoperability; Web currently persists its own center coordinates and note properties.
- A separate .NET 10 library for user-authored activities; design it after the base Activity editing conventions stabilize.
