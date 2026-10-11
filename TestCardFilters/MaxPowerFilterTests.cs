using CardFilters;
using Interfaces;
using Moq;

namespace TestCardFilters;

public class MaxPowerFilterTests
{
    [Fact]
    public void DoesNotEqualObjectOfAnotherType()
    {
        // Arrange
        var filter = new MaxPowerFilter(0);

        // Act
        var actual = filter.Equals(new object());

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void DoesNotEqualFilterWithDifferentRaces()
    {
        // Arrange
        var first = new MaxPowerFilter(1000);
        var second = new MaxPowerFilter(2000);

        // Act
        var actual = first.Equals(second);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var filter = new MaxPowerFilter(0);

        // Act
        var copy = filter.Copy();

        // Assert
        Assert.Equal(filter, copy);
    }

    [Fact]
    public void HashCodesAreEqualForEqualFilters()
    {
        // Arrange
        var first = new MaxPowerFilter(0);
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
        var filter = new MaxPowerFilter(0);

        // Act
        var actual = filter.Match(Mock.Of<ICard>());

        // Assert
        Assert.False(actual);
    }

    [Theory]
    [InlineData(6000, 6001, false)]
    [InlineData(6000, 6000, true)]
    public void MatchesCreatureWithMaxPower(
        int maxPower, int creaturePower, bool expected)
    {
        // Arrange
        var filter = new MaxPowerFilter(maxPower);
        var creature = new Mock<ICreature>();
        creature.SetupGet(x => x.Power).Returns(creaturePower);

        // Act
        var actual = filter.Match(creature.Object);

        // Assert
        Assert.Equal(expected, actual);
    }
}
