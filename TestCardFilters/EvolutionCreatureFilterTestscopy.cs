using CardFilters;
using Interfaces;
using Moq;

namespace TestCardFilters;

public class EvolutionCreatureFilterTests
{
    [Fact]
    public void DoesNotEqualObjectOfAnotherType()
    {
        // Arrange
        var filter = new EvolutionCreatureFilter();

        // Act
        var actual = filter.Equals(new object());

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var filter = new EvolutionCreatureFilter();

        // Act
        var copy = filter.Copy();

        // Assert
        Assert.Equal(filter, copy);
    }

    [Fact]
    public void HashCodesAreEqualForEqualFilters()
    {
        // Arrange
        var first = new EvolutionCreatureFilter();
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
        var filter = new EvolutionCreatureFilter();

        // Act
        var actual = filter.Match(Mock.Of<ICard>());

        // Assert
        Assert.False(actual);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void MatchesCreatureThatHasEvolutionCreature(
        bool isEvolutionCreature)
    {
        // Arrange
        var filter = new EvolutionCreatureFilter();
        var creature = new Mock<ICreature>();
        creature.SetupGet(x => x.IsEvolutionCreature).Returns(
            isEvolutionCreature);

        // Act
        var actual = filter.Match(creature.Object);

        // Assert
        Assert.Equal(isEvolutionCreature, actual);
    }
}
