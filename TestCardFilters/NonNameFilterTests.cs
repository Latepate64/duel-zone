using CardFilters;
using Interfaces;
using Moq;

namespace TestCardFilters;

public class NonNameFilterTests
{
    [Fact]
    public void DoesNotEqualObjectOfAnotherType()
    {
        // Arrange
        var filter = new NonNameFilter("Emeral");

        // Act
        var actual = filter.Equals(new object());

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void DoesNotEqualFilterWithDifferentNames()
    {
        // Arrange
        var first = new NonNameFilter("Emeral");
        var second = new NonNameFilter("Corile");

        // Act
        var actual = first.Equals(second);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var filter = new NonNameFilter("Emeral");

        // Act
        var copy = filter.Copy();

        // Assert
        Assert.Equal(filter, copy);
    }

    [Fact]
    public void HashCodesAreEqualForEqualFilters()
    {
        // Arrange
        var first = new NonNameFilter("Emeral");
        var second = first.Copy();
        var expected = second.GetHashCode();

        // Act
        var actual = first.GetHashCode();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("Emeral", "Corile", true)]
    [InlineData("Emeral", "Emeral", false)]
    public void MatchesCreatureWithNonName(
        string filterNonName, string cardNonName, bool expected)
    {
        // Arrange
        var filter = new NonNameFilter(filterNonName);
        var creature = new Mock<ICard>();
        creature.SetupGet(x => x.Name).Returns(cardNonName);

        // Act
        var actual = filter.Match(creature.Object);

        // Assert
        Assert.Equal(expected, actual);
    }
}
