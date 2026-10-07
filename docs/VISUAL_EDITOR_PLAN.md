# Web editor UX instructions

Keep the browser editor understandable, keyboard-accessible, and reliable for creating, opening, editing, validating, and saving WF workflows.

## Scope

- Apply UX changes to `WorkflowEditor.Web` and its required Web projects only.
- Do not change or migrate `WorkflowEditor.Win` or `glassPeople`.
- Keep this file to current behavior, open UX work, acceptance checks, and known limitations. Do not add implementation diaries or closed-step logs.
- Activity coverage and code patterns belong in [WORK_PLAN.md](WORK_PLAN.md).

## Already implemented

- New workflow on first load; toolbox grouped by control flow, primitives, collections, flowchart, and state machine.
- Resizable/collapsible toolbox, variables, and properties panels; diagram zoom controls include reset and fit.
- Nested stack regions, Flowchart and StateMachine editing, directional connections, validation feedback, notes, dirty-state confirmation, and XAML open/save.
- Light/dark theme toggle persisted in `localStorage`.
- Properties panel supports display name plus focused editors for Assign, WriteLine, Delay, If, While, and AddToCollection. Dedicated node editors cover additional activities; unsupported types show a clear fallback.

## Active UX priorities

1. **Responsive layout:** keep toolbox, diagram, breadcrumb, variables, and properties usable at narrow and wide viewport sizes. Define a compact panel mode that does not hide essential navigation or actions.
2. **Keyboard operation:** provide a way to find and add toolbox activities without drag-and-drop. Ensure controls, panels, dialogs, and node actions have accessible names, visible focus, and predictable Enter/Space behavior.
3. **Sequence editing:** make insertion and reordering behavior explicit. Moving a node must not silently change execution order; test insert, reorder, delete, and XAML round-trip.
4. **Property context:** make it obvious where each supported Activity is edited and how to open its child region. Extend the properties panel only when it avoids conflicting duplicate editors; retain an explicit fallback for unsupported properties.
5. **Variables:** show which workflow scope owns the variables and keep add, edit, and remove actions understandable when navigating nested containers.

## Acceptance checks

- At narrow and wide viewport sizes, panels do not cover the diagram or make key actions unreachable.
- A user can search for and add an Activity with keyboard and pointer; empty search results are explained.
- Selection, nested navigation, and loading a workflow keep the properties panel in sync.
- Invalid field values produce visible feedback and can be corrected.
- Sequence and graph edits preserve their model semantics through save and reopen.
- Light and dark themes retain readable text, links, ports, validation messages, and focus indicators.

## Verification and known limits

- Run the unit tests and Release Web build from the repository root; manually check the browser after restarting the host following a rebuild.
- Exercise empty, nested, graph, invalid, and large workflows at narrow and wide sizes, including keyboard-only navigation.
- Publish with trimming and Windows view-state interoperability have not been verified.
- Graph layout is basic and does not minimize link crossings; graph-port choice is session-only; link bends are not draggable.
