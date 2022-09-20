using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace SquareFinderTest;

public class SquareFinderTest
{
    [Fact]
    public void CanLoadPointsWithEmptyList()
    {
        var inputString = Array.Empty<string>();
        var squareFinder = new SquareFinder.SquareFinder();
        squareFinder.LoadPoints(inputString);
        squareFinder.Points.Count.Should().Be(0);
    }

    [Fact]
    public void CanLoadPoints()
    {
        var inputString = new List<string> { "-1 -1", "2 1", "4 -2", "1 -4" };

        var squareFinder = new SquareFinder.SquareFinder();
        squareFinder.LoadPoints(inputString);
        squareFinder.Points.Count.Should().Be(4);
        string.Join(", ", squareFinder.Points).Should().Be("(1, -4), (4, -2), (-1, -1), (2, 1)");
    }

    [Fact]
    public void CanFindSquare()
    {
        var inputString = new List<string> { "-1 -1", "2 1", "4 -2", "1 -4" };
        var squareFinder = new SquareFinder.SquareFinder();
        squareFinder.LoadPoints(inputString);

        var solutions = squareFinder.FindSquares();
        solutions.Should().HaveCount(1);
        var result = string.Join(",", solutions);
        result.Should().Be("(1, -4) (4, -2) (2, 1) (-1, -1)");
    }

    [Fact]
    public void CouldNotFindSquare()
    {
        var inputString = new List<string> { "-1 -1", "2 2", "4 -2", "1 -4" };
        var squareFinder = new SquareFinder.SquareFinder();
        squareFinder.LoadPoints(inputString);

        var solutions = squareFinder.FindSquares();
        solutions.Should().HaveCount(0);
    }

    [Fact]
    public void CouldFindMoreSquare()
    {
        var inputString = new List<string>
        {
            "1 3", "2 3",
            "0 2", "1 2", "2 2", "3 2",
            "0 1", "1 1", "2 1", "3 1",
            "1 0", "2 0"
        };
        var squareFinder = new SquareFinder.SquareFinder();
        squareFinder.LoadPoints(inputString);

        var solutions = squareFinder.FindSquares();
        solutions.Should().HaveCount(11);
    }
}
