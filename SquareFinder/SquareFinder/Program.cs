using System.IO.Abstractions;

namespace SquareFinder;

public static class Program
{
    public static IFileSystem? _fileSystem { get; set; }

    private static IFileSystem GetFileSystem()
    {
        _fileSystem ??= new FileSystem();
        return _fileSystem;
    }

    public static int Main(string[] args)
    {
        if (args.Length != 1)
        {
            Console.WriteLine("Usage:");
            Console.WriteLine("dotnet run <file to load>");
            return 1;
        }

        return FindSquares(GetFileSystem(), args[0]);
    }

    public static int FindSquares(IFileSystem fileSystem, string fileName)
    {
        if (!fileSystem.File.Exists(fileName)) return 1;
        var lines = fileSystem.File.ReadLines(fileName);

        var squareFinder = new SquareFinder();
        squareFinder.LoadPoints(lines);
        if (squareFinder.Points.Any())
        {
            Console.WriteLine($"List of points contains {squareFinder.Points.Count} elements.");
            // Console.WriteLine(String.Join(", ", squareFinder.Points));

            Console.WriteLine($"First / last  point {squareFinder.Points.First()} / {squareFinder.Points.Last()}.");
            Console.WriteLine($"First / last  x {squareFinder.MinX} / {squareFinder.MaxX}.");
            Console.WriteLine($"First / last  y {squareFinder.MinY} / {squareFinder.MaxY}.");

            var solutions = squareFinder.FindSquares();
            Console.WriteLine($"Found {solutions.Count} !");
            // Console.WriteLine(String.Join("\n", solutions));
        }

        return 0;
    }
}
