using GameEvents;
using Interfaces;
using Moq;

namespace TestGameEvents;

public class MainPhaseEventTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var player = new Mock<IPlayerV2>();
        player.Setup(x => x.Copy()).Returns(player.Object);
        var e = new MainPhaseEvent(player.Object);

        // Act
        var actual = e.Copy();
        
        // Assert
        Assert.Equal(e, actual);
    }

    [Fact]
    public void CreatesUseCardEventWhenActivePlayerHasHandCards()
    {
        // Arrange
        var player = new Mock<IPlayerV2>();
        player.Setup(x => x.Hand.HasCards).Returns(true);
        var e = new MainPhaseEvent(player.Object);
        var expected = new UseCardEvent(player.Object);

        // Act
        var events = e.Happen(Mock.Of<IGameState>());
        
        // Assert
        Assert.Contains(expected, events);
    }

    [Fact]
    public void NothingHappensWhenActivePlayerHasNoHandCards()
    {
        // Arrange
        var player = new Mock<IPlayerV2>();
        player.Setup(x => x.Hand.HasCards).Returns(false);
        var e = new MainPhaseEvent(player.Object);

        // Act
        var events = e.Happen(Mock.Of<IGameState>());
        
        // Assert
        Assert.Empty(events);
    }
}