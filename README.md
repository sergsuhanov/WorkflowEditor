# WorkflowEditor

Experimental Windows Workflow Foundation editor. The repository contains a legacy Windows application and a browser-based editor; current development targets the Web editor.

## Run the Web editor

From the repository root:

```sh
dotnet run --project WorkflowEditor.Web/WorkflowEditor.Web.csproj --urls http://localhost:5199
```

After rebuilding, stop and restart the host before checking the browser at <http://localhost:5199>.

## Current Web capabilities

The toolbox includes stack activities (`Sequence`, `Assign`, `WriteLine`, `Delay`, `If`, `While`, `DoWhile`, `ForEach<T>`, `Parallel`, `TryCatch`, `Switch<T>`, and collection activities), plus `Flowchart` and `StateMachine` editors. XAML can be opened, edited, validated, and saved. Validation reports every error and warning with the name of the argument each one belongs to. Unsupported loaded activities use a generic display-name editor.

While a schema has unsaved changes, the editor keeps a draft of it in the browser (not on any server), asks before a reload or a close, and offers that draft back when the page is opened again. The draft is dropped once the workflow is saved or another one is opened.

Edits can be taken back and applied again with `Ctrl+Z` and `Ctrl+Y` (`Ctrl+Shift+Z`), or with the undo and redo commands of the toolbar.

See [docs/WORK_PLAN.md](docs/WORK_PLAN.md) for implementation rules and coverage, and [docs/VISUAL_EDITOR_PLAN.md](docs/VISUAL_EDITOR_PLAN.md) for the active UX backlog.

## Verify

The Web graph is built through the solution filter, because `trunk.sln` also holds the legacy projects that target .NET Framework 4.7.2 and only build on Windows:

```sh
dotnet test Blazor.WorkflowEditor.Tests/Blazor.WorkflowEditor.Tests.csproj -c Release
dotnet build web.slnf -c Release
```

Do not change `WorkflowEditor.Win` or `glassPeople`.
