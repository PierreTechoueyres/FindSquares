using FluentAssertions;
using SquareFinder;
using Xunit;

namespace SquareFinderTest;

public class PointTest
{
    [Fact]
    public void CanBuildAPoint()
    {
        var point = new Point();
        point.X.Should().Be(0);
        point.Y.Should().Be(0);

        point = new Point(-1, 2);
        point.X.Should().Be(-1);
        point.Y.Should().Be(2);
    }
}