using CardFilters;
using Interfaces;
using Moq;

namespace TestCardFilters;

public class TappedCreatureFilterTests
{
    [Fact]
    public void DoesNotEqualObjectOfAnotherType()
    {
        // Arrange
        var filter = new TappedCreatureFilter();

        // Act
        var actual = filter.Equals(new object());

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var filter = new TappedCreatureFilter();

        // Act
        var copy = filter.Copy();

        // Assert
        Assert.Equal(filter, copy);
    }

    [Fact]
    public void HashCodesAreEqualForEqualFilters()
    {
        // Arrange
        var first = new TappedCreatureFilter();
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
        var filter = new TappedCreatureFilter();

        // Act
        var actual = filter.Match(Mock.Of<ICard>());

        // Assert
        Assert.False(actual);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void MatchesCreatureThatIsTappedCreature(bool isTapped)
    {
        // Arrange
        var filter = new TappedCreatureFilter();
        var creature = new Mock<ICreature>();
        creature.SetupGet(x => x.Tapped).Returns(isTapped);

        // Act
        var actual = filter.Match(creature.Object);

        // Assert
        Assert.Equal(isTapped, actual);
    }
}
