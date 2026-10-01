using GameEvents;
using Interfaces;
using Moq;

namespace TestGameEvents;

public class StartOfTurnEventTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var player = new Mock<IPlayerV2>();
        player.Setup(x => x.Copy()).Returns(player.Object);
        var e = new StartOfTurnEvent(player.Object);

        // Act
        var actual = e.Copy();
        
        // Assert
        Assert.Equal(e, actual);
    }

    [Fact]
    public void NothingHappens()
    {
        // Arrange
        var e = new StartOfTurnEvent(Mock.Of<IPlayerV2>());

        // Act
        var events = e.Happen(Mock.Of<IGameState>());
        
        // Assert
        Assert.Empty(events);
    }
}