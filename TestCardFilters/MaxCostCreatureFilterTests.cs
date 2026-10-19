using CardFilters;
using Interfaces;
using Moq;

namespace TestCardFilters;

public class MaxCostCreatureFilterTests
{
    [Fact]
    public void DoesNotEqualObjectOfAnotherType()
    {
        // Arrange
        var filter = new MaxCostCreatureFilter(0);

        // Act
        var actual = filter.Equals(new object());

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void DoesNotEqualFilterWithDifferentRaces()
    {
        // Arrange
        var first = new MaxCostCreatureFilter(1);
        var second = new MaxCostCreatureFilter(2);

        // Act
        var actual = first.Equals(second);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var filter = new MaxCostCreatureFilter(0);

        // Act
        var copy = filter.Copy();

        // Assert
        Assert.Equal(filter, copy);
    }

    [Fact]
    public void HashCodesAreEqualForEqualFilters()
    {
        // Arrange
        var first = new MaxCostCreatureFilter(0);
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
        var filter = new MaxCostCreatureFilter(0);

        // Act
        var actual = filter.Match(Mock.Of<ICard>());

        // Assert
        Assert.False(actual);
    }

    [Theory]
    [InlineData(1, 2, false)]
    [InlineData(1, 1, true)]
    public void MatchesCreatureWithMaxCostCreature(
        int maxCost, int creatureCost, bool expected)
    {
        // Arrange
        var filter = new MaxCostCreatureFilter(maxCost);
        var creature = new Mock<ICreature>();
        creature.SetupGet(x => x.ManaCost).Returns(creatureCost);

        // Act
        var actual = filter.Match(creature.Object);

        // Assert
        Assert.Equal(expected, actual);
    }
}
