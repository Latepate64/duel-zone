using System.Linq;
using Engine.Zones;
using Interfaces;
using Moq;
using Xunit;

namespace TestEngine.Zones;

public sealed class GraveyardTests
{
    [Fact]
    public void HashCodesAreEqualForEqualObjects()
    {
        // Arrange
        var zone = new Graveyard();
        var another = zone.Copy();

        // Act
        var first = zone.GetHashCode();
        var second = another.GetHashCode();

        // Assert
        Assert.Equal(first, second);
    }

    [Theory]
    [InlineData(false, 0)]
    [InlineData(true, 1)]
    public void GetOtherCards(bool isMatch, int expectedCount)
    {
        // Arrange
        var source = Mock.Of<ICard>();
        var notSource = Mock.Of<ICard>();
        var zone = new Graveyard();
        zone.Add(source);
        zone.Add(notSource);
        var filter = new Mock<ICardFilter>();
        filter.Setup(x => x.Match(notSource)).Returns(isMatch);

        // Act
        var cards = zone.GetOtherCards(source, filter.Object);

        // Assert
        Assert.DoesNotContain(source, cards);
        Assert.Equal(expectedCount, cards.Count());
    }
}