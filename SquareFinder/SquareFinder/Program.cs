using System.Linq;

namespace SquareFinder;

public static class Program
{
    private static int Main(string[] args)
    {
        if (args.Length != 1)
        {
            Console.WriteLine("Usage:");
            Console.WriteLine("dotnet run <file to load>");
            return 1;
        }
        
        var lines = File.ReadLines(args[0]);

        var squareFinder = new SquareFinder();
        squareFinder.LoadPoints(lines);
        Console.WriteLine($"List of points contains {squareFinder.Points.Count} elements.");
        // Console.WriteLine(String.Join(", ", squareFinder.Points));

        Console.WriteLine($"First / last  point {squareFinder.Points.First()}/ {squareFinder.Points.Last()}.");
        Console.WriteLine($"First / last  x {squareFinder.MinX}/ {squareFinder.MaxX}.");
        Console.WriteLine($"First / last  y {squareFinder.MinY}/ {squareFinder.MaxY}.");

        var solutions = squareFinder.FindSquares();
        Console.WriteLine($"Found {solutions.Count} !");
        // Console.WriteLine(String.Join(",\n", solutions));

        return 0;
    }
}