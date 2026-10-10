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
- XAML open/save, workflow validation, unsaved-change confirmation, and browser file download are implemented; a failed open/save/validate and an operation the editor refuses are reported in a dialog (`MessageModal`), so the page keeps no status line of its own. A variable is edited in its row, so neither adding nor editing one uses a form: the panel opens two dialogs, the confirmation of a deletion (`ConfirmationModal`) and the choice of a type (`TypeSelectModal`, the same form that completes the generic parameters of an activity that is dropped). A new `ActivityBuilder` starts empty and holds one root implementation Activity; only a `Flowchart` draws a `START` cue (the root and every other surface just ask for their first element), and the cue is presentation-only. Web view state and notes use `bwas:Designer` attached properties.
- Specialized designers cover `Sequence`, `If`, `While`, `DoWhile`, `ForEach<T>`, `Parallel`, `TryCatch`, `Switch<T>`, `Assign`/`Assign<T>`, `WriteLine`, `Delay`, `Throw`, `TerminateWorkflow`, collection activities, `Flowchart`/`FlowDecision`/`FlowSwitch<T>`, and `StateMachine`/`State`.
- Activities that hold one Activity per branch expose those branches as `IActivityHolder` slots (`DefaultNode.Slots`) and are not containers, so they never place their children on the parent surface and are never opened. Each branch renders the control of the activity it holds as an embedded node (`EmbeddedActivity` + `DynamicComponent`), created by `Service` in `updatePath`; the child can be selected to edit its properties, and a container child keeps its `Open` action and is then edited through the path. Such a card passes its fields as `Preview` and its regions, with those same fields above them, as `Edit`, so its branches appear once the chevron opens the card. `Sequence` and `Parallel` stay containers that list several children on their own surface. `Sequence` is an ordered container (`IStackContainer`): it lays its children out in model order, both as a column on its own surface and as a list drawn inside its card (`DefaultNode.InlineChildren` rendered through `SequenceControl`), a drop lands at the index of the drop point, and a dragged card or `Alt+↑/↓` moves an element to another index. Any card that another card draws is dragged as a card of its own (`Service.CanDragCard`): a branch child (`EmbeddedActivity`), a card of an inline list, and a card of the column of the opened container (`ActivityControl`), which takes its own pointer events so the diagram never moves the node under it. The drop of a dragged card is placed by the same code as a toolbox item (`Service.placeActivity`, which `AddActivity`, `Service.MoveDraggedActivity` and `Service.MoveInlineChild` share): the card keeps the activity it shows and only what draws it changes, so a branch region of another activity, a region of a container card, the list of another `Sequence` card and the column of the opened container all take it exactly like a toolbox item. A card the drag points at a place of is taken out of what drew it first (`Service.detachFromOwner`), a card that leaves the column is taken off the canvas (`adoptEmbedded` removes it from the diagram) and a card that enters it becomes a node of it again (`adoptSurface`), except into a target it carries itself, which would close a cycle. A region takes drops when the card is on a surface or drawn by an inline list (`ActivityRegion.acceptsDrop`), because a card drawn inside a branch is opened first. Its children have no ports or connections and keep no position of their own; a card drawn inside a card is an embedded node (`IsEmbedded`), exactly like a branch child. Ports are rendered only by the cards a graph container (`IGraphContainer`: `Flowchart`, `StateMachine`) lays out and marks through `DefaultNode.UseGraphPorts` (`DefaultNode.ShowsPorts`): the mode where the user connects elements to each other exists only there, while a card placed by any other container cannot start a link. The card body shows one of two blocks: the compact fields a control passes as `Preview` while the card is closed, and the editor it passes as `Edit` while the card is open, where a container passes its child list as that editor. A card whose control passes no `Edit` has no chevron and no closed state. A card starts closed and the state is kept with the activity (`bwas:Designer.IsExpanded`), so it survives leaving the container and save/reopen. `Parallel` keeps a row of unordered branches with drops and deletes only.
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
