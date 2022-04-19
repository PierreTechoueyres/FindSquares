using FluentAssertions;
using SquareFinder;
using Xunit;

namespace SquareFinderTest;

public class PointComparerTest
{
   
    [Fact]
    public void CanCompareTwoPoints()
    {
        var point1 = new Point(-1, -1);
        var point2 = new Point(-1, 2);
        var comparer = new PointComparer();

        comparer.Compare(null, null).Should().Be(0);
        comparer.Compare(null, point1).Should().Be(-1);
        comparer.Compare(point1, null).Should().Be(1);
        comparer.Compare(point1, point1).Should().Be(0);

        comparer.Compare(point1, point2).Should().Be(-1);
    }
  
}