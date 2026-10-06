using System.Activities;
using System.Activities.XamlIntegration;
using System.Text;
using System.Xaml;

namespace Blazor.WorkflowEditor;

public static class WorkflowXamlSerializer {
    public static ActivityBuilder LoadBuilder(string source) {
        if (string.IsNullOrWhiteSpace(source))
            throw new ArgumentException("Workflow XAML cannot be empty.", nameof(source));

        using var reader = new StringReader(source.TrimStart('\uFEFF', ' ', '\t', '\r', '\n'));
        using var xamlReader = new XamlXmlReader(reader);
        using var builderReader = ActivityXamlServices.CreateBuilderReader(xamlReader);
        return XamlServices.Load(builderReader) switch {
            ActivityBuilder builder => builder,
            System.Activities.Activity activity => new ActivityBuilder { Implementation = activity },
            _ => throw new NotSupportedException("The XAML document does not contain a workflow activity.")
        };
    }

    public static string SaveBuilder(ActivityBuilder builder) {
        ArgumentNullException.ThrowIfNull(builder);

        var output = new StringBuilder();
        using var textWriter = new StringWriter(output);
        using var xamlWriter = new XamlXmlWriter(textWriter, new XamlSchemaContext());
        using var writer = ActivityXamlServices.CreateBuilderWriter(
            xamlWriter);
        XamlServices.Save(writer, builder);
        return output.ToString();
    }
}
