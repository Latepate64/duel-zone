using CardFilters;
using Interfaces;
using Moq;

namespace TestCardFilters;

public class AnyCardFilterTests
{
    [Fact]
    public void DoesNotEqualObjectOfAnotherType()
    {
        // Arrange
        var filter = new AnyCardFilter();

        // Act
        var actual = filter.Equals(new object());

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var filter = new AnyCardFilter();

        // Act
        var copy = filter.Copy();

        // Assert
        Assert.Equal(filter, copy);
    }

    [Fact]
    public void HashCodesAreEqualForEqualFilters()
    {
        // Arrange
        var first = new AnyCardFilter();
        var second = first.Copy();
        var expected = second.GetHashCode();

        // Act
        var actual = first.GetHashCode();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void MatchesAnyCard()
    {
        // Arrange
        var filter = new AnyCardFilter();

        // Act
        var actual = filter.Match(Mock.Of<ICard>());

        // Assert
        Assert.True(actual);
    }
}
