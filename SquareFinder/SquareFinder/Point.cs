namespace SquareFinder;

public class Point
{
    public Point()
    {
    }
   
    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
    public Point(Point a)
    {
        X = a.X;
        Y = a.Y;
    }

    public override string ToString()
    {
        return $"({X} ; {Y})";
    }

    public int X { get; set; }
    public int Y { get; set; }
}