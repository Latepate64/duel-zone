using GameEvents;
using Interfaces;
using Moq;

namespace TestGameEvents;

public class StartGameEventTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var player = new Mock<IPlayerV2>();
        player.Setup(x => x.Copy()).Returns(player.Object);
        var otherPlayer = new Mock<IPlayerV2>();
        otherPlayer.Setup(x => x.Copy()).Returns(player.Object);
        var random = Mock.Of<IRandomizer>();
        var e = new StartGameEvent(
            player.Object, otherPlayer.Object, random);

        // Act
        var actual = e.Copy();
        
        // Assert
        Assert.Equal(e, actual);
    }

    [Fact]
    public void Happen()
    {
        // Arrange
        var random = Mock.Of<IRandomizer>();
        var player = new Mock<IPlayerV2>();
        player.Setup(x => x.Deck.Shuffle(random));
        var otherPlayer = new Mock<IPlayerV2>();
        otherPlayer.Setup(x => x.Deck.Shuffle(random));
        var e = new StartGameEvent(
            player.Object, otherPlayer.Object, random);
        var state = Mock.Of<IGameState>();

        // Act
        var events = e.Happen(state);
        
        // Assert
        Assert.Empty(events);
    }
}