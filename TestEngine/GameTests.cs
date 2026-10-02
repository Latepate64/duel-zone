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
        var startingPlayer = Mock.Of<IPlayerV2>();
        var otherPlayer = Mock.Of<IPlayerV2>();
        var state = new Mock<IGameState>();
        state.SetupGet(x => x.PassableAction).Returns(
            Mock.Of<IPassableGameEvent>);
        state.Setup(x => x.EventsThatWouldHappen.Get()).Returns([]);
        state.SetupSequence(x => x.EventsHappening.IsEmpty)
            .Returns(true).Returns(false);
        state.SetupSequence(x => x.GameOver).Returns(false).Returns(true);
        state.SetupGet(x => x.TurnNumber).Returns(1);
        var game = CreateGame(state.Object);

        // Act
        game.Play(Mock.Of<IPassAction>());

        // Assert
        state.Verify(x => x.SwapActivePlayer());
        Assert.Equal(state.Object, game.State);
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
        Assert.Equal(state.Object, game.State);
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

    [Fact]
    public void GameHasStartedAlready()
    {
        // Arrange
        var state = Mock.Of<IGameState>();
        var game = CreateGame(state);
        var startingPlayer = Mock.Of<IPlayerV2>();
        var otherPlayer = Mock.Of<IPlayerV2>();
        
        // Act
        _ = Assert.Throws<InvalidOperationException>(
            () => game.Start(startingPlayer, otherPlayer));

        // Assert
        Assert.Equal(state, game.State);
    }

    [Fact]
    public void GameStarts()
    {
        // Arrange
        var randomizer = Mock.Of<IRandomizer>();
        var game = new Game(randomizer, 0);
        var startingPlayer = new Mock<IPlayerV2>();
        startingPlayer.Setup(x => x.Deck.Shuffle(randomizer));
        var otherPlayer = new Mock<IPlayerV2>();
        otherPlayer.Setup(x => x.Deck.Shuffle(randomizer));
        
        // Act
        game.Start(startingPlayer.Object, otherPlayer.Object);

        // Assert
        Assert.NotNull(game.State);
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
        _ = Assert.Throws<InvalidOperationException>(
            () => game.Play(Mock.Of<IGameEventV2>()));

        // Assert
        Assert.Equal(state.Object, game.State);
    }

    [Fact]
    public void Concede()
    {
        // Arrange
        var state = new Mock<IGameState>();
        var game = CreateGame(state.Object);
        var concede = new Mock<IConcedeEvent>();
        
        // Act
        game.Play(concede.Object);

        // Assert
        Assert.Equal(state.Object, game.State);
        concede.Verify(x => x.Happen(state.Object));
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
        var player = Mock.Of<IPlayerV2>();
        var passableAction = new Mock<IPassableGameEvent>();
        passableAction.SetupGet(x => x.Player).Returns(player);
        var state = new Mock<IGameState>();
        state.SetupGet(x => x.PassableAction).Returns(passableAction.Object);
        state.Setup(x => x.EventsThatWouldHappen.Get()).Returns([]);
        state.SetupGet(x => x.EventsHappening.IsEmpty).Returns(false);
        var gameEvent = new Mock<IGameEventV2>();
        gameEvent.SetupGet(x => x.Player).Returns(player);
        var game = CreateGame(state.Object, maxloopCount: 0);
        
        // Act
        _ = Assert.Throws<InvalidOperationException>(
            () => game.Play(gameEvent.Object));

        // Assert
        Assert.Equal(state.Object, game.State);
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
        var player = Mock.Of<IPlayerV2>();
        var passableAction = new Mock<IPassableGameEvent>();
        passableAction.SetupGet(x => x.Player).Returns(player);
        var state = new Mock<IGameState>();
        state.SetupGet(x => x.PassableAction).Returns(passableAction.Object);
        state.Setup(x => x.EventsHappening.Push());
        var wouldHappen = Mock.Of<IGameEventV2>();
        state.Setup(x => x.EventsThatWouldHappen.Get()).Returns([wouldHappen]);
        state.SetupSequence(x => x.GameOver)
                .Returns(false).Returns(false).Returns(true);
        state.SetupGet(x => x.EventsHappening.IsEmpty).Returns(false);
        var gameEvent = new Mock<IGameEventV2>();
        gameEvent.SetupGet(x => x.Player).Returns(player);
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
        game.Play(gameEvent.Object);

        // Assert
        Assert.Equal(state.Object, game.State);
        if (testMode == TestMode.EventsHappeningPops)
        {
            state.Verify(x => x.EventsThatWouldHappen.Clear());
            state.Verify(x => x.EventsHappening.Push(wouldHappen));  
            state.Verify(x => x.EventsHappening.Pop());
        }
        if (testMode == TestMode.Passable)
        {
            state.VerifySet(x => x.PassableAction = passable);
        }
        if (testMode == TestMode.NotPassable)
        {
            state.Verify(x => x.EventsThatWouldHappen.Add(notPassable));
        }
    }

    static Game CreateGame(IGameState state, int maxloopCount = 99) => new(
        Mock.Of<IRandomizer>(), state, maxloopCount);
}