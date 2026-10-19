using CardFilters;
using Interfaces;
using Moq;

namespace TestCardFilters;

public class MinPowerFilterTests
{
    [Fact]
    public void DoesNotEqualObjectOfAnotherType()
    {
        // Arrange
        var filter = new MinPowerFilter(0);

        // Act
        var actual = filter.Equals(new object());

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void DoesNotEqualFilterWithDifferentPowers()
    {
        // Arrange
        var first = new MinPowerFilter(1000);
        var second = new MinPowerFilter(2000);

        // Act
        var actual = first.Equals(second);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var filter = new MinPowerFilter(0);

        // Act
        var copy = filter.Copy();

        // Assert
        Assert.Equal(filter, copy);
    }

    [Fact]
    public void HashCodesAreEqualForEqualFilters()
    {
        // Arrange
        var first = new MinPowerFilter(0);
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
        var filter = new MinPowerFilter(0);

        // Act
        var actual = filter.Match(Mock.Of<ICard>());

        // Assert
        Assert.False(actual);
    }

    [Theory]
    [InlineData(6000, 6000, true)]
    [InlineData(6000, 5999, false)]
    public void MatchesCreatureWithMinPower(
        int minPower, int creaturePower, bool expected)
    {
        // Arrange
        var filter = new MinPowerFilter(minPower);
        var creature = new Mock<ICreature>();
        creature.SetupGet(x => x.Power).Returns(creaturePower);

        // Act
        var actual = filter.Match(creature.Object);

        // Assert
        Assert.Equal(expected, actual);
    }
}
