using System;
using Engine;
using GameEvents;
using Interfaces;
using Moq;
using Xunit;

namespace TestEngine;

public sealed class GameTests
{
    [Fact]
    public void PlayerOrderIsUpdatedAfterTurnEnds()
    {
        var activePlayer = new Mock<IPlayerV2>();
        activePlayer.SetupGet(x => x.Deck.HasCards).Returns(true);
        var nonActivePlayer = new Mock<IPlayerV2>();
        nonActivePlayer.SetupGet(x => x.Deck.HasCards).Returns(true);
        var state = new Mock<IGameState>();
        state.SetupGet(x => x.ActivePlayer).Returns(activePlayer.Object);
        state.SetupGet(x => x.NonActivePlayers).Returns([
            nonActivePlayer.Object]);
        state.SetupGet(x => x.PassableAction).Returns(
            Mock.Of<IPassableGameEvent>);
        state.Setup(x => x.EventsThatWouldHappen.Get()).Returns([]);
        state.SetupSequence(x => x.EventsHappening.IsEmpty)
            .Returns(true).Returns(false);
        state.SetupSequence(x => x.GameOver).Returns(false).Returns(true);
        state.SetupGet(x => x.TurnNumber).Returns(1);
        var game = CreateGame(state.Object);

        // Act
        var playState = game.Play(Mock.Of<IPassAction>());

        // Assert
        state.Verify(x => x.SwapActivePlayer());
        Assert.Equal(state.Object, game.State);
        Assert.Equal(PlayState.GameOver, playState);
    }

    [Fact]
    public void
        EventsHappeningReturningMoreThanOnePassableGameEventThrowsNotImplementedException()
    {
        // Arrange
        var activePlayer = new Mock<IPlayerV2>();
        activePlayer.SetupGet(x => x.Deck.HasCards).Returns(true);
        var nonActivePlayer = new Mock<IPlayerV2>();
        nonActivePlayer.SetupGet(x => x.Deck.HasCards).Returns(true);
        var state = new Mock<IGameState>();
        state.SetupGet(x => x.ActivePlayer).Returns(activePlayer.Object);
        state.SetupGet(x => x.NonActivePlayers).Returns([
            nonActivePlayer.Object]);
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
        Assert.Equal(state.Object, game.State);
    }

    [Fact]
    public void GameEnds()
    {
        // Arrange
        var activePlayer = new Mock<IPlayerV2>();
        activePlayer.SetupGet(x => x.Deck.HasCards).Returns(true);
        var nonActivePlayer = new Mock<IPlayerV2>();
        nonActivePlayer.SetupGet(x => x.Deck.HasCards).Returns(true);
        var state = new Mock<IGameState>();
        state.SetupGet(x => x.ActivePlayer).Returns(activePlayer.Object);
        state.SetupGet(x => x.NonActivePlayers).Returns([
            nonActivePlayer.Object]);
        var gameEvent = new Mock<IPassableGameEvent>();
        state.SetupGet(x => x.PassableAction).Returns(gameEvent.Object);
        gameEvent.Setup(x => x.Validate(gameEvent.Object));
        state.Setup(x => x.EventsThatWouldHappen.Get()).Returns([]);
        state.SetupGet(x => x.EventsHappening.IsEmpty).Returns(false);
        state.Setup(x => x.EventsHappening.Happen(state.Object)).Returns([]);
        state.SetupSequence(x => x.GameOver).Returns(false).Returns(true);
        var game = CreateGame(state.Object);
        
        // Act
        var playState = game.Play(Mock.Of<IPassableGameEvent>());

        // Assert
        Assert.Equal(state.Object, game.State);
        Assert.Equal(PlayState.GameOver, playState);
    }

    [Fact]
    public void GameHasStartedAlready()
    {
        // Arrange
        var state = Mock.Of<IGameState>();
        var game = CreateGame(state);
        var startingPlayer = Mock.Of<IPlayerV2>();
        var otherPlayer = Mock.Of<IPlayerV2>();
        var startGame = Mock.Of<IStartGameEvent>();
        
        // Act
        var ex = Assert.Throws<InvalidOperationException>(
            () => game.Play(startGame));

        // Assert
        Assert.Equal(state, game.State);
        Assert.Equal("Game has started already", ex.Message);
    }

    [Fact]
    public void GameStarts()
    {
        // Arrange
        var randomizer = Mock.Of<IRandomizer>();
        var game = new Game();
        var startingPlayer = new Mock<IPlayerV2>();
        startingPlayer.Setup(x => x.Deck.Shuffle(randomizer));
        startingPlayer.SetupGet(x => x.Deck.HasCards).Returns(false);
        var otherPlayer = new Mock<IPlayerV2>();
        otherPlayer.Setup(x => x.Deck.Shuffle(randomizer));
        otherPlayer.SetupGet(x => x.Deck.HasCards).Returns(false);
        var startGame = new Mock<IStartGameEvent>();
        startGame.SetupGet(x => x.Player).Returns(startingPlayer.Object);
        startGame.SetupGet(x => x.OtherPlayer).Returns(otherPlayer.Object);
        
        // Act
        var playState = game.Play(startGame.Object);

        // Assert
        Assert.Equal(
            [startingPlayer.Object, otherPlayer.Object], game.State.Losers);
        Assert.Equal(PlayState.GameOver, playState);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void GameHasAlreadyEnded(bool ended)
    {
        // Arrange
        var state = new Mock<IGameState>();
        state.Setup(x => x.GameOver).Returns(ended);
        var game = CreateGame(state.Object);
        
        // Act
        var ex = Assert.Throws<InvalidOperationException>(
            () => game.Play(Mock.Of<IGameEventV2>()));

        // Assert
        Assert.Equal(state.Object, game.State);
        Assert.Equal(
            ended ? "Game has ended already" : "No passable action found",
            ex.Message);
    }

    [Fact]
    public void Concede()
    {
        // Arrange
        var state = new Mock<IGameState>();
        var game = CreateGame(state.Object);
        var concede = new Mock<IConcedeEvent>();
        
        // Act
        var playState = game.Play(concede.Object);

        // Assert
        Assert.Equal(state.Object, game.State);
        concede.Verify(x => x.Happen(state.Object));
        Assert.Equal(PlayState.GameOver, playState);
    }

    [Fact]
    public void UnexpectedPlayerTakingAction()
    {
        // Arrange
        var state = new Mock<IGameState>();
        var passableAction = new Mock<IPassableGameEvent>();
        passableAction.SetupGet(x => x.Player).Returns(Mock.Of<IPlayerV2>());
        state.SetupGet(x => x.PassableAction).Returns(passableAction.Object);
        var game = CreateGame(state.Object);
        var gameEvent = new Mock<IGameEventV2>();
        gameEvent.SetupGet(x => x.Player).Returns(Mock.Of<IPlayerV2>());
        
        // Act
        var illegalActionException = Assert.Throws<IllegalActionException>(
            () => game.Play(gameEvent.Object));

        // Assert
        Assert.Equal(
            IllegalActionType.UnexpectedPlayer, illegalActionException.Type);
        Assert.Equal(state.Object, game.State);
    }

    [Fact]
    public void LoopCounterFull()
    {
        // Arrange
        var activePlayer = new Mock<IPlayerV2>();
        activePlayer.SetupGet(x => x.Deck.HasCards).Returns(true);
        var nonActivePlayer = new Mock<IPlayerV2>();
        nonActivePlayer.SetupGet(x => x.Deck.HasCards).Returns(true);
        var state = new Mock<IGameState>();
        state.SetupGet(x => x.ActivePlayer).Returns(activePlayer.Object);
        state.SetupGet(x => x.NonActivePlayers).Returns([
            nonActivePlayer.Object]);
        var passableAction = new Mock<IPassableGameEvent>();
        passableAction.SetupGet(x => x.Player).Returns(activePlayer.Object);
        state.SetupGet(x => x.PassableAction).Returns(passableAction.Object);
        state.Setup(x => x.EventsThatWouldHappen.Get()).Returns([]);
        state.SetupGet(x => x.EventsHappening.IsEmpty).Returns(false);
        var gameEvent = new Mock<IGameEventV2>();
        gameEvent.SetupGet(x => x.Player).Returns(activePlayer.Object);
        var game = CreateGame(state.Object, maxloopCount: 0);
        
        // Act
        var ex = Assert.Throws<InvalidOperationException>(
            () => game.Play(gameEvent.Object));

        // Assert
        Assert.Equal(state.Object, game.State);
        Assert.Equal("Looped too many times", ex.Message);
    }

    public enum TestMode
    {
        EventsHappeningPops,
        Passable,
        NotPassable,
    }

    [Theory]
    [InlineData(TestMode.EventsHappeningPops)]
    [InlineData(TestMode.Passable)]
    [InlineData(TestMode.NotPassable)]
    public void GameEndsSuccessfully(TestMode testMode)
    {
        // Arrange
        var activePlayer = new Mock<IPlayerV2>();
        activePlayer.SetupGet(x => x.Deck.HasCards).Returns(true);
        var nonActivePlayer = new Mock<IPlayerV2>();
        nonActivePlayer.SetupGet(x => x.Deck.HasCards).Returns(true);
        var state = new Mock<IGameState>();
        state.SetupGet(x => x.ActivePlayer).Returns(activePlayer.Object);
        state.SetupGet(x => x.NonActivePlayers).Returns([
            nonActivePlayer.Object]);
        var passableAction = new Mock<IPassableGameEvent>();
        passableAction.SetupGet(x => x.Player).Returns(activePlayer.Object);
        state.SetupGet(x => x.PassableAction).Returns(passableAction.Object);
        state.Setup(x => x.EventsHappening.Push());
        var wouldHappen = Mock.Of<IGameEventV2>();
        state.Setup(x => x.EventsThatWouldHappen.Get()).Returns([wouldHappen]);
        state.SetupSequence(x => x.GameOver)
                .Returns(false).Returns(false).Returns(true);
        state.SetupGet(x => x.EventsHappening.IsEmpty).Returns(false);
        var gameEvent = new Mock<IGameEventV2>();
        gameEvent.SetupGet(x => x.Player).Returns(activePlayer.Object);
        var game = CreateGame(state.Object, maxloopCount: 1);
        var passable = Mock.Of<IPassableGameEvent>();
        if (testMode == TestMode.Passable)
        {
            state.Setup(x => x.EventsHappening.Happen(state.Object)).Returns([
                passable
            ]);
        }
        var notPassable = Mock.Of<IGameEventV2>();
        if (testMode == TestMode.NotPassable)
        {
            state.Setup(x => x.EventsHappening.Happen(state.Object)).Returns([
                notPassable
            ]);
        }
        
        // Act
        var playState = game.Play(gameEvent.Object);

        // Assert
        Assert.Equal(state.Object, game.State);
        if (testMode == TestMode.EventsHappeningPops)
        {
            state.Verify(x => x.EventsThatWouldHappen.Clear());
            state.Verify(x => x.EventsHappening.Push(wouldHappen));  
            state.Verify(x => x.EventsHappening.Pop());
            Assert.Equal(PlayState.GameOver, playState);
        }
        if (testMode == TestMode.Passable)
        {
            state.VerifySet(x => x.PassableAction = passable);
            Assert.Equal(PlayState.Action, playState);
        }
        if (testMode == TestMode.NotPassable)
        {
            state.Verify(x => x.EventsThatWouldHappen.Add(notPassable));
            Assert.Equal(PlayState.GameOver, playState);
        }
    }

    static Game CreateGame(IGameState state, int maxloopCount = 99) => new(
        state, maxloopCount);
}