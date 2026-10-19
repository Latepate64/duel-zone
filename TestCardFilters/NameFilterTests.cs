using CardFilters;
using Interfaces;
using Moq;

namespace TestCardFilters;

public class NameFilterTests
{
    [Fact]
    public void DoesNotEqualObjectOfAnotherType()
    {
        // Arrange
        var filter = new NameFilter("Emeral");

        // Act
        var actual = filter.Equals(new object());

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void DoesNotEqualFilterWithDifferentNames()
    {
        // Arrange
        var first = new NameFilter("Emeral");
        var second = new NameFilter("Corile");

        // Act
        var actual = first.Equals(second);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var filter = new NameFilter("Emeral");

        // Act
        var copy = filter.Copy();

        // Assert
        Assert.Equal(filter, copy);
    }

    [Fact]
    public void HashCodesAreEqualForEqualFilters()
    {
        // Arrange
        var first = new NameFilter("Emeral");
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
        var filter = new NameFilter("Emeral");

        // Act
        var actual = filter.Match(Mock.Of<ICard>());

        // Assert
        Assert.False(actual);
    }

    [Theory]
    [InlineData("Emeral", "Corile", false)]
    [InlineData("Emeral", "Emeral", true)]
    public void MatchesCreatureWithName(
        string filterName, string cardName, bool expected)
    {
        // Arrange
        var filter = new NameFilter(filterName);
        var creature = new Mock<ICard>();
        creature.SetupGet(x => x.Name).Returns(cardName);

        // Act
        var actual = filter.Match(creature.Object);

        // Assert
        Assert.Equal(expected, actual);
    }
}
