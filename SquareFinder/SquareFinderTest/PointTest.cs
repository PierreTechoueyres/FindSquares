using FluentAssertions;
using SquareFinder;
using Xunit;

namespace SquareFinderTest;

public class PointTest
{
    [Fact]
    public void CanBuildADefaultPoint()
    {
        var point = new Point();
        point.X.Should().Be(0);
        point.Y.Should().Be(0);
    }

    [Fact]
    public void CanBuildAPoint()
    {
        var point = new Point(-1, 2);
        point.X.Should().Be(-1);
        point.Y.Should().Be(2);
    }

    [Fact]
    public void CanCalculatePrime()
    {
        var a = new Point(1, -4);
        var b = new Point(4, -2);

        var aa = new Point();
        var bb = new Point();

        (aa.X, aa.Y) = a.CalculatePrime(b);
        aa.X.Should().Be(-1);
        aa.Y.Should().Be(-1);

        (bb.X, bb.Y) = b.CalculatePrime(a);
        bb.X.Should().Be(2);
        bb.Y.Should().Be(1);
    }
}
