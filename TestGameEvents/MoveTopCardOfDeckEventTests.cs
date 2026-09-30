using GameEvents;
using Interfaces;
using Moq;

namespace TestGameEvents;

public class MoveTopCardOfDeckEventTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var player = new Mock<IPlayerV2>();
        player.Setup(x => x.Copy()).Returns(player.Object);
        var e = new MoveTopCardOfDeckEvent(player.Object, ZoneType.ManaZone);

        // Act
        var actual = e.Copy();
        
        // Assert
        Assert.Equal(e, actual);
    }

    [Fact]
    public void TopCardOfDeckIsMovedToDestination()
    {
        // Arrange
        var card = Mock.Of<ICard>();
        var player = new Mock<IPlayerV2>();
        player.SetupGet(x => x.Deck.HasCards).Returns(true);
        player.SetupGet(x => x.Deck.TopCard).Returns(card);
        player.Setup(x => x.Deck.Remove(card));
        player.Setup(x => x.ManaZone.Add(card));
        var e = new MoveTopCardOfDeckEvent(player.Object, ZoneType.ManaZone);

        // Act
        var events = e.Happen(Mock.Of<IGameState>());
        
        // Assert
        Assert.Empty(events);
        player.Verify(x => x.Deck.Remove(card));
        player.Verify(x => x.ManaZone.Add(card));
    }

    [Fact]
    public void NothingMovesWhenDeckIsEmpty()
    {
        // Arrange
        var card = Mock.Of<ICard>();
        var player = new Mock<IPlayerV2>();
        player.SetupGet(x => x.Deck.HasCards).Returns(false);
        var e = new MoveTopCardOfDeckEvent(player.Object, ZoneType.ManaZone);

        // Act
        var events = e.Happen(Mock.Of<IGameState>());
        
        // Assert
        Assert.Empty(events);
    }

    [Fact]
    public void NotImplementedExceptionIsThrownWhenDestinationIsNotSupported()
    {
        // Arrange
        var card = Mock.Of<ICard>();
        var player = new Mock<IPlayerV2>();
        player.SetupGet(x => x.Deck.HasCards).Returns(true);
        player.SetupGet(x => x.Deck.TopCard).Returns(card);
        player.Setup(x => x.Deck.Remove(card));
        var e = new MoveTopCardOfDeckEvent(player.Object, ZoneType.Graveyard);

        // Act + Assert
        var events = Assert.Throws<NotImplementedException>(
            () => e.Happen(Mock.Of<IGameState>()));
        
        // Assert
        player.Verify(x => x.Deck.Remove(card)); //TODO NOT A GOOD THING
    }
}