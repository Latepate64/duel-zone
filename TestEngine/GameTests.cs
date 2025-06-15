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
        randomizer.Setup(x => x.Shuffle(startingPlayer.Deck.Cards.ToList())).Callback(
            (List<Card> cards) => cards.Reverse());
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
            state.Losers.AddRange(state.Players);
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
        var toCharge = player.Hand.Cards.ElementAt(3);

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
    public void PayingWithTappedManaThrows()
    {
        // Arrange
        var player = new PlayerV2()
        {
            Hand = new Engine.Zones.Hand([CreateCreature()]),
            ManaZone = new Engine.Zones.ManaZone([CreateCreature(tapped: true)]),
        };
        var state = new GameState([player, (CreatePlayer(DeckSize))])
        {
            EventsHappening = new(new MainPhaseEvent(player))
        };
        state.PassableAction = new UseCardEvent(state.ActivePlayer);
        var game = CreateGame(state);

        // Act
        var ex = Assert.Throws<IllegalActionException>(() => game.Play(new UseCardEvent(player)
        {
            Card = player.Hand.Cards.Single(),
            PaymentCards = player.ManaZone.Cards
        }));

        // Assert
        Assert.Equal(IllegalActionType.UseCardTappedManaForPayment, ex.Type);
    }

    [Fact]
    public void UsingCardWithInsufficientPaymentForCivilizationsThrows()
    {
        // Arrange
        var player = new PlayerV2()
        {
            Hand = new Engine.Zones.Hand([CreateCreature(Civilization.Light)]),
            ManaZone = new Engine.Zones.ManaZone([CreateCreature(Civilization.Water)]),
        };
        var state = new GameState([player, (CreatePlayer(DeckSize))])
        {
            EventsHappening = new(new MainPhaseEvent(player))
        };
        state.PassableAction = new UseCardEvent(state.ActivePlayer);
        var game = CreateGame(state);

        // Act
        var ex = Assert.Throws<IllegalActionException>(() => game.Play(new UseCardEvent(player)
        {
            Card = player.Hand.Cards.Single(),
            PaymentCards = player.ManaZone.Cards
        }));

        // Assert
        Assert.Equal(IllegalActionType.UseCardPaymentForCivilizations, ex.Type);
    }

    [Fact]
    public void SummoningACreaturePutsItFromHandIntoTheBattleZoneAndTapsPaymentCards()
    {
        // Arrange
        var player = new PlayerV2()
        {
            Hand = new Engine.Zones.Hand([CreateCreature(), CreateCreature()]),
            ManaZone = new Engine.Zones.ManaZone([CreateCreature()]),
        };
        var state = new GameState([player, (CreatePlayer(DeckSize))])
        {
            EventsHappening = new(new MainPhaseEvent(player))
        };
        state.PassableAction = new UseCardEvent(state.ActivePlayer);
        var toUse = player.Hand.Cards.Last();

        // Act
        CreateGame(state).Play(new UseCardEvent(player)
        {
            Card = toUse,
            PaymentCards = player.ManaZone.Cards
        });

        // Assert
        Assert.True(player.ManaZone.Cards.Single().Tapped);
        Assert.DoesNotContain(toUse, player.Hand.Cards);
        Assert.Contains(toUse, state.BattleZone.Cards);
        Assert.Equal(new UseCardEvent(state.ActivePlayer), state.PassableAction);
    }

    [Fact]
    public void AttackingCreatureIsNullThrows()
    {
        // Arrange
        var player = CreatePlayer(DeckSize);
        var state = new GameState([player, (CreatePlayer(DeckSize))])
        {
            EventsHappening = new(new AttackPhaseEvent(player))
        };
        state.PassableAction = new AttackEvent(state.ActivePlayer);

        // Act
        var ex = Assert.Throws<IllegalActionException>(() => CreateGame(state).Play(new AttackEvent(player)));

        // Assert
        Assert.Equal(IllegalActionType.AttackingCreatureIsNull, ex.Type);
    }

    [Fact]
    public void AttackingCreatureIsTappedThrows()
    {
        // Arrange
        var player = CreatePlayer(DeckSize);
        var attackingCreature = CreateCreature(tapped: true);
        var state = new GameState([player, (CreatePlayer(DeckSize))])
        {
            EventsHappening = new(new AttackPhaseEvent(player)),
            BattleZone = new Engine.Zones.BattleZone([attackingCreature]),
        };
        state.PassableAction = new AttackEvent(state.ActivePlayer);

        // Act
        var ex = Assert.Throws<IllegalActionException>(() => CreateGame(state).Play(new AttackEvent(player)
        {
            AttackingCreature = attackingCreature
        }));

        // Assert
        Assert.Equal(IllegalActionType.AttackingCreatureIsTapped, ex.Type);
    }

    [Fact]
    public void AttackingCreatureHasSummoningSicknessThrows()
    {
        // Arrange
        var player = CreatePlayer(DeckSize);
        var attackingCreature = CreateCreature();
        var state = new GameState([player, (CreatePlayer(DeckSize))])
        {
            EventsHappening = new(new AttackPhaseEvent(player)),
            BattleZone = new Engine.Zones.BattleZone([attackingCreature]),
        };
        state.PassableAction = new AttackEvent(state.ActivePlayer);

        // Act
        var ex = Assert.Throws<IllegalActionException>(() => CreateGame(state).Play(new AttackEvent(player)
        {
            AttackingCreature = attackingCreature
        }));

        // Assert
        Assert.Equal(IllegalActionType.AttackingCreatureHasSummoningSickness, ex.Type);
    }

    [Fact]
    public void AttackedCreatureAndAttackedPlayerAreNullThrows()
    {
        // Arrange
        var player = CreatePlayer(DeckSize);
        var attackingCreature = CreateCreature(summoningSickness: false);
        var state = new GameState([player, (CreatePlayer(DeckSize))])
        {
            EventsHappening = new(new AttackPhaseEvent(player)),
            BattleZone = new Engine.Zones.BattleZone([attackingCreature]),
        };
        state.PassableAction = new AttackEvent(state.ActivePlayer);

        // Act
        var ex = Assert.Throws<IllegalActionException>(() => CreateGame(state).Play(new AttackEvent(player)
        {
            AttackingCreature = attackingCreature
        }));

        // Assert
        Assert.Equal(IllegalActionType.AttackedCreatureAndAttackedPlayerAreNull, ex.Type);
    }

    [Fact]
    public void AttackedCreatureAndAttackedPlayerAreNotNullThrows()
    {
        // Arrange
        var player = CreatePlayer(DeckSize);
        var attackingCreature = CreateCreature(summoningSickness: false);
        var attackedCreature = CreateCreature();
        var state = new GameState([player, (CreatePlayer(DeckSize))])
        {
            EventsHappening = new(new AttackPhaseEvent(player)),
            BattleZone = new Engine.Zones.BattleZone([attackingCreature]),
        };
        state.PassableAction = new AttackEvent(state.ActivePlayer);

        // Act
        var ex = Assert.Throws<IllegalActionException>(() => CreateGame(state).Play(new AttackEvent(player)
        {
            AttackingCreature = attackingCreature,
            AttackedCreature = attackedCreature,
            AttackedPlayer = state.NonActivePlayers.Single()
        }));

        // Assert
        Assert.Equal(IllegalActionType.AttackedCreatureAndAttackedPlayerAreNotNull, ex.Type);
    }

    static PlayerV2 CreatePlayer(int deckSize, int handSize = 5)
    {
        var deckCards = new List<Card>();
        for (int i = 0; i < deckSize; ++i)
        {
            deckCards.Add(CreateCreature());
        }
        var handCards = new List<Card>();
        for (int i = 0; i < handSize; ++i)
        {
            handCards.Add(CreateCreature());
        }
        return new PlayerV2
        {
            Deck = new Engine.Zones.Deck([.. deckCards]),
            Hand = new Engine.Zones.Hand([.. handCards])
        };
    }

    static Card CreateCreature(Civilization civilization = Civilization.Light, bool tapped = false, int manaCost = 1,
        bool summoningSickness = true)
    {
        return new Card(tapped, [civilization], manaCost, summoningSickness);
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

    static Game CreateGame(GameState state, int maxloopCount = 5) => new(Mock.Of<IRandomizer>(), state, maxloopCount);
}