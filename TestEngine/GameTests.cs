using System;
using System.Collections.Generic;
using System.Linq;
using Engine;
using Engine.Zones;
using GameEvents;
using Interfaces;
using Moq;
using Xunit;

namespace TestEngine;

public sealed class GameTests
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
        randomizer.Setup(x => x.Shuffle(startingPlayer.Deck.Cards.ToList())).Callback(
            (List<ICard> cards) => cards.Reverse());
        randomizer.Setup(x => x.Shuffle(otherPlayer.Deck.Cards.ToList()));
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
        Assert.Equal(new ChargeEvent(startingPlayer), game.State.PassableAction);
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
        var ex = Assert.Throws<InvalidOperationException>(() => game.Start(startingPlayer, otherPlayer));
        Assert.Equal("Game has started already", ex.Message);
    }

    [Fact]
    public void StartingAGameThatWasCreatedWithAStateThrows()
    {
        // Arrange
        var state = CreateGameState();

        // Act
        var game = CreateGame(state);

        // Assert
        Assert.Equal(state, game.State);
        var ex = Assert.Throws<InvalidOperationException>(() => game.Start(state.ActivePlayer,
            state.NonActivePlayers.Single()));
        Assert.Equal("Game has started already", ex.Message);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void ConcedingPlayerLosesAndOpponentWins(bool startingPlayerConcedesInsteadOfAnother)
    {
        // Arrange
        var state = CreateGameState();
        var game = CreateGame(state);
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
        if (winInsteadOfLose)
        {
            state.Winner = state.ActivePlayer;
            state.Losers.Add(state.NonActivePlayers.Single());
        }
        else
        {
            foreach (var player in state.Players)
            {
                state.Losers.Add(player);
            }
        }

        var game = CreateGame(state);

        // Act + Assert
        var ex = Assert.Throws<InvalidOperationException>(() => game.Play(new ConcedeEvent(state.ActivePlayer)));
        Assert.Equal("Game has ended already", ex.Message);
    }

    [Fact]
    public void PlayingAGameWithoutPassableActionThrows()
    {
        // Arrange
        var state = CreateGameState();
        var game = CreateGame(state);

        // Act
        var ex = Assert.Throws<InvalidOperationException>(() => game.Play(new PassAction(state.ActivePlayer)));

        // Assert
        Assert.Equal("No passable action found", ex.Message);
        Assert.Equal(state, game.State);
    }

    [Fact]
    public void PlayingAGameWithWrongPlayerTakingActionThrows()
    {
        // Arrange
        var state = CreateGameState();
        state.PassableAction = new ChargeEvent(state.ActivePlayer);
        var game = CreateGame(state);

        // Act
        var ex = Assert.Throws<IllegalActionException>(() => game.Play(new PassAction(state.NonActivePlayers.First())));

        // Assert
        Assert.Equal(IllegalActionType.UnexpectedPlayer, ex.Type);
        Assert.Equal(state, game.State);
    }

    [Fact]
    public void TakenActionNotMatchingPassableActionThrows()
    {
        // Arrange
        var state = CreateGameState();
        state.PassableAction = new ChargeEvent(state.ActivePlayer);
        var game = CreateGame(state);

        // Act
        var ex = Assert.Throws<IllegalActionException>(() => game.Play(new UseCardEvent(state.ActivePlayer)));

        // Assert
        Assert.Equal(IllegalActionType.UnexpectedType, ex.Type);
        Assert.Equal(state, game.State);
    }

    [Fact]
    public void LoopCounterReachingMaxThrows()
    {
        // Arrange
        var state = CreateGameState();
        state.PassableAction = new ChargeEvent(state.ActivePlayer);
        var game = CreateGame(state, 0);

        // Act
        var ex = Assert.Throws<InvalidOperationException>(() => game.Play(
            new PassAction(state.ActivePlayer)));

        // Assert
        Assert.Equal("Looped too many times", ex.Message);
        Assert.Equal(state, game.State);
    }

    [Fact]
    public void ProceedToUseCardEventAfterActivePlayerPassesCharging()
    {
        // Arrange
        var startingPlayer = CreatePlayer(DeckSize);
        var otherPlayer = CreatePlayer(DeckSize);
        var state = new GameState([startingPlayer, otherPlayer])
        {
            EventsHappening = new EventStack(new TakeTurnEvent(
                startingPlayer, true, PhaseType.Main)),
            PassableAction = new ChargeEvent(startingPlayer)
        };
        var game = CreateGame(state);

        // Act
        game.Play(new PassAction(startingPlayer));

        // Assert
        Assert.Equal(
            new UseCardEvent(startingPlayer), game.State.PassableAction);
    }

    [Fact]
    public void PlayerOrderIsUpdatedAfterTurnEnds()
    {
        // Arrange
        var startingPlayer = CreatePlayer(DeckSize);
        var otherPlayer = CreatePlayer(DeckSize);
        var state = new GameState([startingPlayer, otherPlayer])
        {
            EventsHappening = new EventStack(new TakeTurnEvent(
                startingPlayer, true, PhaseType.Attack)),
            PassableAction = new AttackEvent(startingPlayer),
            TurnNumber = 1
        };
        var game = CreateGame(state);

        // Act
        game.Play(new PassAction(startingPlayer));

        // Assert
        Assert.Equal(startingPlayer, state.NonActivePlayers.Single());
        Assert.Equal(otherPlayer, state.ActivePlayer);
    }

    [Fact]
    public void
        EventsHappeningReturningMoreThanOnePassableGameEventThrowsNotImplementedException()
    {
        // Arrange
        var state = new Mock<IGameState>();
        state.SetupGet(x => x.PassableAction).Returns(
            Mock.Of<IPassableGameEvent>);
        state.Setup(x => x.EventsThatWouldHappen.Get()).Returns([]);
        state.SetupGet(x => x.EventsHappening.IsEmpty).Returns(false);
        state.Setup(x => x.EventsHappening.Happen(state.Object)).Returns([
            Mock.Of<IPassableGameEvent>(),
            Mock.Of<IPassableGameEvent>()
        ]);
        var game = CreateGame(state.Object);

        // Act + Assert
        Assert.Throws<NotImplementedException>(
            () => game.Play(Mock.Of<IPassAction>()));
    }

    [Fact]
    public void GameEnds()
    {
        // Arrange
        var state = new Mock<IGameState>();
        var gameEvent = new Mock<IPassableGameEvent>();
        state.SetupGet(x => x.PassableAction).Returns(gameEvent.Object);
        gameEvent.Setup(x => x.Validate(gameEvent.Object));
        state.Setup(x => x.EventsThatWouldHappen.Get()).Returns([]);
        state.SetupGet(x => x.EventsHappening.IsEmpty).Returns(false);
        state.Setup(x => x.EventsHappening.Happen(state.Object)).Returns([]);
        state.SetupSequence(x => x.GameOver).Returns(false).Returns(true);
        var game = CreateGame(state.Object);
        
        // Act
        game.Play(Mock.Of<IPassableGameEvent>());

        // Assert
        Assert.Equal(state.Object, game.State);
    }

    static PlayerV2 CreatePlayer(int deckSize, int handSize = 5)
    {
        var deckCards = new List<ICreature>();
        for (int i = 0; i < deckSize; ++i)
        {
            deckCards.Add(CreateCreature());
        }
        var handCards = new List<ICreature>();
        for (int i = 0; i < handSize; ++i)
        {
            handCards.Add(CreateCreature());
        }
        var player = new PlayerV2
        {
            Deck = new Deck([.. deckCards]),
            Hand = new Hand([.. handCards])
        };
        player.SetOwnerForCards();
        return player;
    }

    static ICreature CreateCreature(Civilization civilization = Civilization.Light, bool tapped = false,
        int manaCost = 1, bool summoningSickness = true, int power = 1000, PlayerV2 owner = null)
    {
        var creature = new Mock<ICreature>();
        creature.SetupProperty(x => x.Tapped, tapped);
        creature.SetupGet(x => x.Civilizations).Returns([civilization]);
        creature.SetupGet(x => x.ManaCost).Returns(manaCost);
        creature.SetupGet(x => x.SummoningSickness).Returns(summoningSickness);
        creature.SetupGet(x => x.Power).Returns(power);
        creature.SetupGet(x => x.OwnerV2).Returns(owner);
        creature.SetupGet(x => x.Name).Returns("Test Creature");
        creature.SetupGet(x => x.Races).Returns([Race.AngelCommand]);
        return creature.Object;
    }

    static GameState CreateGameState()
    {
        var startingPlayer = CreatePlayer(DeckSize);
        var otherPlayer = CreatePlayer(DeckSize);
        return new GameState([startingPlayer, otherPlayer])
        {
            EventsHappening = new EventStack(new TakeTurnEvent(
                startingPlayer, true))
        };
    }

    static Game CreateGame(IGameState state, int maxloopCount = 99) => new(
        Mock.Of<IRandomizer>(), state, maxloopCount);
}