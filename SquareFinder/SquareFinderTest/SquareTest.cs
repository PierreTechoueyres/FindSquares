using System;
using FluentAssertions;
using SquareFinder;
using Xunit;

namespace SquareFinderTest;

public class SquareTest
{
    [Fact]
    public void CanBuildASquare()
    {
        var square = new Square(new Point(-1, -1), new Point(2, 1), new Point(4, 2), new Point(1, -4));
        square.Corners.Count.Should().Be(4);
    }

    [Fact]
    public void CanGetPoints()
    {
        var square = new Square(new Point(-1, -1), new Point(2, 1), new Point(4, 2), new Point(1, -4));
        square.Corners.Count.Should().Be(4);
        square.GetPoints().Should().BeEquivalentTo(new[]
        {
            new Point(-1, -1), new Point(2, 1), new Point(4, 2), new Point(1, -4)
        });
    }

    [Fact]
    public void CanThrowExceptionWhenBuildingAnInvalidSquare()
    {
        var constructor = () =>
            new Square(new Point(-1, -1), new Point(2, 1), new Point(4, 2), new Point(4, 2));
        constructor.Should().Throw<Exception>().Which
            .Message.Should().StartWith("This isn't a square !!!");
    }
}
