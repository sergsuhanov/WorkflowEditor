using System.Xaml;

namespace Blazor.WorkflowEditor.Activity.State;

public static class Designer {
    //public static readonly AttachableMemberIdentifier ViewStateIdentifier = new(typeof(Designer), "ViewState");
    //public static ViewState Get(object target) {
    //    AttachablePropertyServices.TryGetProperty<ViewState>(target, ViewStateIdentifier, out var value);
    //    return value;
    //}
    //public static void Set(object target, ViewState value) {
    //    AttachablePropertyServices.SetProperty(target, ViewStateIdentifier, value);
    //}

    static T? getValue<T>(object target, AttachableMemberIdentifier propery) {
        return AttachablePropertyServices.TryGetProperty<T>(target, propery, out var v) ? v : default;
    }

    static void setValue<T>(object target, AttachableMemberIdentifier propery, T value) {
        if (value is not null)
            AttachablePropertyServices.SetProperty(target, propery, value);
        else
            AttachablePropertyServices.RemoveProperty(target, propery);
    }

    public static bool HasProperty(object target) =>
        AttachablePropertyServices.GetAttachedPropertyCount(target) > 0;

    #region CenterX
    public static readonly AttachableMemberIdentifier CenterXProperty = new(typeof(Designer), "CenterX");
    public static int? GetCenterX(object target) => getValue<int?>(target, CenterXProperty);
    public static void SetCenterX(object target, int? value) => setValue(target, CenterXProperty, value);
    #endregion

    #region CenterY
    public static readonly AttachableMemberIdentifier CenterYProperty = new(typeof(Designer), "CenterY");
    public static int? GetCenterY(object target) => getValue<int?>(target, CenterYProperty);
    public static void SetCenterY(object target, int? value) => setValue(target, CenterYProperty, value);
    #endregion

    #region Note
    /// <summary>Free-form designer note; stored in XAML next to the activity (like the WF annotation).</summary>
    public static readonly AttachableMemberIdentifier NoteProperty = new(typeof(Designer), "Note");
    public static string? GetNote(object target) => getValue<string>(target, NoteProperty);
    public static void SetNote(object target, string? value) => setValue(target, NoteProperty, value);
    #endregion

    #region IsExpanded
    /// <summary>
    /// Whether the card of the activity shows the editor it holds instead of its compact fields. Stored with the
    /// activity, so the card keeps its state while the user moves between the container and its surface, and
    /// across save and reopen. A collapsed card keeps no value.
    /// </summary>
    public static readonly AttachableMemberIdentifier IsExpandedProperty = new(typeof(Designer), "IsExpanded");
    public static bool? GetIsExpanded(object target) => getValue<bool?>(target, IsExpandedProperty);
    public static void SetIsExpanded(object target, bool? value) => setValue(target, IsExpandedProperty, value);
    #endregion

    #region BranchEdges
    /// <summary>
    /// Places a connection of a graph surface leaves and arrives at, keyed by the connection itself (`next`,
    /// `True`, `False`, `default`, a switch case). A connection is drawn from the point of the edge its branch
    /// belongs to and to the point that faces the card it joins, and a user who drags one of its ends onto
    /// another point of a card keeps that choice here, so a schema that is saved and opened again draws the line
    /// exactly where it was left.
    /// <para>The value is a compact list, `True=Left@0.5>Top@0.25;False=Right@0.5`, so it stays readable in the
    /// file; it is read and written through <see cref="BranchPorts"/>.</para>
    /// </summary>
    public static readonly AttachableMemberIdentifier BranchPortsProperty = new(typeof(Designer), "BranchPorts");
    public static string? GetBranchPorts(object target) => getValue<string>(target, BranchPortsProperty);
    public static void SetBranchPorts(object target, string? value) => setValue(target, BranchPortsProperty, value);
    #endregion

}

/// <summary>
/// The points a user picked for the connections of a graph surface, kept on the element each connection leaves
/// from: a connection is otherwise drawn from the edge its branch belongs to and to the edge that faces the card
/// it joins, and this is what makes a hand-picked point outlive a save and a reload.
/// </summary>
public static class BranchPorts {
    /// <summary>Points the user picked for a connection, or null when it keeps the points the model asks for.</summary>
    public static (PortPlace Source, PortPlace Target)? Get(object activity, string key) {
        var places = parse(Designer.GetBranchPorts(activity));
        return places.TryGetValue(key, out var found) ? found : null;
    }

    /// <summary>Keeps the points the user picked for a connection with the element that owns the connection.</summary>
    public static void Set(object activity, string key, PortPlace source, PortPlace target) {
        var places = parse(Designer.GetBranchPorts(activity));
        places[key] = (source, target);
        Designer.SetBranchPorts(activity, string.Join(';', places.Select(place =>
            $"{escape(place.Key)}={place.Value.Source}>{place.Value.Target}")));
    }

    private static Dictionary<string, (PortPlace Source, PortPlace Target)> parse(string? value) {
        var result = new Dictionary<string, (PortPlace Source, PortPlace Target)>();
        if (string.IsNullOrWhiteSpace(value))
            return result;

        foreach (var entry in value.Split(';', StringSplitOptions.RemoveEmptyEntries)) {
            var separator = entry.IndexOf('=');
            if (separator <= 0)
                continue;

            var ends = entry[(separator + 1)..].Split('>');
            if (PortPlace.Parse(ends[0]) is not { } source)
                continue;

            var target = ends.Length > 1 && PortPlace.Parse(ends[1]) is { } parsed ? parsed : source;
            result[unescape(entry[..separator])] = (source, target);
        }

        return result;
    }

    /// <summary>Escapes the separators of a key, so a key that carries one stays a single key.</summary>
    private static string escape(string key) => key
        .Replace("%", "%25").Replace(";", "%3B").Replace("=", "%3D").Replace(">", "%3E");

    private static string unescape(string key) => key
        .Replace("%3E", ">").Replace("%3D", "=").Replace("%3B", ";").Replace("%25", "%");
}

public enum PortAlignment {
    Top = 0,
    TopRight = 1,
    Right = 2,
    BottomRight = 3,
    Bottom = 4,
    BottomLeft = 5,
    Left = 6,
    TopLeft = 7
}

/*
public class ViewState {

    //public static readonly AttachableMemberIdentifier CenterXProperty = new(typeof(ViewState), "CenterX");
    //public static int? GetCenterX(object target) =>
    //     AttachablePropertyServices.TryGetProperty<int?>(target, CenterXProperty, out var v) ? v : null;
    //public static void SetCenterX(object target, int? centerX) =>
    //     AttachablePropertyServices.SetProperty(target, CenterXProperty, centerX);


    public int? CenterX { get; set; }
    public int? CenterY { get; set; }
    public int? Widht { get; set; }
    public int? Height { get; set; }
    public int? OffcetX { get; set; }
    public int? OffcetY { get; set; }
    public string? Comment { get; set; }
    public bool? IsExpanded { get; set; }
    public double? Zoom { get; set; }
    public PortAlignment? IncomingPortAlign { get; set; }
    public PortAlignment? OutcomingPortAlign { get; set; }

    public bool IsEmpty() {
        return CenterX == null && CenterY == null &&
            Widht == null && Height == null &&
            Comment == null &&
            IsExpanded == null &&
            Zoom == null &&
            OffcetX == null && OffcetY == null &&
            IncomingPortAlign == null &&
            OutcomingPortAlign == null;
    }

}
*/
