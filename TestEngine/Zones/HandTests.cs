using Engine.Zones;
using Interfaces;
using Moq;
using Xunit;

namespace TestEngine.Zones;

public sealed class HandTests
{
    [Fact]
    public void HashCodesAreEqualForEqualObjects()
    {
        // Arrange
        var zone = new Hand();
        var another = zone.Copy();

        // Act
        var first = zone.GetHashCode();
        var second = another.GetHashCode();

        // Assert
        Assert.Equal(first, second);
    }

    [Fact]
    public void CardsWithManaCost()
    {
        // Arrange
        var zone = new Hand();
        var card = new Mock<ICard>();
        card.Setup(x => x.ManaCost).Returns(1);
        zone.Add(card.Object);

        // Act
        var cards = zone.CardsWithManaCost(1);

        // Assert
        Assert.Contains(card.Object, cards);
        Assert.Single(cards);
    }
}