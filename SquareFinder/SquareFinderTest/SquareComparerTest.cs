using FluentAssertions;
using SquareFinder;
using Xunit;

namespace SquareFinderTest;

public class SquareComparerTest
{
    [Fact]
    public void CanCompareTwoSquare()
    {
        var square1 = new Square(new Point(-1, -1), new Point(2, 1), new Point(4, 2), new Point(1, -4));
        var square2 = new Square(new Point(-1, 1), new Point(2, 3), new Point(4, 5), new Point(1, -2));
        var comparer = new SquareComparer();

        comparer.Compare(null, null).Should().Be(0); // equality.
        comparer.Compare(null, square1).Should().Be(-1); // null is lesser than an square whatever it is.
        comparer.Compare(square1, null).Should().Be(1); // null is lesser than an square whatever it is.
        comparer.Compare(square1, square1).Should().Be(0); // equality.

        comparer.Compare(square1, square2).Should().Be(-1); // square2 < square 1.
    }
    
}