# Web editor UX instructions

Keep the browser editor understandable, keyboard-accessible, and reliable for creating, opening, editing, validating, and saving WF workflows.

## Scope

- Apply UX changes to `WorkflowEditor.Web` and its required Web projects only.
- Do not change or migrate `WorkflowEditor.Win` or `glassPeople`.
- Keep this file to current behavior, open UX work, acceptance checks, and known limitations. Do not add implementation diaries or closed-step logs.
- Activity coverage and code patterns belong in [WORK_PLAN.md](WORK_PLAN.md).

## Already implemented

- New workflow starts with an empty `ActivityBuilder`; its root accepts one Activity. Toolbox is grouped by control flow, primitives, collections, flowchart, and state machine.
- Resizable/collapsible toolbox, variables, and properties panels; diagram zoom controls include reset and fit.
- Nested stack regions, Flowchart and StateMachine editing, directional connections, validation feedback, notes, dirty-state confirmation, and XAML open/save.
- Sequence's collapsed card is a read-only summary; open the container to add or arrange its children.
- Branches that hold a single activity (`If`, `While`, `DoWhile`, `ForEach<T>`, `TryCatch`, `Switch<T>`) are edited on the node card: the branch renders the control of the activity it holds through a dynamic component, and that control can be selected to edit its properties. A container child keeps its `Open` action and is then edited through the path. These activities hold one activity per branch, so unlike `Sequence` and `Parallel` they are not containers and are never opened.
- Light/dark theme toggle persisted in `localStorage`.
- Properties panel supports display name plus focused editors for Assign, WriteLine, Delay, If, While, and AddToCollection. Dedicated node editors cover additional activities; unsupported types show a clear fallback.

## Active UX priorities

1. **Root, Sequence and branch semantics:** keep a new workflow empty until the user adds its single root Activity; reject a second drop at the `ActivityBuilder` root. Show a presentation-only `START` cue for both the root Activity and the selected Flowchart start element. Add or arrange Sequence children only after opening the Sequence. An activity that holds one Activity per branch (`If`, `While`, `DoWhile`, `ForEach<T>`, `TryCatch`, `Switch<T>`) fills only the branch the drop landed on and renders it inside its own card, so it is never opened.
2. **Workflow Foundation visual comparison:** use the legacy desktop editor as a read-only reference, not as a migration target. Compare its activity toolbox, property inspector, commands, toolbar views, and design surface with the Web editor, then resolve the remaining Web UX gaps. Reference composition: [MainWindow.xaml](../WorkflowEditor.Win/MainWindow.xaml), [MainWindow.xaml.cs](../WorkflowEditor.Win/MainWindow.xaml.cs), and [DesignerService.cs](../WorkflowEditor.Win/DesignerService.cs).
3. **Sequence editing:** make insertion and reordering behavior explicit. Moving a node must not silently change execution order; test insert, reorder, delete, and XAML round-trip.
4. **Keyboard operation:** provide a way to find and add toolbox activities without drag-and-drop. Ensure controls, panels, dialogs, and node actions have accessible names, visible focus, and predictable Enter/Space behavior.
5. **Property context and variables:** make it obvious where each supported Activity is edited, how to open its child region, and which workflow scope owns its variables. A branch surface has no variables of its own, so the variables panel resolves to the nearest enclosing scope that can hold them. Retain an explicit fallback for unsupported properties.
6. **Responsive layout (lower priority):** keep the editor usable at narrow sizes, but prioritize the large-screen workflow canvas used for diagram editing.

## Acceptance checks

- A new workflow has no implicit Sequence; adding one root Activity succeeds, a second root drop is rejected, and deleting the root allows a new one.
- The root-level `START` cue points to the sole implementation Activity; inside Flowchart it points to the selected start element. It follows its target during pan, zoom, and movement, and is absent inside other nested containers. It is never serialized or editable as an Activity.
- An empty root shows `START` and a first-activity drop hint; an unset Flowchart start is clearly indicated. The initial root activity is centered in the visible editor area, including when the editor is first rendered before its canvas dimensions are known.
- The collapsed Sequence card does not accept drops; opening it exposes the child editing surface.
- A branch is filled only when the drop lands on it, and the branch renders the control of the activity it holds; that control can be selected to edit its properties, and a container child keeps its `Open` action, which opens it through the path. An activity that holds one activity per branch is not a container and is never opened itself. Deleting or replacing a branch child releases the model reference, and a card that grew is laid out again so it does not overlap the next card.
- On the primary large-screen layout, the design surface, toolbox, properties, variables, commands, and navigation have clear roles and do not hide essential actions.
- A user can search for and add an Activity with keyboard and pointer; empty search results are explained.
- Selection, nested navigation, and loading a workflow keep the properties panel in sync.
- Invalid field values produce visible feedback and can be corrected.
- Sequence and graph edits preserve their model semantics through save and reopen.
- Narrow viewport layouts remain usable without making essential navigation or actions unreachable.
- Light and dark themes retain readable text, links, ports, validation messages, and focus indicators.

## Verification and known limits

- Run the unit tests and Release Web build from the repository root; manually check the browser after restarting the host following a rebuild.
- Exercise empty, nested, graph, invalid, and large workflows on the primary large-screen layout; check narrow sizes and keyboard-only navigation as secondary coverage.
- Publish with trimming and Windows view-state interoperability have not been verified.
- Graph layout is basic and does not minimize link crossings; graph-port choice is session-only; link bends are not draggable.
