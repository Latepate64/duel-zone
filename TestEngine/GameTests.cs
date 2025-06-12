using System;
using System.Collections.Generic;
using System.Linq;
using Engine;
using Engine.GameEvents;
using Moq;
using Xunit;

namespace TestEngine;

public class GameTests
{
    const int DeckSize = 15;

    [Fact]
    public void StartingAGameSetupsTheGameCorrectly()
    {
        // Arrange

        const int ShieldCount = 5;
        const int HandSize = 5;
        const int DeckSizeAfterSetup = DeckSize - (ShieldCount + HandSize);
        var startingPlayer = CreatePlayer(DeckSize, handSize: 0);
        var otherPlayer = CreatePlayer(DeckSize, handSize: 0);
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

    [Fact]
    public void StartingAnAlreadyStartedGameThrows()
    {
        // Arrange
        var game = new Game(Mock.Of<IRandomizer>());
        var startingPlayer = CreatePlayer(DeckSize, handSize: 0);
        var otherPlayer = CreatePlayer(DeckSize, handSize: 0);

        // Act
        game.Start(startingPlayer, otherPlayer);

        // Assert
        _ = Assert.Throws<InvalidOperationException>(() => game.Start(startingPlayer, otherPlayer));
    }

    [Fact]
    public void StartingAGameThatWasCreatedWithAStateThrows()
    {
        // Arrange
        var state = CreateGameState();

        // Act
        var game = new Game(Mock.Of<IRandomizer>(), state);

        // Assert
        Assert.Equal(state, game.State);
        _ = Assert.Throws<InvalidOperationException>(() => game.Start(state.ActivePlayer,
            state.NonActivePlayers.Single()));
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void IllegalActionDuringChargePhaseThrows(bool shuffleInsteadOfInvalidCharge)
    {
        // Arrange
        var state = CreateGameState();
        state.HappeningEvent = new ChargePhaseEvent(state.ActivePlayer);
        var randomizer = Mock.Of<IRandomizer>();
        var game = new Game(randomizer, state);
        PlayerAction action = shuffleInsteadOfInvalidCharge
            ? new ShuffleDeckEvent(state.ActivePlayer, randomizer)
            : new ChargeEvent(state.ActivePlayer);

        // Act
        var ex = Assert.Throws<IllegalActionException>(() => game.Play(action));

        // Assert
        Assert.Equal(action, ex.PlayerAction);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void ConcedingPlayerLosesAndOpponentWins(bool startingPlayerConcedesInsteadOfAnother)
    {
        // Arrange
        var state = CreateGameState();
        state.HappeningEvent = new ChargePhaseEvent(state.ActivePlayer);
        var game = new Game(Mock.Of<IRandomizer>(), state);
        var conceder = startingPlayerConcedesInsteadOfAnother ? state.ActivePlayer : state.NonActivePlayers.Single();
        var winner = startingPlayerConcedesInsteadOfAnother ? state.NonActivePlayers.Single() : state.ActivePlayer;
        var action = new ConcedeEvent(conceder);

        // Act
        game.Play(action);

        // Assert
        Assert.Equal([conceder], game.State.Losers);
        Assert.Equal(winner, game.State.Winner);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void PlayingAGameThatHasWinnerOrAllPlayersLostThrows(bool winInsteadOfLose)
    {
        // Arrange
        var state = CreateGameState();
        state.HappeningEvent = new ChargePhaseEvent(state.ActivePlayer);
        if (winInsteadOfLose)
        {
            state.Winner = state.ActivePlayer;
            state.Losers.Add(state.NonActivePlayers.Single());
        }
        else
        {
            state.Losers.AddRange(state.Players);
        }
        
        var game = new Game(Mock.Of<IRandomizer>(), state);

        // Act + Assert
        _ = Assert.Throws<InvalidOperationException>(() => game.Play(null));
    }

    [Fact]
    public void ActivePlayerChargesDuringChargePhase()
    {
        // Arrange
        var state = CreateGameState();
        state.HappeningEvent = new TakeTurnEvent(state.ActivePlayer, 1)
        {
            NextPhase = PhaseType.Main,
            HappeningEvent = new ChargePhaseEvent(state.ActivePlayer)
        };
        var randomizer = Mock.Of<IRandomizer>();
        var game = new Game(randomizer, state);
        var card = state.ActivePlayer.Hand.Cards.First();
        var action = new ChargeEvent(state.ActivePlayer) { ChosenCard = card };

        // Act
        game.Play(action);

        // Assert
        Assert.DoesNotContain(card, state.ActivePlayer.Hand.Cards);
        Assert.Contains(card, state.ActivePlayer.ManaZone.Cards);
        Assert.Equal(new UseCardEvent(state.ActivePlayer), game.State.LeafHappeningEvent.PromptedAction);
    }

    static PlayerV2 CreatePlayer(int deckSize, int handSize)
    {
        var cards = new List<ICard>();
        for (int i = 0; i < deckSize; ++i)
        {
            cards.Add(Mock.Of<ICard>());
        }
        var player = new PlayerV2(cards);
        for (int i = 0; i < handSize; ++i)
        {
            player.Hand.Cards.Add(Mock.Of<ICard>());
        }
        return player;
    }

    static GameState CreateGameState()
    {
        var startingPlayer = CreatePlayer(DeckSize, handSize: 5);
        var otherPlayer = CreatePlayer(DeckSize, handSize: 5);
        return new GameState([startingPlayer, otherPlayer]);
    }
}