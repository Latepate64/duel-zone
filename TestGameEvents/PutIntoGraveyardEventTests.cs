using GameEvents;
using Interfaces;
using Moq;

namespace TestGameEvents;

public class PutIntoGraveyardEventTests
{
    [Fact]
    public void HashCodesAreEqualForEqualEvents()
    {
        // Arrange
        var player = Mock.Of<IPlayerV2>();
        var card = Mock.Of<ICard>();
        var e = new PutIntoGraveyardEvent(player, card);
        var another = new PutIntoGraveyardEvent(player, card);
        var expected = another.GetHashCode();

        // Act
        var actual = e.GetHashCode();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var player = new Mock<IPlayerV2>();
        player.Setup(x => x.Copy()).Returns(player.Object);
        var card = new Mock<ICard>();
        card.Setup(x => x.Copy()).Returns(card.Object);
        var e = new PutIntoGraveyardEvent(player.Object, card.Object);

        // Act
        var actual = e.Copy();
        
        // Assert
        Assert.Equal(e, actual);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void DoesNotEqualEventOfAnotherType(bool isNull)
    {
        // Arrange
        var player = Mock.Of<IPlayerV2>();
        var card = Mock.Of<ICard>();
        var e = new PutIntoGraveyardEvent(player, card);

        // Act
        var actual = e.Equals(isNull
            ? null : new AttackEvent(player));

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void DoesNotEqualEventWithDifferentCard()
    {
        // Arrange
        var player = Mock.Of<IPlayerV2>();
        var e = new PutIntoGraveyardEvent(player, Mock.Of<ICard>());
        var another = new PutIntoGraveyardEvent(player, Mock.Of<ICard>());

        // Act
        var actual = e.Equals(another);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void CardIsPutIntoGraveyard()
    {
        // Arrange
        var player = new Mock<IPlayerV2>();
        var card = Mock.Of<ICard>();
        player.Setup(x => x.Graveyard.Add(card));
        var e = new PutIntoGraveyardEvent(player.Object, card);

        // Act
        var events = e.Happen(Mock.Of<IGameState>());

        // Assert
        Assert.Empty(events);
        player.Verify(x => x.Graveyard.Add(card));
    }
}
