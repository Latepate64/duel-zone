using Engine;
using Moq;
using Xunit;

namespace TestEngine;

public class GameTests
{
    [Fact]
    public void PlayersShuffleTheirDecksWhenStartingAGame()
    {
        // Arrange
        var card1 = Mock.Of<ICard>();
        var card2 = Mock.Of<ICard>();
        var card3 = Mock.Of<ICard>();
        var card4 = Mock.Of<ICard>();
        var startingPlayer = new PlayerV2(Deck: [card1, card2]);
        var otherPlayer = new PlayerV2(Deck: [card3, card4]);
        var randomizer = new Mock<IRandomizer>();
        var expectedStartingPlayer = startingPlayer with
        {
            Deck = [card2, card1]
        };
        var expectedOtherPlayer = otherPlayer with { Deck = [card3, card4] };
        randomizer.Setup(x => x.Shuffle(startingPlayer.Deck)).Returns(
            expectedStartingPlayer.Deck);
        randomizer.Setup(x => x.Shuffle(otherPlayer.Deck)).Returns(
            expectedOtherPlayer.Deck);
        var game = new Game(randomizer.Object);

        // Act
        game.Start(startingPlayer, otherPlayer);

        // Assert
        Assert.Equal([expectedStartingPlayer, expectedOtherPlayer],
            game.State.Players);
    }
}