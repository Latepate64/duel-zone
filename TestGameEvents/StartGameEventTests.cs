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
        var random = new Mock<IRandomizer>();
        random.Setup(x => x.Copy()).Returns(random.Object);
        var e = new StartGameEvent(
            player.Object, otherPlayer.Object, random.Object);

        // Act
        var actual = e.Copy();
        
        // Assert
        Assert.Equal(e, actual);
    }

    [Fact]
    public void Happen()
    {
        // Arrange
        var random = new Mock<IRandomizer>();
        random.Setup(x => x.Copy()).Returns(random.Object);
        var player = new Mock<IPlayerV2>();
        player.Setup(x => x.Deck.Shuffle(random.Object));
        var otherPlayer = new Mock<IPlayerV2>();
        otherPlayer.Setup(x => x.Deck.Shuffle(random.Object));
        var e = new StartGameEvent(
            player.Object, otherPlayer.Object, random.Object);
        var state = Mock.Of<IGameState>();

        // Act
        var events = e.Happen(state);
        
        // Assert
        Assert.Empty(events);
    }
}