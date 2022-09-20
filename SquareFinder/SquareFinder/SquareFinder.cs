namespace SquareFinder;

public class SquareFinder
{
    public SortedSet<Point> Points { get; } = new(new PointComparer());
    public int MinX { get; private set; }
    public int MaxX { get; private set; }
    public int MinY { get; private set; }
    public int MaxY { get; private set; }

    public void LoadPoints(IEnumerable<string> lines)
    {
        Points.Clear();

        foreach (var line in lines)
        {
            var elements = line.Split(" ");
            if (elements.Length >= 2
                && int.TryParse(elements[0], out var x)
                && int.TryParse(elements[1], out var y))
            {
                MinX = MinX < x ? MinX : x;
                MaxX = MaxX > x ? MaxX : x;
                MinY = MinY < x ? MinY : y;
                MaxY = MaxY > x ? MaxY : y;

                var point = new Point(x, y);
                if (!Points.Contains(point))
                    Points.Add(point);
            }
        }
    }

    public HashSet<Square> FindSquares()
    {
        var aIndex = 0;
        var orderedPoints = Points.ToArray();

        // var solutions = new SortedSet<Square>(new SquareComparer());
        var solutions = new HashSet<Square>();

        foreach (var cornerA in Points)
        {
            ++aIndex;
            var cornerAPrime = new Point();
            var cornerBPrime = new Point();

            for (var bIndex = aIndex; bIndex < orderedPoints.Length; bIndex++)
            {
                var cornerB = orderedPoints[bIndex];

                if (cornerA.X >= cornerB.X) continue;

                cornerAPrime.X = cornerA.X - (cornerB.Y - cornerA.Y);
                cornerAPrime.Y = cornerA.Y + (cornerB.X - cornerA.X);

                cornerBPrime.X = cornerB.X - (cornerB.Y - cornerA.Y);
                cornerBPrime.Y = cornerB.Y + (cornerB.X - cornerA.X);

                if (!Points.Contains(cornerAPrime)) continue;
                if (!Points.Contains(cornerBPrime)) continue;

                var square = new Square(cornerA, cornerB, cornerAPrime, cornerBPrime);
                solutions.Add(square);
            }
        }

        return solutions;
    }
}
