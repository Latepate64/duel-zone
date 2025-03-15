using Engine;
using Engine.Zones;
using Moq;
using Xunit;

namespace TestEngine;

public class GameTests
{
    [Fact]
    public void EndsWhenDecksAreEmpty()
    {
        // Arrange
        var game = new Game();
        var player1 = new Mock<IPlayer>();
        player1.SetupGet(x => x.Deck).Returns(new Deck());
        var player2 = new Mock<IPlayer>();
        player2.SetupGet(x => x.Deck).Returns(new Deck());

        // Act
        game.Play(player1.Object, player2.Object);

        // Assert
        Assert.True(game.Ended);
    }
}
