using Blazor.Diagrams.Core;
using Blazor.Diagrams.Core.Anchors;
using Blazor.Diagrams.Core.Geometry;
using Blazor.Diagrams.Core.Models;
using Blazor.Diagrams.Core.Models.Base;
using Blazor.Diagrams.Core.Routers;

namespace Blazor.WorkflowEditor.Activity;

/// <summary>
/// Router of the graph surfaces: right-angled routes with rounded corners, like the classic Workflow
/// Foundation designer, laid out around the cards of the surface.
/// <para>
/// The stock <see cref="OrthogonalRouter"/> only knows the two cards a connection joins, so a route of it may
/// run straight through any other card of the surface. The corridors here are built from every card the route
/// could meet, and the route picked in them is the shortest run with the fewest bends, which is what keeps a
/// diagram readable once the user has spread the cards over the surface.
/// </para>
/// <para>
/// A route is drawn by the library on every change of the picture, including the frames of a drag, and the
/// search is kept small because only the cards inside the band a connection spans take part in it. An end
/// anchored on something other than an edge of a card — a connection still being drawn, a corner alignment the
/// stock router cannot route — has no corridor of its own, and a connection that cannot be laid out at a right
/// angle at all (an end that stands inside the card of a neighbour) is joined by a straight line instead.
/// </para>
/// </summary>
public class WorkflowRouter : Router {
    /// <summary>
    /// Distance a route keeps from every card it passes, so the line reads as a line of its own instead of lying
    /// against the border of a card. A diagram whose cards stand closer than twice this is routed with the reach
    /// of the ports alone, which is the narrowest a right-angled route can be.
    /// </summary>
    private const double Clearance = 20;

    /// <summary>Reach of the band a connection is routed in, measured around the two cards it joins.</summary>
    private const double CorridorMargin = 50;

    /// <summary>Cost of one bend in world units: a straight run is worth one extra corner at this price.</summary>
    private const double BendPenalty = 20;

    private readonly Router straight = new NormalRouter();

    public override Point[] GetRoute(Diagram diagram, BaseLinkModel link) =>
        route(diagram, link) ?? straight.GetRoute(diagram, link);

    private static Point[]? route(Diagram diagram, BaseLinkModel link) {
        if (!link.IsAttached)
            return null;

        if (link.Source is not SinglePortAnchor sourceAnchor || link.Target is not SinglePortAnchor targetAnchor)
            return null;

        if (DefaultNode.OutwardDirection(sourceAnchor.Port.Alignment) is not { } sourceDirection
            || DefaultNode.OutwardDirection(targetAnchor.Port.Alignment) is not { } targetDirection)
            return null;

        if (sourceAnchor.Port.Parent.GetBounds() is not { } sourceBox
            || targetAnchor.Port.Parent.GetBounds() is not { } targetBox)
            return null;

        //A route ends on the anchor the library uses, which sits on the outer edge of the port circle standing on
        //the border of the card; its ends are joined to those anchors by short segments that stand on the edge.
        var anchor = sourceAnchor.Port.MiddlePosition;
        var endpoint = targetAnchor.Port.MiddlePosition;

        //The roomy clearance is what the surface normally looks like. Cards that stand too close to leave room
        //for it are routed with the reach of the ports alone, which is the narrowest clearance that still leaves
        //a card at a right angle.
        foreach (var clearance in new[] { Clearance, DefaultNode.PortRadius }) {
            var start = offset(anchor, sourceDirection, clearance);
            var goal = offset(endpoint, targetDirection, clearance);

            var sourceArea = sourceBox.Inflate(clearance, clearance);
            var targetArea = targetBox.Inflate(clearance, clearance);
            var corridor = sourceArea.Union(targetArea).Inflate(CorridorMargin, CorridorMargin);

            var obstacles = new List<Rectangle> { sourceArea, targetArea };
            foreach (var node in diagram.Nodes) {
                if (ReferenceEquals(node, sourceAnchor.Port.Parent) || ReferenceEquals(node, targetAnchor.Port.Parent))
                    continue;

                //A card outside the band cannot be met by a route that stays inside it, so it is left out of the
                //search; that is what keeps the grid small on a large diagram.
                if (node.GetBounds()?.Inflate(clearance, clearance) is { } area && area.Intersects(corridor))
                    obstacles.Add(area);
            }

            //Corridors run along the borders of the cards and along the lines the two ends leave on, so every
            //route of the grid is a sequence of right angles that keeps its clearance from the cards.
            var xs = new SortedSet<double> { start.X, goal.X, corridor.Left, corridor.Right };
            var ys = new SortedSet<double> { start.Y, goal.Y, corridor.Top, corridor.Bottom };
            foreach (var obstacle in obstacles) {
                xs.Add(obstacle.Left);
                xs.Add(obstacle.Right);
                ys.Add(obstacle.Top);
                ys.Add(obstacle.Bottom);
            }

            var columns = xs.ToArray();
            var rows = ys.ToArray();

            if (shortestPath(columns, rows, obstacles, cellOf(columns, rows, start), cellOf(columns, rows, goal)) is not { } path)
                continue;

            //The two anchors are the ends of the line and are added by the library itself, so only the cells that
            //turn the run are left; its ends are the two points the anchors are joined to.
            return corners(path).ToArray();
        }

        return null;
    }

    private static (int X, int Y) cellOf(double[] columns, double[] rows, Point point) =>
        (indexOf(columns, point.X), indexOf(rows, point.Y));

    /// <summary>
    /// Index of the coordinate a value belongs to. The value is one of the coordinates — both ends are added to
    /// them — but it is looked up by distance, because a position of a card is a fraction most of the time and
    /// the equality of two doubles is not what decides which line a route starts on.
    /// </summary>
    private static int indexOf(double[] coordinates, double value) {
        var index = 0;
        for (var i = 1; i < coordinates.Length; i++) {
            if (Math.Abs(coordinates[i] - value) < Math.Abs(coordinates[index] - value))
                index = i;
        }

        return index;
    }

    private static Point offset(Point point, Point direction, double distance) =>
        point.Add(direction.X * distance, direction.Y * distance);

    /// <summary>
    /// Whether an axis-aligned run of the grid passes through a card. A run is allowed to touch the border of a
    /// card — that is how a route keeps its distance from the cards — but not to cross it, which is what keeps a
    /// route from slipping through a card whose borders are both grid lines.
    /// </summary>
    private static bool crosses(List<Rectangle> obstacles, double x1, double y1, double x2, double y2) {
        if (Math.Abs(y1 - y2) < 0.001)
            return obstacles.Any(card => y1 > card.Top && y1 < card.Bottom
                && Math.Max(x1, x2) > card.Left && Math.Min(x1, x2) < card.Right);

        if (Math.Abs(x1 - x2) < 0.001)
            return obstacles.Any(card => x1 > card.Left && x1 < card.Right
                && Math.Max(y1, y2) > card.Top && Math.Min(y1, y2) < card.Bottom);

        return true;
    }

    /// <summary>
    /// Shortest run between two cells, where a bend costs <see cref="BendPenalty"/> on top of its length, so a
    /// route that saves corners wins over a shorter one that keeps turning.
    /// </summary>
    private static List<Point>? shortestPath(double[] columns, double[] rows, List<Rectangle> obstacles,
        (int X, int Y) from, (int X, int Y) to) {
        const int noDirection = 0;
        const int horizontal = 1;
        const int vertical = 2;

        var width = columns.Length;
        var height = rows.Length;

        //A state is a cell together with the direction the route entered it from: two runs that reach the same
        //cell are only the same run when they arrive the same way, because it is the next corner that costs.
        int stateOf(int x, int y, int direction) => (x * height + y) * 3 + direction;
        int cellOf(int state) => state / 3;

        var costs = new double[width * height * 3];
        var cameFrom = new int[width * height * 3];
        Array.Fill(costs, double.PositiveInfinity);
        Array.Fill(cameFrom, -1);

        var start = stateOf(from.X, from.Y, noDirection);
        var target = to.X * height + to.Y;
        costs[start] = 0;

        var queue = new PriorityQueue<(int State, double Cost), double>();
        queue.Enqueue((start, 0), 0);

        var reached = -1;
        while (queue.Count > 0) {
            var (current, cost) = queue.Dequeue();
            if (cost > costs[current])
                continue;

            var cell = cellOf(current);
            if (cell == target) {
                reached = current;
                break;
            }

            var x = cell / height;
            var y = cell % height;
            var direction = current % 3;

            for (var step = 0; step < 4; step++) {
                var nx = x + (step == 0 ? -1 : step == 1 ? 1 : 0);
                var ny = y + (step == 2 ? -1 : step == 3 ? 1 : 0);
                if (nx < 0 || ny < 0 || nx >= width || ny >= height)
                    continue;

                if (crosses(obstacles, columns[x], rows[y], columns[nx], rows[ny]))
                    continue;

                var move = step < 2 ? horizontal : vertical;
                var length = step < 2 ? Math.Abs(columns[nx] - columns[x]) : Math.Abs(rows[ny] - rows[y]);
                var next = stateOf(nx, ny, move);
                var nextCost = cost + length + (direction != noDirection && direction != move ? BendPenalty : 0);
                if (nextCost >= costs[next])
                    continue;

                costs[next] = nextCost;
                cameFrom[next] = current;
                queue.Enqueue((next, nextCost), nextCost + remaining(columns, rows, nx, ny, to));
            }
        }

        if (reached < 0)
            return null;

        var path = new List<Point>();
        for (var state = reached; state >= 0; state = cameFrom[state]) {
            var cell = cellOf(state);
            path.Add(new Point(columns[cell / height], rows[cell % height]));
            if (state == start)
                break;
        }

        path.Reverse();
        return path;
    }

    /// <summary>Distance a cell still has to cover, which never overrates the cost of the run ahead of it.</summary>
    private static double remaining(double[] columns, double[] rows, int x, int y, (int X, int Y) to) =>
        Math.Abs(columns[x] - columns[to.X]) + Math.Abs(rows[y] - rows[to.Y]);

    /// <summary>The cells of a run that turn it, its two ends included: the ones it runs straight through add nothing.</summary>
    private static List<Point> corners(List<Point> path) {
        var result = new List<Point> { path[0] };
        for (var i = 1; i < path.Count - 1; i++) {
            var previous = result[^1];
            var next = path[i + 1];
            var straight = Math.Abs(previous.X - path[i].X) < 0.001 && Math.Abs(path[i].X - next.X) < 0.001
                || Math.Abs(previous.Y - path[i].Y) < 0.001 && Math.Abs(path[i].Y - next.Y) < 0.001;
            if (!straight)
                result.Add(path[i]);
        }

        result.Add(path[^1]);
        return result;
    }
}
