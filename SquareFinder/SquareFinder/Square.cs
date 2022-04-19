namespace SquareFinder;

public class Square
{
    public SortedSet<Point> Corners { get; } = new (new PointComparer());

    public Square(Point a, Point b, Point c, Point d)
    {
        Corners.Add(new Point(a));
        Corners.Add(new Point(b));
        Corners.Add(new Point(c));
        Corners.Add(new Point(d));

        if (Corners.Count != 4)
        {
            var message = "This isn't a square !!!\n";
            message += $"a: ({a.X} ; {a.Y}), ";
            message += $"b: ({b.X} ; {b.Y}), ";
            message += $"c: ({c.X} ; {c.Y}), ";
            message += $"d: ({d.X} ; {d.Y})";
            throw new Exception(message);
                
        }
    }

    public override string ToString()
    {
        return string.Join("; ", Corners);
    }
}