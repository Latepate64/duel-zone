using CardFilters;
using Interfaces;
using Moq;

namespace TestCardFilters;

public class MultiFilterTests
{
    [Fact]
    public void DoesNotEqualObjectOfAnotherType()
    {
        // Arrange
        var filter = new MultiFilter();

        // Act
        var actual = filter.Equals(new object());

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var filter1 = new Mock<ICardFilter>();
        filter1.Setup(x => x.Copy()).Returns(filter1.Object);
        var filter2 = new Mock<ICardFilter>();
        filter2.Setup(x => x.Copy()).Returns(filter2.Object);
        var multiFilter = new MultiFilter(filter1.Object, filter2.Object);

        // Act
        var copy = multiFilter.Copy();

        // Assert
        Assert.Equal(multiFilter, copy);
    }

    [Fact]
    public void HashCodesAreEqualForEqualFilters()
    {
        // Arrange
        var filter1 = new Mock<ICardFilter>();
        filter1.Setup(x => x.Copy()).Returns(filter1.Object);
        var filter2 = new Mock<ICardFilter>();
        filter2.Setup(x => x.Copy()).Returns(filter2.Object);
        var first = new MultiFilter(filter1.Object, filter2.Object);
        var second = first.Copy();
        var expected = second.GetHashCode();

        // Act
        var actual = first.GetHashCode();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void DoesNotEqualMultiFilterWithDifferentFilters()
    {
        // Arrange
        var first = new MultiFilter(Mock.Of<ICardFilter>());
        var second = new MultiFilter();

        // Act
        var actual = first.Equals(second);

        // Assert
        Assert.False(actual);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void MatchesIfAllFiltersMatch(bool allMatch)
    {
        // Arrange
        var card = Mock.Of<ICard>();
        var filter1 = new Mock<ICardFilter>();
        filter1.Setup(x => x.Match(card)).Returns(true);
        var filter2 = new Mock<ICardFilter>();
        filter2.Setup(x =>  x.Match(card)).Returns(allMatch);
        var filter = new MultiFilter(filter1.Object, filter2.Object);

        // Act
        var actual = filter.Match(card);

        // Assert
        Assert.Equal(allMatch, actual);
    }
}
