namespace SquareFinder;

public class PointComparer : IComparer<Point>
{
    public int Compare(Point? a, Point? b)
    {
        switch (a, b)
        {
            case (a: null, b: null): return 0;
            case (a: null, b: _): return -1;
            case (a: _, b: null): return 1;
            default:
                var yDelta = a.Y - b.Y;
                var xDelta = a.X - b.X;
                return yDelta == 0 ? xDelta : yDelta;
        }
    }
}
