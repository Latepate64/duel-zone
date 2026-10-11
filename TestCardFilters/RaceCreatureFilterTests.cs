using CardFilters;
using Interfaces;
using Moq;

namespace TestCardFilters;

public class RaceCreatureFilterTests
{
    [Fact]
    public void DoesNotEqualObjectOfAnotherType()
    {
        // Arrange
        var filter = new RaceCreatureFilter();

        // Act
        var actual = filter.Equals(new object());

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void DoesNotEqualFilterWithDifferentRaces()
    {
        // Arrange
        var first = new RaceCreatureFilter(Race.AngelCommand);
        var second = new RaceCreatureFilter(Race.DemonCommand);

        // Act
        var actual = first.Equals(second);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var filter = new RaceCreatureFilter();

        // Act
        var copy = filter.Copy();

        // Assert
        Assert.Equal(filter, copy);
    }

    [Fact]
    public void HashCodesAreEqualForEqualFilters()
    {
        // Arrange
        var first = new RaceCreatureFilter(Race.AngelCommand);
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
        var filter = new RaceCreatureFilter(Race.AngelCommand);

        // Act
        var actual = filter.Match(Mock.Of<ICard>());

        // Assert
        Assert.False(actual);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void MatchesCreatureWithMatchingRace(
        bool creatureHasMatchingRace)
    {
        // Arrange
        var filter = new RaceCreatureFilter(Race.AngelCommand);
        var creature = new Mock<ICreature>();
        creature.Setup(x => x.HasRace(Race.AngelCommand)).Returns(
            creatureHasMatchingRace);

        // Act
        var actual = filter.Match(creature.Object);

        // Assert
        Assert.Equal(creatureHasMatchingRace, actual);
    }
}
