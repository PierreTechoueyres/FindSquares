namespace SquareFinder;

public class PointComparer : IComparer<Point>
{
    public int Compare(Point? a, Point? b)
    {
        if (a is null && b is null) return 0;
        if (a is null) return -1;
        if (b is null) return 1;

        var yDelta = a.Y - b.Y;
        var xDelta = a.X - b.X;

        return yDelta == 0 ? xDelta : yDelta;
    }
}
