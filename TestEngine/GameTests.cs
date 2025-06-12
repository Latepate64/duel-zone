using System.Collections.Generic;
using System.Linq;
using Engine;
using Engine.GameEvents;
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
        const int HandSize = 5;
        const int DeckSizeAfterSetup = DeckSize - (ShieldCount + HandSize);
        var startingPlayer = CreatePlayer(DeckSize);
        var otherPlayer = CreatePlayer(DeckSize);
        var randomizer = new Mock<IRandomizer>();
        randomizer.Setup(x => x.Shuffle(startingPlayer.Deck.Cards)).Callback((List<ICard> cards) => cards.Reverse());
        randomizer.Setup(x => x.Shuffle(otherPlayer.Deck.Cards));
        var game = new Game(randomizer.Object);
        var startingDeck = startingPlayer.Deck.Cards.ToList();
        startingDeck.Reverse();
        var otherDeck = otherPlayer.Deck.Cards.ToList();

        // Act
        game.Start(startingPlayer, otherPlayer);

        // Assert
        Assert.Equal(startingDeck.Take(DeckSizeAfterSetup), game.State.Players[0].Deck.Cards);
        Assert.Equal(startingDeck.TakeLast(ShieldCount).Reverse(), game.State.Players[0].ShieldZone.Cards);
        Assert.Equal(startingDeck.Skip(DeckSizeAfterSetup).Take(HandSize).Reverse(), game.State.Players[0].Hand.Cards);
        Assert.Equal(otherDeck.Take(DeckSizeAfterSetup), game.State.Players[1].Deck.Cards);
        Assert.Equal(otherDeck.TakeLast(ShieldCount).Reverse(), game.State.Players[1].ShieldZone.Cards);
        Assert.Equal(otherDeck.Skip(DeckSizeAfterSetup).Take(HandSize).Reverse(), game.State.Players[1].Hand.Cards);
        Assert.Equal(new ChargeEvent(startingPlayer), game.State.LeafHappeningEvent.PromptedAction);
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