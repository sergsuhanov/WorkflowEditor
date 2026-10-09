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
- The card header carries the activity icon (or, on a card that holds detail, the chevron that opens and closes it in the place of that icon), the display name (truncated, full name in the tooltip) and the card actions; the body holds the note preview, the activity preview and, while the card is expanded, the detail it holds.
- Every activity edits its own fields on its card, so no built-in card needs an edit command: the chevron of the card opens and closes only the detail a card holds — the list of children of an ordered container, or the inline editor a custom control passes as the `Edit` fragment of `ActivityControl`. A card without detail shows its activity icon instead of the chevron and stays expanded.
- Designer notes are edited in the properties panel in a multi-line field that keeps the line breaks the user typed; the card previews the note, clamped to three lines, and the note is saved in XAML next to its activity.
- Validation has no panel of its own. A card whose activity reports errors, or that holds an activity reporting errors anywhere below it, is outlined in red, and the messages of the selected activity are listed in the properties panel.
- Containers (`Sequence`, `Parallel`) are plain cards that keep a short body below the header, so an empty card still reads as a surface that holds the schema, because everything they hold is visible after opening them.
- A `Sequence` is edited in two ways, and both show the same children. Its card draws the children inside itself, one under another in model order (a nested container draws its own children the same way, so the whole tree is cascaded), and the `Open` action shows them on a surface of their own as a column. A drop lands at the index of the drop point (a caret shows the place), a card dragged to another place takes it, `Alt+↑/↓` moves the selected card in the order (the properties panel says so), and the header keeps no move commands. A card of an ordered container has no ports or connections and keeps no position of its own (a `bwas:Designer.CenterX` left in an older file is ignored). Opening a card that is drawn inside another card puts the containers between them on the breadcrumb. `Parallel` stays a row of branches: its members are unordered, so it accepts drops and deletes only.
- An opened container that holds nothing yet asks for its first element with the same dashed placeholder the empty root uses.
- Branches that hold a single activity (`If`, `While`, `DoWhile`, `ForEach<T>`, `TryCatch`, `Switch<T>`) are edited on the node card: the branch renders the control of the activity it holds through a dynamic component, and that control can be selected to edit its properties. A container child keeps its `Open` action and is then edited through the path. These activities hold one activity per branch, so unlike `Sequence` and `Parallel` they are not containers and are never opened.
- A branch is a caption plus the control of the activity it holds, with no frame of its own, so the inner card stays the only border. An empty branch shows the same dashed drop placeholder as the start of a new schema.
- The card of an activity carries its properties as compact fields above its branches: `If`, `While`, `DoWhile` their condition, `ForEach<T>` its values and item name, `Switch<T>` its expression and cases, `TryCatch` its catch type, `WriteLine` its text, `Delay` its duration, `Assign` its destination and source, and the collection activities their variables. `If` places Then and Else next to each other.
- A graph container keeps the one choice that is not made inside it: `Flowchart` its start node and `StateMachine` its initial state. A `FlowDecision` and a `FlowSwitch<T>` carry their condition, expression and targets, and a state carries its entry, exit, transitions, and its initial/final flags.
- Editing a property on a card or in the properties panel marks the schema as changed and refreshes the diagram and the panel, because the model setters notify the service.
- Light/dark theme toggle persisted in `localStorage`.
- Properties panel supports display name plus focused editors for Assign, WriteLine, Delay, If, While, and AddToCollection. Dedicated node editors cover additional activities; unsupported types show a clear fallback.

## Active UX priorities

1. **Root, Sequence and branch semantics:** keep a new workflow empty until the user adds its single root Activity; reject a second drop at the `ActivityBuilder` root. Show a presentation-only `START` cue, the same one everywhere: every canvas that has no start element asks for its first element with it (empty root, empty `Sequence`/`Parallel`, empty `Flowchart`/`StateMachine` and a `Flowchart` whose start node is not chosen), and every canvas that has one draws the cue on the card of that element (the root Activity, a Flowchart start node, the initial state, the first element of a `Sequence`). Add or arrange Sequence children only after opening the Sequence. An activity that holds one Activity per branch (`If`, `While`, `DoWhile`, `ForEach<T>`, `TryCatch`, `Switch<T>`) fills only the branch the drop landed on and renders it inside its own card, so it is never opened.
2. **Workflow Foundation visual comparison:** use the legacy desktop editor as a read-only reference, not as a migration target. Compare its activity toolbox, property inspector, commands, toolbar views, and design surface with the Web editor, then resolve the remaining Web UX gaps. Reference composition: [MainWindow.xaml](../WorkflowEditor.Win/MainWindow.xaml), [MainWindow.xaml.cs](../WorkflowEditor.Win/MainWindow.xaml.cs), and [DesignerService.cs](../WorkflowEditor.Win/DesignerService.cs).
3. **Sequence editing:** the children of an opened `Sequence` form a column (the "ordered container"): the model order decides the place of every card, a drop lands at the index of the drop point, and a card the user drags — or moves with `Alt+↑/↓` — takes a new index. Moving a node can never silently change the execution order in another way.
4. **Keyboard operation:** provide a way to find and add toolbox activities without drag-and-drop. Ensure controls, panels, dialogs, and node actions have accessible names, visible focus, and predictable Enter/Space behavior.
5. **Property context and variables:** make it obvious where each supported Activity is edited, how to open its child region, and which workflow scope owns its variables. A branch surface has no variables of its own, so the variables panel resolves to the nearest enclosing scope that can hold them. Retain an explicit fallback for unsupported properties.
6. **Responsive layout (lower priority):** keep the editor usable at narrow sizes, but prioritize the large-screen workflow canvas used for diagram editing.

## Acceptance checks

- A new workflow has no implicit Sequence; adding one root Activity succeeds, a second root drop is rejected, and deleting the root allows a new one.
- The `START` cue is the same on every surface: an empty canvas draws the badge, the arrow and the drop box at the top, where a container lays out its first element, and a canvas that has a start element draws the cue on the card of that element instead. It follows its target during pan, zoom, and movement, and is never serialized or editable as an Activity.
- An empty root shows `START` and a first-activity drop hint; an unset Flowchart start is clearly indicated. The initial root activity is centered in the visible editor area, including when the editor is first rendered before its canvas dimensions are known.
- The collapsed Sequence card does not accept drops and shows no children: the chevron of the card opens and closes the list it draws, and `Open` shows the same children on a surface of their own.
- Inside a Sequence, both on the card and on its own surface: a dropped activity lands at the index of the drop point, a dragged card and `Alt+↑/↓` move an element to another index, the first and last card of a column cannot move out of it, deleting a card closes the gap, and selecting a card drawn inside a card fills the properties panel. The order survives save and reopen.
- A branch is filled only when the drop lands on it, and the branch renders the control of the activity it holds; that control can be selected to edit its properties, and a container child keeps its `Open` action, which opens it through the path. An activity that holds one activity per branch is not a container and is never opened itself. Deleting or replacing a branch child releases the model reference, and a card that grew is laid out again so it does not overlap the next card.
- On the primary large-screen layout, the design surface, toolbox, properties, variables, commands, and navigation have clear roles and do not hide essential actions.
- A user can search for and add an Activity with keyboard and pointer; empty search results are explained.
- Selection, nested navigation, and loading a workflow keep the properties panel in sync.
- A note typed in the properties panel appears on the card immediately, keeps its line breaks through save and reopen, and the card preview never exceeds three lines.
- Invalid field values produce visible feedback and can be corrected.
- An activity with a missing required argument, or holding one, is outlined in red on the diagram; selecting it lists its messages in the properties panel, and no card carries an error badge.
- Sequence and graph edits preserve their model semantics through save and reopen.
- Narrow viewport layouts remain usable without making essential navigation or actions unreachable.
- Light and dark themes retain readable text, links, ports, validation messages, and focus indicators.

## Verification and known limits

- Run the unit tests and Release Web build from the repository root; manually check the browser after restarting the host following a rebuild.
- Exercise empty, nested, graph, invalid, and large workflows on the primary large-screen layout; check narrow sizes and keyboard-only navigation as secondary coverage.
- Publish with trimming and Windows view-state interoperability have not been verified.
- Graph layout is basic and does not minimize link crossings; graph-port choice is session-only; link bends are not draggable.
- The children of a `Sequence` have no scrolling or fit action of their own: a long sequence keeps growing downwards, on its card and on its own surface, so a deep tree is reached by panning (and a deeply nested tree makes tall cards). A `bwas:Designer.CenterX`/`CenterY` left on a Sequence child by an older build stays in the file (it is ignored, not rewritten).
