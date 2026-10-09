using CardFilters;
using Interfaces;
using Moq;

namespace TestCardFilters;

public class CivilizationCreatureFilterTests
{
    [Fact]
    public void DoesNotEqualObjectOfAnotherType()
    {
        // Arrange
        var filter = new CivilizationCreatureFilter();

        // Act
        var actual = filter.Equals(new object());

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void DoesNotEqualFilterWithDifferentCivilizations()
    {
        // Arrange
        var first = new CivilizationCreatureFilter(Civilization.Light);
        var second = new CivilizationCreatureFilter(Civilization.Water);

        // Act
        var actual = first.Equals(second);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var filter = new CivilizationCreatureFilter();

        // Act
        var copy = filter.Copy();

        // Assert
        Assert.Equal(filter, copy);
    }

    [Fact]
    public void HashCodesAreEqualForEqualFilters()
    {
        // Arrange
        var first = new CivilizationCreatureFilter(Civilization.Light);
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
        var filter = new CivilizationCreatureFilter(Civilization.Light);

        // Act
        var actual = filter.Match(Mock.Of<ICard>());

        // Assert
        Assert.False(actual);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void MatchesCreatureWithMatchingCivilization(
        bool creatureHasMatchingCivilization)
    {
        // Arrange
        var filter = new CivilizationCreatureFilter(Civilization.Light);
        var creature = new Mock<ICreature>();
        creature.Setup(x => x.HasCivilization(Civilization.Light)).Returns(
            creatureHasMatchingCivilization);

        // Act
        var actual = filter.Match(creature.Object);

        // Assert
        Assert.Equal(creatureHasMatchingCivilization, actual);
    }
}
