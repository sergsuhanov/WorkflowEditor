using System.Activities;
using Blazor.Diagrams.Core.Anchors;
using Blazor.Diagrams.Core.Geometry;
using Blazor.Diagrams.Core.Models;

namespace Blazor.WorkflowEditor.Activity;

public class DefaultNode : NodeModel {
    private readonly Size defaultSize = new(250, 114);

    //    internal readonly Service service;
    public readonly Service service;
    private readonly object activity;
    private readonly System.Reflection.PropertyInfo? displayNameProperty;

    public object Element => activity;

    public string DisplayName {
        get => activity is System.Activities.Activity a
            ? a.DisplayName
            : displayNameProperty?.GetValue(activity) as string ?? activity.GetType().Name;
        set {
            if (DisplayName == value)
                return;

            if (activity is System.Activities.Activity a)
                a.DisplayName = value;
            else if (displayNameProperty?.CanWrite == true)
                displayNameProperty.SetValue(activity, value);

            service.NotifyStateChanged();
        }
    }
    public string? Comment { get; set; }
    public bool IsContainer { get; init; } = false;
    public bool IsGeneric { get; set; } = false;

    /// <summary>
    /// Whether the card shows the editor it holds instead of its compact fields. It starts closed, and the value
    /// is kept with the activity, so a card stays as the user left it when the container is opened and left, or
    /// when the schema is saved and reopened.
    /// </summary>
    private bool isExpanded;
    public bool IsExpanded {
        get => isExpanded;
        set {
            if (isExpanded == value)
                return;

            isExpanded = value;
            State.Designer.SetIsExpanded(activity, value ? true : null);
        }
    }

    /// <summary>
    /// True when the node is a child of an ordered container (Sequence). Such a node is laid out by the
    /// container in a column, so it has no ports or connections and it neither reads nor saves a position of
    /// its own.
    /// </summary>
    public bool IsStackChild { get; set; }

    /// <summary>
    /// Free-form note of this node. It is saved in XAML (attached property) and shown on the card,
    /// like the annotation of the classic Workflow Foundation designer. It is edited in the
    /// properties panel, where the editor accepts line breaks.
    /// </summary>
    public string Note {
        get => State.Designer.GetNote(activity) ?? string.Empty;
        set {
            if (string.Equals(State.Designer.GetNote(activity) ?? string.Empty, value ?? string.Empty))
                return;

            State.Designer.SetNote(activity, string.IsNullOrWhiteSpace(value) ? null : value);
            service.NotifyStateChanged();
        }
    }

    public bool HasNote => !string.IsNullOrWhiteSpace(State.Designer.GetNote(activity));

    public double? Zoom { get; set; }
    public Point? Offcet { get; set; }

    /// <summary>
    /// Center point
    /// </summary>
    public Point CenterPosition {
        get {
            if (Size != null)
                return this.Position.Add(this.Size.Width / 2.0, this.Size.Height / 2.0);
            else
                return this.Position;
        }
        set {
            if (Size != null)
                SetPosition(value.X - this.Size.Width / 2.0, value.Y - this.Size.Height / 2.0);
            else
                SetPosition(value.X, value.Y);

            //Programmatic position changes must refresh ports and link routes, otherwise links are drawn
            //using stale port positions.
            UpdatePortGeometry();
            RefreshLinks();
        }
    }

    public string CssClass {
        get {
            var result = string.Empty;
            if (base.Selected)
                result += " isSelected";
            if (this.IsContainer)
                result += " isContainer";
            if (this.IsExpanded)
                result += " isExpanded";

            return result;
        }
    }

    public PortModel IncomingPort { get; private set; }
    public PortModel OutcomingPort { get; private set; }

    /// <summary>
    /// Whether the card offers its connection points. Only the children of a graph container (Flowchart,
    /// StateMachine) are connected to each other, so only they show ports; a card anywhere else is placed by
    /// its container — the order of a Sequence, a branch of another activity — and has nothing to connect to.
    /// </summary>
    public bool ShowsPorts { get; private set; }

    private readonly PortModel leftPort = default!;
    private readonly PortModel topPort = default!;
    private readonly PortModel rightPort = default!;
    private readonly PortModel bottomPort = default!;

    public DefaultNode(Service service, object activity) : base() {
        this.service = service;
        this.activity = activity;
        this.displayNameProperty = activity.GetType().GetProperty("DisplayName");

        //A card that is recreated (leaving an opened container rebuilds the cards of its surface) takes back the
        //state the user left it in.
        this.isExpanded = State.Designer.GetIsExpanded(activity) == true;

        this.Size = defaultSize;

        topPort = this.AddPort(PortAlignment.Top);
        topPort.Locked = true;
        bottomPort = this.AddPort(PortAlignment.Bottom);
        bottomPort.Locked = true;
        leftPort = this.AddPort(PortAlignment.Left);
        leftPort.Locked = true;
        rightPort = this.AddPort(PortAlignment.Right);
        rightPort.Locked = true;

        IncomingPort = topPort;
        OutcomingPort = bottomPort;

        //The library measures the port rectangles once, in the browser, and never again: a node that is
        //moved or resized afterwards would keep its links attached to the old border point. The node box is
        //known here, so the ports are placed from it instead of from the DOM.
        this.SizeChanged += onSizeChanged;
    }

    private void onSizeChanged(NodeModel model) => UpdatePortGeometry();

    /// <summary>Radius of the round port marker. The port rectangle is a square of <c>2 * PortRadius</c>.</summary>
    private const double PortRadius = 10;

    /// <summary>
    /// Places every port so that its circle sits exactly on the node border: the link anchors of the library
    /// point at the outer edge of that circle, which is what makes a connection look attached to the card.
    /// Called whenever the node is moved or resized, and safe to call at any time.
    /// </summary>
    public void UpdatePortGeometry() {
        if (Size is not { } size)
            return;

        var right = Position.X + size.Width;
        var bottom = Position.Y + size.Height;
        var middleX = Position.X + size.Width / 2.0;
        var middleY = Position.Y + size.Height / 2.0;

        foreach (var port in Ports) {
            var center = port.Alignment switch {
                PortAlignment.Top => new Point(middleX, Position.Y),
                PortAlignment.TopRight => new Point(right, Position.Y),
                PortAlignment.Right => new Point(right, middleY),
                PortAlignment.BottomRight => new Point(right, bottom),
                PortAlignment.Bottom => new Point(middleX, bottom),
                PortAlignment.BottomLeft => new Point(Position.X, bottom),
                PortAlignment.Left => new Point(Position.X, middleY),
                PortAlignment.TopLeft => new Point(Position.X, Position.Y),
                _ => new Point(right, middleY)
            };

            port.Size = new Size(PortRadius * 2, PortRadius * 2);
            port.Position = new Point(center.X - PortRadius, center.Y - PortRadius);
            //Keep the port initialized: while it is false the library re-measures it in the DOM and would
            //overwrite the computed rectangle with a stale one.
            port.Initialized = true;
        }

        //NodeModel.RefreshLinks() only walks the links attached to the node itself, and the library attaches
        //a port-anchored link to the port, so the routes have to be rebuilt through the ports.
        foreach (var port in Ports)
            port.RefreshLinks();
    }

    public bool HasViewState => State.Designer.HasProperty(activity);

    /// <summary>
    /// Re-places the children of an opened container once the browser measured the cards, so a card that grew
    /// (an expanded node, a branch that holds an activity) does not overlap the next one.
    /// </summary>
    public virtual void RelayoutChildren() {
    }

    public bool RestoreViewState() {

        var centerX = State.Designer.GetCenterX(activity);
        var centerY = State.Designer.GetCenterY(activity);
        if (centerX != null && centerY != null)
            this.CenterPosition = new Point((double)centerX, (double)centerY);
        else if (this.service.VisibleViewport is { } view)
            this.CenterPosition = new Point(view.Left + view.Width / 2, view.Top + view.Height / 2);
        else if (this.service.DiagramContainer is { } container)
            this.CenterPosition = new Diagrams.Core.Geometry.Point(container.Width / 2, container.Height / 2);
        else
            this.CenterPosition = new Point(0, 0);
        /*
        this.viewState = Blazor.WorkflowEditor.Activity.State.Designer.Get(activity);

        if (this.viewState == null) {
            this.viewState = new();
            Blazor.WorkflowEditor.Activity.State.Designer.Set(activity, this.viewState);
        }

        if (viewState.IsEmpty()) {
            if (this.service.DiagramContainer != null)
                this.CenterPosition = new Diagrams.Core.Geometry.Point(
                    this.service.DiagramContainer!.Width / 2,
                    this.service.DiagramContainer!.Height / 2);

            return true;
        }

        //This is tempory code...

        if (viewState.CenterX.HasValue && viewState.CenterY.HasValue)
            this.CenterPosition = new Point((double)viewState.CenterX, (double)viewState.CenterY);

        if (viewState.Widht.HasValue && viewState.Height.HasValue)
            this.Size = new Size((double)viewState.Widht, (double)viewState.Height);

        if (viewState.Comment != null)
            this.Comment = viewState.Comment;

        if (viewState.IsExpanded != null)
            this.IsExpanded = viewState.IsExpanded.Value;

        if (viewState.Zoom != null)
            this.Zoom = viewState.Zoom;

        if (viewState.OffcetX.HasValue && viewState.OffcetY.HasValue)
            this.Offcet = new Point((double)viewState.OffcetX, (double)viewState.OffcetY);

        if (viewState.IncomingPortAlign != null) {
            var _incomingPort = viewState.IncomingPortAlign switch {
                State.PortAlignment.Top => topPort,
                State.PortAlignment.Left => leftPort,
                State.PortAlignment.Right => rightPort,
                State.PortAlignment.Bottom => bottomPort,
                _ => topPort
            };
            SetIncoming(_incomingPort);
        }

        if (viewState.OutcomingPortAlign != null) {
            var _outcomingPort = viewState.OutcomingPortAlign switch {
                State.PortAlignment.Top => topPort,
                State.PortAlignment.Left => leftPort,
                State.PortAlignment.Right => rightPort,
                State.PortAlignment.Bottom => bottomPort,
                _ => bottomPort
            };
            SetOutcoming(_outcomingPort);
        }
        */
        return true;
    }

    public void UpdateViewState() {
        //A card of an ordered container is placed by its index, so it has no position worth saving: writing one
        //would store a value that the next layout ignores.
        if (IsStackChild)
            return;

#pragma warning disable CS8321 // The local function 'sizeCompare' is declared but never used
        static bool sizeCompare(Blazor.Diagrams.Core.Geometry.Size sourse, Blazor.Diagrams.Core.Geometry.Size destination) =>
            Math.Abs(sourse.Width - destination.Width) < 1 && Math.Abs(sourse.Height - destination.Height) < 1;
#pragma warning restore CS8321 // The local function 'sizeCompare' is declared but never used

        State.Designer.SetCenterX(activity, (int?)this.CenterPosition.X);
        State.Designer.SetCenterY(activity, (int?)this.CenterPosition.Y);

        /*
        if (this.Size != null && sizeCompare(this.Size, this.defaultSize) == false) {
            this.viewState.Widht = (int)this.Size.Width;
            this.viewState.Height = (int)this.Size.Height;
        } else {
            this.viewState.Widht = null;
            this.viewState.Height = null;
        }

        this.viewState.Comment = this.Comment;
        this.viewState.IsExpanded = this.IsExpanded ? true : null;

        this.viewState.IncomingPortAlign = this.IncomingPort.Alignment switch {
            PortAlignment.Top => State.PortAlignment.Top,
            PortAlignment.Left => State.PortAlignment.Left,
            PortAlignment.Right => State.PortAlignment.Right,
            PortAlignment.Bottom => State.PortAlignment.Bottom,
            _ => State.PortAlignment.Top
        };
        this.viewState.OutcomingPortAlign = this.OutcomingPort.Alignment switch {
            PortAlignment.Top => State.PortAlignment.Top,
            PortAlignment.Left => State.PortAlignment.Left,
            PortAlignment.Right => State.PortAlignment.Right,
            PortAlignment.Bottom => State.PortAlignment.Bottom,
            _ => State.PortAlignment.Top
        };

        this.viewState.Zoom = Zoom;

        if (this.Offcet != null) {
            this.viewState.OffcetX = (int)this.Offcet.X;
            this.viewState.OffcetY = (int)this.Offcet.Y;
        } else {
            this.viewState.OffcetX = null;
            this.viewState.OffcetY = null;
        }
        */
    }

    public void SetOutcoming(PortModel port) {
        if (this.OutcomingPort == port)
            return;
        var links = this.PortLinks.Where(p => p.SourcePort() == this.OutcomingPort).ToList();
        this.OutcomingPort = port;
        links.ForEach(p => p.SetSource(new SinglePortAnchor(this.OutcomingPort)));
        this.RefreshAll();
    }

    public void SetIncoming(PortModel port) {
        if (this.IncomingPort == port)
            return;
        var links = this.PortLinks.Where(p => p.TargetPort() == this.IncomingPort).ToList();
        this.IncomingPort = port;
        links.ForEach(p => p.SetTarget(new SinglePortAnchor(this.IncomingPort)));
        this.RefreshAll();
    }

    protected IEnumerable<Variable> GetVariables(IEnumerable<System.Activities.Variable> source) {
        var result = new List<Variable>();
        foreach (var property in source) {
            Variable variable = new() {
                Activity = (System.Activities.Activity)activity,
                Name = property.Name,
                Type = property.Type,
                DefaultValue = property.Default
            };
            result.Add(variable);
        }
        return result;
    }

    protected IEnumerable<Variable> GetVariables(IEnumerable<DynamicActivityProperty> source) {
        var result = new List<Variable>();
        foreach (var property in source) {
            Variable variable = new() {
                Activity = (System.Activities.Activity)activity,
                Name = property.Name,
                Type = property.Type,
                DefaultValue = property.Value
            };
            result.Add(variable);
        }
        return result;
    }

    public virtual IEnumerable<Variable> GetVariables() {
        return Enumerable.Empty<Variable>();
    }

    public virtual void LoadChilds(Func<System.Activities.Activity, ActivityDesignerPair> addActivity) {

    }
    /// <summary>
    /// Lays out a row of nodes inside the currently visible part of the diagram (pan/zoom aware).
    /// </summary>
    protected void ArrangeRow(IReadOnlyList<ActivityDesignerPair> pairs, int startIndex = 0) {
        if (pairs.Count == 0)
            return;

        var view = service.VisibleViewport;
        var left = view?.Left ?? 0;
        var top = view?.Top ?? 0;
        var viewHeight = view?.Height ?? 0;
        var rowY = viewHeight > 0 ? top + Math.Max(60, viewHeight * 0.4) : 150;
        var step = (pairs[0].Node.Size?.Width ?? 250) + 72;

        for (var i = 0; i < pairs.Count; i++) {
            var node = pairs[i].Node;
            if (node.HasViewState && startIndex == 0)
                continue;
            var width = node.Size?.Width ?? 250;
            node.CenterPosition = new Point(left + 24 + width / 2 + (startIndex + i) * step, rowY);
            node.UpdateViewState();
        }
    }

    public virtual void AddChild(ActivityDesignerPair source) {

    }
    public virtual void RemoveChild(System.Activities.Activity child) {

    }

    /// <summary>Loads child elements, including non-activity ones. By default only activity children are loaded.</summary>
    public virtual void LoadElements(Func<object, ActivityDesignerPair> addElement) => LoadChilds(a => addElement(a));

    /// <summary>Removes a child element (activity or not) from the model.</summary>
    public virtual void RemoveElement(object child) {
        if (child is System.Activities.Activity a)
            RemoveChild(a);
    }

    /// <summary>
    /// Elements this node renders inside its own card, in order (the children of an ordered container that is
    /// shown as a card). They are not nodes of the diagram: the card draws their controls itself, so they can be
    /// edited, added and reordered without opening the container on a surface of its own. Empty for every other
    /// node.
    /// </summary>
    public virtual IReadOnlyList<object> InlineChildren => Array.Empty<object>();

    /// <summary>
    /// Single-activity slots of this node (If branches, loop body, catch handlers, switch cases). The card
    /// renders the activity of each slot itself, so such a node returns no slots from <see cref="LoadElements"/>.
    /// Containers (Sequence, Parallel) hold several children at once and return none.
    /// </summary>
    public virtual IReadOnlyList<IActivityHolder> Slots => Array.Empty<IActivityHolder>();

    /// <summary>
    /// True when the node is rendered inside a branch region of another card instead of being a node of the
    /// diagram itself. Such a node has no ports and is selected by clicking its card.
    /// </summary>
    public bool IsEmbedded { get; set; }

    /// <summary>The node whose branch region renders this embedded node, if any.</summary>
    public DefaultNode? EmbeddedOwner { get; set; }

    /// <summary>Whether this container accepts a child of the given activity or element type.</summary>
    public virtual bool CanAdd(Type elementType) => typeof(System.Activities.Activity).IsAssignableFrom(elementType);

    /// <summary>
    /// Hint drawn on the canvas while this container is open and holds nothing yet, or null when the
    /// container needs no hint: it either has children or draws a cue of its own.
    /// </summary>
    public virtual string? EmptyHint => null;

    /// <summary>Extra CSS class for the collapsed node card, used by nodes with an inline region designer.</summary>
    public virtual string NodeLayoutClass => string.Empty;

    /// <summary>
    /// Replaces the four default ports with the directional set used by graph containers: incoming ports on
    /// the left and top edges, outgoing ports on the right and bottom edges. One anchor per side gives a
    /// choice of connection point while drawing without using the corner alignments, which the orthogonal
    /// router cannot handle. A node that is laid out by a graph container is the only one that shows ports:
    /// the mode where the user connects elements to each other exists only there.
    /// </summary>
    public void UseGraphPorts() {
        ShowsPorts = true;

        if (Ports.Count == 4 && Ports.All(p => p is GraphInPort or GraphOutPort))
            return;

        foreach (var port in Ports.ToList())
            RemovePort(port);

        //Incoming: the left edge is the canonical anchor, the top edge takes vertical neighbours.
        SetIncoming(AddPort(new GraphInPort(this, PortAlignment.Left)));
        AddPort(new GraphInPort(this, PortAlignment.Top));

        //Outgoing: the right edge is the canonical anchor, the bottom edge is the second choice.
        SetOutcoming(AddPort(new GraphOutPort(this, PortAlignment.Right)));
        AddPort(new GraphOutPort(this, PortAlignment.Bottom));

        UpdatePortGeometry();
    }

    /// <summary>Deletes a child activity, removing its diagram node when it is currently shown.</summary>
    public void RemoveChildEverywhere(System.Activities.Activity child) {
        var pair = service.FindPair(child);
        if (pair != null)
            service.Delete(pair.Node);

        //The node cleanup above removes the child from the surface it was shown on, which is not necessarily
        //this node, so the model reference is released here as well.
        RemoveChild(child);
    }

    /// <summary>Removes the current child of a single-slot region before a newly dropped one replaces it.</summary>
    protected void ReplaceChild(System.Activities.Activity? existing, ActivityDesignerPair child) {
        if (existing != null && !ReferenceEquals(existing, child.Activity))
            RemoveChildEverywhere(existing);
    }

}
