using CardFilters;
using Interfaces;
using Moq;

namespace TestCardFilters;

public class TappedCardFilterTests
{
    [Fact]
    public void DoesNotEqualObjectOfAnotherType()
    {
        // Arrange
        var filter = new TappedCardFilter();

        // Act
        var actual = filter.Equals(new object());

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var filter = new TappedCardFilter();

        // Act
        var copy = filter.Copy();

        // Assert
        Assert.Equal(filter, copy);
    }

    [Fact]
    public void HashCodesAreEqualForEqualFilters()
    {
        // Arrange
        var first = new TappedCardFilter();
        var second = first.Copy();
        var expected = second.GetHashCode();

        // Act
        var actual = first.GetHashCode();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void MatchesCardThatIsTappedCard(bool isTapped)
    {
        // Arrange
        var filter = new TappedCardFilter();
        var card = new Mock<ICard>();
        card.SetupGet(x => x.Tapped).Returns(isTapped);

        // Act
        var actual = filter.Match(card.Object);

        // Assert
        Assert.Equal(isTapped, actual);
    }
}
