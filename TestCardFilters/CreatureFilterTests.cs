using CardFilters;
using Interfaces;
using Moq;

namespace TestCardFilters;

public class CreatureFilterTests
{
    [Fact]
    public void DoesNotEqualObjectOfAnotherType()
    {
        // Arrange
        var filter = new CreatureFilter();

        // Act
        var actual = filter.Equals(new object());

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var filter = new CreatureFilter();

        // Act
        var copy = filter.Copy();

        // Assert
        Assert.Equal(filter, copy);
    }

    [Fact]
    public void HashCodesAreEqualForEqualFilters()
    {
        // Arrange
        var first = new CreatureFilter();
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
        var filter = new CreatureFilter();

        // Act
        var actual = filter.Match(Mock.Of<ICard>());

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void MatchesCreature()
    {
        // Arrange
        var filter = new CreatureFilter();
        var creature = Mock.Of<ICreature>();

        // Act
        var actual = filter.Match(creature);

        // Assert
        Assert.True(actual);
    }
}
