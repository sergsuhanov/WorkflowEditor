namespace Blazor.WorkflowEditor;

public class ToolBoxGroup {
    public string Name { get; set; } = "DefaultGroupName";
    public string? Description { get; set; }

    /// <summary>
    /// State in toolbox component
    /// </summary>
    public bool Collapsed { get; set; }

    public List<ToolBoxItem> Items { get; set; } = new();

    public void Add<T>(string? imageToolbox = null) where T : System.Activities.Activity {
        Add(typeof(T), imageToolbox);
    }

    public void Add(Type type, string? imageToolbox = null) {
        var ti = new ToolBoxItem {
            Name = displayName(type),
            Image = imageToolbox ?? ActivityIcon.CssClass(type),
            TypeOfActivity = type
        };
        Items.Add(ti);
    }

    private static string displayName(Type type) {
        var name = type.Name;
        var tick = name.IndexOf('`');
        if (tick < 0)
            return name;

        name = name[..tick];
        if (type.IsGenericTypeDefinition) {
            var parameters = type.GetGenericArguments().Select(a => a.Name);
            return $"{name}<{string.Join(", ", parameters)}>";
        }
        return name;
    }
}

