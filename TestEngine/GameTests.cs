using System.Collections.Generic;
using System.Linq;
using Engine;
using Moq;
using Xunit;

namespace TestEngine;

public class GameTests
{
    [Fact]
    public void StartingAGameSetupsTheGameCorrectly()
    {
        // Arrange
        const int DeckSize = 15;
        const int ShieldCount = 5;
        var startingPlayer = CreatePlayer(DeckSize);
        var otherPlayer = CreatePlayer(DeckSize);
        var randomizer = new Mock<IRandomizer>();
        randomizer.Setup(x => x.Shuffle(startingPlayer.Deck.Cards)).Callback((List<ICard> cards) => cards.Reverse());
        randomizer.Setup(x => x.Shuffle(otherPlayer.Deck.Cards));
        var game = new Game(randomizer.Object);
        var toReverse = startingPlayer.Deck.Cards.ToList();
        toReverse.Reverse();
        var expectedStartingPlayerDeckCards = toReverse.Take(DeckSize - ShieldCount);
        var expectedStartingPlayerShields = toReverse.TakeLast(ShieldCount).Reverse();
        var expectedOtherPlayerDeckCards = otherPlayer.Deck.Cards.Take(DeckSize - ShieldCount).ToList();
        var expectedOtherPlayerShields = otherPlayer.Deck.Cards.TakeLast(ShieldCount).Reverse().ToList();

        // Act
        game.Start(startingPlayer, otherPlayer);

        // Assert
        Assert.Equal(expectedStartingPlayerDeckCards, game.State.Players[0].Deck.Cards);
        Assert.Equal(expectedStartingPlayerShields, game.State.Players[0].ShieldZone.Cards);
        Assert.Equal(expectedOtherPlayerDeckCards, game.State.Players[1].Deck.Cards);
        Assert.Equal(expectedOtherPlayerShields, game.State.Players[1].ShieldZone.Cards);
    }

    static PlayerV2 CreatePlayer(int deckSize)
    {
        var cards = new List<ICard>();
        for (int i = 0; i < deckSize; ++i)
        {
            cards.Add(Mock.Of<ICard>());
        }
        return new PlayerV2(cards);
    }
}