# WorkflowEditor

Experimental Windows Workflow Foundation editor. The repository contains a legacy Windows application and a browser-based editor; current development targets the Web editor.

## Run the Web editor

From the repository root:

```sh
dotnet run --project WorkflowEditor.Web/WorkflowEditor.Web.csproj --urls http://localhost:5199
```

After rebuilding, stop and restart the host before checking the browser at <http://localhost:5199>.

## Current Web capabilities

The toolbox includes stack activities (`Sequence`, `Assign`, `WriteLine`, `Delay`, `If`, `While`, `DoWhile`, `ForEach<T>`, `Parallel`, `TryCatch`, `Switch<T>`, and collection activities), plus `Flowchart` and `StateMachine` editors. XAML can be opened, edited, validated, and saved. Unsupported loaded activities use a generic display-name editor.

See [docs/WORK_PLAN.md](docs/WORK_PLAN.md) for implementation rules and coverage, and [docs/VISUAL_EDITOR_PLAN.md](docs/VISUAL_EDITOR_PLAN.md) for the active UX backlog.

## Verify

```sh
dotnet test Blazor.WorkflowEditor.Tests/Blazor.WorkflowEditor.Tests.csproj -c Release
dotnet build WorkflowEditor.Web/WorkflowEditor.Web.csproj -c Release
```

Do not change `WorkflowEditor.Win` or `glassPeople`.
