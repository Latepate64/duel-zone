using GameEvents;
using Interfaces;
using Moq;

namespace TestGameEvents;

public class ShuffleDeckEventTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var player = new Mock<IPlayerV2>();
        player.Setup(x => x.Copy()).Returns(player.Object);
        var random = new Mock<IRandomizer>();
        random.Setup(x => x.Copy()).Returns(random.Object);
        var e = new ShuffleDeckEvent(player.Object, random.Object);

        // Act
        var actual = e.Copy();
        
        // Assert
        Assert.Equal(e, actual);
    }

    [Fact]
    public void ShufflesDeck()
    {
        // Arrange
        var player = new Mock<IPlayerV2>();
        var random = Mock.Of<IRandomizer>();
        player.Setup(x => x.Deck.Shuffle(random));
        var e = new ShuffleDeckEvent(player.Object, random);

        // Act
        var events = e.Happen(Mock.Of<IGameState>());
        
        // Assert
        player.Verify(x => x.Deck.Shuffle(random));
        Assert.Empty(events);
    }
}