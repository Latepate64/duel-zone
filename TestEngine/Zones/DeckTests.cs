using Engine.Zones;
using Interfaces;
using Moq;
using Xunit;

namespace TestEngine.Zones;

public sealed class DeckTests
{
    [Fact]
    public void HashCodesAreEqualForEqualObjects()
    {
        // Arrange
        var zone = new Deck();
        var another = zone.Copy();

        // Act
        var first = zone.GetHashCode();
        var second = another.GetHashCode();

        // Assert
        Assert.Equal(first, second);
    }

    [Fact]
    public void GetTopCard()
    {
        // Arrange
        var zone = new Deck();
        var card = Mock.Of<ICard>();
        zone.Add(card);

        // Act
        var topCard = zone.TopCard;

        // Assert
        Assert.Equal(card, topCard);
    }
}