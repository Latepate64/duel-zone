using System;
using Engine;
using Engine.Steps;
using Moq;
using Xunit;

namespace TestEngine;

public class TurnTests
{
    [Fact]
    public void Copy()
    {
        // Arrange
        var activePlayer = Mock.Of<IPlayer>();
        var nonActivePlayer = Mock.Of<IPlayer>();
        var turn = new Turn(activePlayer, nonActivePlayer);
        var phase = new Mock<IPhase>();
        phase.Setup(x => x.Copy()).Returns(phase.Object);
        phase.SetupGet(x => x.GameEvents).Returns([]);
        turn.AddPhase(phase.Object);

        // Act
        var copy = turn.Copy();

        // Assert
        Assert.Equal(turn, copy);
        Assert.NotEqual(turn, new Turn(activePlayer, nonActivePlayer));
        Assert.Equal(turn.CurrentPhase, copy.CurrentPhase);
        Assert.Equal(turn.GameEvents, copy.GameEvents);
        Assert.NotEqual(turn.GetHashCode(), copy.GetHashCode());
    }

    [Fact]
    public void TurnCanBePlayedIfItHasNoPhases()
    {
        // Arrange
        var activePlayer = Mock.Of<IPlayer>();
        var nonActivePlayer = Mock.Of<IPlayer>();
        var turn = new Turn(activePlayer, nonActivePlayer);
        var game = Mock.Of<IGame>();

        // Act + Assert
        turn.Play(game, 1);
    }

    [Fact]
    public void TurnCannotBePlayedIfItHasPhases()
    {
        // Arrange
        var activePlayer = Mock.Of<IPlayer>();
        var nonActivePlayer = Mock.Of<IPlayer>();
        var turn = new Turn(activePlayer, nonActivePlayer);
        var phase = Mock.Of<IPhase>();
        turn.AddPhase(phase);
        var game = Mock.Of<IGame>();

        // Act + Assert
        _ = Assert.Throws<InvalidOperationException>(() => turn.Play(game, 1));
    }

    [Fact]
    public void CurrentPhaseCanBeStarted()
    {
        // Arrange
        var activePlayer = Mock.Of<IPlayer>();
        var nonActivePlayer = Mock.Of<IPlayer>();
        var turn = new Turn(activePlayer, nonActivePlayer);
        var game = Mock.Of<IGame>();
        var nextPhase = Mock.Of<IPhase>();
        var phase = new Mock<IPhase>();
        phase.Setup(x => x.GetNextPhase(game)).Returns(nextPhase);
        turn.AddPhase(phase.Object);

        // Act + Assert
        turn.StartCurrentPhase(game);
    }
}
