namespace SquareFinder;

public class SquareComparer : IComparer<Square>
{
    private readonly PointComparer _comparer = new();

    public int Compare(Square? x, Square? y)
    {
        if (x is null && y is null) return 0;
        if (x is null) return -1;
        if (y is null) return 1;

        var xCorners = x.Corners.ToArray();
        var yCorners = y.Corners.ToArray();

        for (var i = 0; i < xCorners.Length; i++)
        {
            var result = _comparer.Compare(xCorners[i], yCorners[i]);
            if (result != 0) return result;
        }

        return 0;
    }
}
