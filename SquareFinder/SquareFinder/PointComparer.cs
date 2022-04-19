namespace SquareFinder;

public class PointComparer : IComparer<Point>
{
    public int Compare(Point? a, Point? b)
    {
        if (a is null && b is null) return 0;
        if (a is null) return -1;
        if (b is null) return 1;

        var yDelta = b.Y < a.Y ? 1 : b.Y == a.Y ? 0 : -1;
        var xDelta = b.X < a.X ? 1 : b.X == a.X ? 0 : -1;

        return yDelta == 0 ? xDelta : yDelta ;
    }
}