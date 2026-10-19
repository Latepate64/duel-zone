using CardFilters;
using Interfaces;
using Moq;

namespace TestCardFilters;

public class MinCostCreatureFilterTests
{
    [Fact]
    public void DoesNotEqualObjectOfAnotherType()
    {
        // Arrange
        var filter = new MinCostCreatureFilter(0);

        // Act
        var actual = filter.Equals(new object());

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void DoesNotEqualFilterWithDifferentRaces()
    {
        // Arrange
        var first = new MinCostCreatureFilter(1);
        var second = new MinCostCreatureFilter(2);

        // Act
        var actual = first.Equals(second);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var filter = new MinCostCreatureFilter(0);

        // Act
        var copy = filter.Copy();

        // Assert
        Assert.Equal(filter, copy);
    }

    [Fact]
    public void HashCodesAreEqualForEqualFilters()
    {
        // Arrange
        var first = new MinCostCreatureFilter(0);
        var second = first.Copy();
        var expected = second.GetHashCode();

        // Act
        var actual = first.GetHashCode();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void DoesNotMatchCard()
    {
        // Arrange
        var filter = new MinCostCreatureFilter(0);

        // Act
        var actual = filter.Match(Mock.Of<ICard>());

        // Assert
        Assert.False(actual);
    }

    [Theory]
    [InlineData(2, 2, true)]
    [InlineData(2, 1, false)]
    public void MatchesCreatureWithMinCostCreature(
        int minCost, int creatureCost, bool expected)
    {
        // Arrange
        var filter = new MinCostCreatureFilter(minCost);
        var creature = new Mock<ICreature>();
        creature.SetupGet(x => x.ManaCost).Returns(creatureCost);

        // Act
        var actual = filter.Match(creature.Object);

        // Assert
        Assert.Equal(expected, actual);
    }
}
