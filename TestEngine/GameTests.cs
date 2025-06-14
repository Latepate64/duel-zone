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
        var game = new Game(Mock.Of<IRandomizer>(), state);

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
        var ex = Assert.Throws<InvalidOperationException>(() => game.Play(new ConcedeEvent(state.ActivePlayer)));
        Assert.Equal("Game has ended already", ex.Message);
    }

    [Fact]
    public void PlayingAGameWithoutPassableActionThrows()
    {
        // Arrange
        var state = CreateGameState();
        var game = new Game(Mock.Of<IRandomizer>(), state);

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
        var game = new Game(Mock.Of<IRandomizer>(), state);

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
        var game = new Game(Mock.Of<IRandomizer>(), state);

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
        var game = new Game(Mock.Of<IRandomizer>(), state, 0);

        // Act
        var ex = Assert.Throws<InvalidOperationException>(() => game.Play(new PassAction(state.ActivePlayer)));

        // Assert
        Assert.Equal("Looped too many times", ex.Message);
        Assert.Equal(state, game.State);
    }

    [Fact]
    public void CardIsPutFromHandIntoManaZoneDuringChargePhase()
    {
        // Arrange
        var game = CreateAndStartGame();
        var player = game.State.ActivePlayer;
        var toCharge = player.Hand.Cards[3];

        // Act
        game.Play(new ChargeEvent(player) { ChosenCard = toCharge });

        // Assert
        Assert.DoesNotContain(toCharge, player.Hand.Cards);
        Assert.Contains(toCharge, player.ManaZone.Cards);
        Assert.Equal(new UseCardEvent(player), game.State.PassableAction);
    }

    [Fact]
    public void UsingCardOutsideOfHandThrows()
    {
        // Arrange
        var game = CreateAndStartGame();
        var player = game.State.ActivePlayer;
        var mana = player.Hand.Cards.Last();
        game.Play(new ChargeEvent(player) { ChosenCard = mana });

        // Act
        var ex = Assert.Throws<IllegalActionException>(() => game.Play(new UseCardEvent(player)
        {
            Card = mana,
            PaymentCards = [mana]
        }));

        // Assert
        Assert.Equal(IllegalActionType.HandDoesNotContainCard, ex.Type);
    }

    [Fact]
    public void UsingCardWithInsufficientPaymentForManaCostThrows()
    {
        // Arrange
        var game = CreateAndStartGame();
        var player = game.State.ActivePlayer;
        var mana = player.Hand.Cards.Last();
        game.Play(new ChargeEvent(player) { ChosenCard = mana });
        var useCard = player.Hand.Cards.Last();

        // Act
        var ex = Assert.Throws<IllegalActionException>(() => game.Play(new UseCardEvent(player)
        {
            Card = useCard,
            PaymentCards = []
        }));

        // Assert
        Assert.Equal(IllegalActionType.UseCardPaymentForManaCost, ex.Type);
    }

    [Fact]
    public void UsingCardWithInsufficientPaymentForCivilizationsThrows()
    {
        // Arrange
        var player = new PlayerV2()
        {
            Hand = new Engine.Zones.Hand([CreateCard(Civilization.Light)]),
            ManaZone = new Engine.Zones.ManaZone([CreateCard(Civilization.Water)]),
        };
        var state = new GameState([player, (CreatePlayer(DeckSize))])
        {
            EventsHappening = new(new MainPhaseEvent(player))
        };
        state.PassableAction = new UseCardEvent(state.ActivePlayer);
        var game = new Game(Mock.Of<IRandomizer>(), state, 0);

        // Act
        var ex = Assert.Throws<IllegalActionException>(() => game.Play(new UseCardEvent(player)
        {
            Card = player.Hand.Cards.Single(),
            PaymentCards = player.ManaZone.Cards
        }));

        // Assert
        Assert.Equal(IllegalActionType.UseCardPaymentForCivilizations, ex.Type);
    }

    static PlayerV2 CreatePlayer(int deckSize, int handSize = 5)
    {
        var cards = new List<ICard>();
        for (int i = 0; i < deckSize; ++i)
        {
            cards.Add(CreateCard());
        }
        var player = new PlayerV2 { Deck = new Engine.Zones.Deck([.. cards]) } ;
        for (int i = 0; i < handSize; ++i)
        {
            player.Hand.Cards.Add(CreateCard());
        }
        return player;
    }

    static ICard CreateCard(Civilization civilization = Civilization.Light)
    {
        var card = Mock.Of<ICard>();
        card.ManaCost = 1;
        card.Civilizations = [civilization];
        return card;
    }

    static GameState CreateGameState()
    {
        var startingPlayer = CreatePlayer(DeckSize);
        var otherPlayer = CreatePlayer(DeckSize);
        return new GameState([startingPlayer, otherPlayer])
        {
            EventsHappening = new(new TakeTurnEvent(startingPlayer, 1))
        };
    }

    static Game CreateAndStartGame()
    {
        var game = new Game(Mock.Of<IRandomizer>());
        var startingPlayer = CreatePlayer(DeckSize, handSize: 0);
        var otherPlayer = CreatePlayer(DeckSize, handSize: 0);
        game.Start(startingPlayer, otherPlayer);
        return game;
    }
}