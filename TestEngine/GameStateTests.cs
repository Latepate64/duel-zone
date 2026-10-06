using System;
using Engine;
using Interfaces;
using Interfaces.ContinuousEffects;
using Moq;
using Xunit;

namespace TestEngine;

public sealed class GameStateTests
{
    public enum Different
    {
        Type,
        ActivePlayer,
        NonActivePlayer,
        OtherWinner,
        Winner,
        Losers,
    }

    [Theory]
    [InlineData(Different.Type)]
    [InlineData(Different.ActivePlayer)]
    [InlineData(Different.NonActivePlayer)]
    [InlineData(Different.OtherWinner)]
    [InlineData(Different.Winner)]
    [InlineData(Different.Losers)]
    public void DoesNotEqual(Different testMode)
    {
        // Arrange
        var activePlayer = Mock.Of<IPlayerV2>();
        var nonActivePlayer = Mock.Of<IPlayerV2>();
        var state = new GameState(activePlayer, nonActivePlayer);
        if (testMode == Different.Winner)
        {
            state.Winner = activePlayer;
        }
        else if (testMode == Different.Losers)
        {
            state.Losers = [nonActivePlayer];
        }
        var other = testMode == Different.Type
            ? new object()
            : new GameState(
                testMode == Different.ActivePlayer ? null : activePlayer,
                testMode == Different.NonActivePlayer
                    ? null : nonActivePlayer)
            {
                Winner = testMode == Different.OtherWinner
                    ? nonActivePlayer : null
            };

        // Act
        var actual = state.Equals(other);
        
        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void DoesNotEqualWithDifferentEventsHappening()
    {
        // Arrange
        var activePlayer = Mock.Of<IPlayerV2>();
        var nonActivePlayer = Mock.Of<IPlayerV2>();
        var state = new GameState(activePlayer, nonActivePlayer);
        state.EventsHappening.Push(Mock.Of<IGameEventV2>());
        var other = new GameState(activePlayer, nonActivePlayer);

        // Act
        var actual = state.Equals(other);
        
        // Assert
        Assert.False(actual);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void DoesNotEqualWithDifferentPassableAction(bool first)
    {
        // Arrange
        var activePlayer = Mock.Of<IPlayerV2>();
        var nonActivePlayer = Mock.Of<IPlayerV2>();
        var passableAction = Mock.Of<IPassableGameEvent>();
        var state = new GameState(activePlayer, nonActivePlayer)
        {
            PassableAction = first ? passableAction : null
        };
        var other = new GameState(activePlayer, nonActivePlayer)
        {
            PassableAction = first ? null : passableAction
        };

        // Act
        var actual = state.Equals(other);
        
        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void DoesNotEqualWithDifferentEventsThatWouldHappen()
    {
        // Arrange
        var activePlayer = Mock.Of<IPlayerV2>();
        var nonActivePlayer = Mock.Of<IPlayerV2>();
        var state = new GameState(activePlayer, nonActivePlayer);
        state.EventsThatWouldHappen.Add(Mock.Of<IGameEventV2>());
        var other = new GameState(activePlayer, nonActivePlayer);

        // Act
        var actual = state.Equals(other);
        
        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void DoesNotEqualWithDifferentTurnNumber()
    {
        // Arrange
        var activePlayer = Mock.Of<IPlayerV2>();
        var nonActivePlayer = Mock.Of<IPlayerV2>();
        var state = new GameState(activePlayer, nonActivePlayer) {
            TurnNumber = 1
        };
        var other = new GameState(activePlayer, nonActivePlayer);

        // Act
        var actual = state.Equals(other);
        
        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void DoesNotEqualWithDifferentBattleZone()
    {
        // Arrange
        var activePlayer = Mock.Of<IPlayerV2>();
        var nonActivePlayer = Mock.Of<IPlayerV2>();
        var state = new GameState(activePlayer, nonActivePlayer);
        state.BattleZone.Add(Mock.Of<ICreature>());
        var other = new GameState(activePlayer, nonActivePlayer);

        // Act
        var actual = state.Equals(other);
        
        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void DoesNotEqualWithDifferentContinuousEffects()
    {
        // Arrange
        var activePlayer = Mock.Of<IPlayerV2>();
        var nonActivePlayer = Mock.Of<IPlayerV2>();
        var state = new GameState(activePlayer, nonActivePlayer);
        var effect = new Mock<IContinuousEffect>();
        effect.Setup(x => x.Copy()).Returns(effect.Object);
        var staticAbility = new Mock<IStaticAbility>();
        effect.SetupGet(x => x.Ability).Returns(staticAbility.Object);
        staticAbility.SetupGet(x => x.ContinuousEffects).Returns(
            [effect.Object]);
        state.ContinuousEffects.Add(Mock.Of<ICard>(), staticAbility.Object);
        var other = new GameState(activePlayer, nonActivePlayer);

        // Act
        var actual = state.Equals(other);
        
        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void EqualsAnother()
    {
        // Arrange
        var activePlayer = Mock.Of<IPlayerV2>();
        var nonActivePlayer = Mock.Of<IPlayerV2>();
        var state = new GameState(activePlayer, nonActivePlayer);
        var other = new GameState(activePlayer, nonActivePlayer);

        // Act
        var actual = state.Equals(other);
        
        // Assert
        Assert.True(actual);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void HashCodesAreEqualForEqualObjects(bool nulls)
    {
        // Arrange
        var activePlayer = new Mock<IPlayerV2>();
        activePlayer.Setup(x => x.Copy()).Returns(activePlayer.Object);
        var nonActivePlayer = new Mock<IPlayerV2>();
        nonActivePlayer.Setup(x => x.Copy()).Returns(nonActivePlayer.Object);
        var passableGameEvent = new Mock<IPassableGameEvent>();
        passableGameEvent.Setup(x => x.Copy()).Returns(
            passableGameEvent.Object);
        var first = new GameState(activePlayer.Object, nonActivePlayer.Object)
        {
            Winner = nulls ? null : activePlayer.Object,
            Losers = [nonActivePlayer.Object],
            PassableAction = nulls ? null : passableGameEvent.Object
        };
        var creature = new Mock<ICreature>();
        creature.Setup(x => x.Copy()).Returns(creature.Object);
        first.BattleZone.Add(creature.Object);
        var second = first.Copy();
        var expected = second.GetHashCode();

        // Act
        var actual = first.GetHashCode();

        // Assert
        Assert.Equal(expected, actual);
        Assert.NotEqual(nulls, first.GameOver);
    }

    [Fact]
    public void GameOverWhenActivePlayerAndNonActivePlayerDoNotExist()
    {
        // Arrange
        var activePlayer = new Mock<IPlayerV2>();
        var nonActivePlayer = new Mock<IPlayerV2>();
        var state = new GameState(activePlayer.Object, nonActivePlayer.Object)
        {
            ActivePlayer = null,
            NonActivePlayer = null
        };

        // Act
        var actual = state.GameOver;

        // Assert
        Assert.True(actual);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void GetOpponent(bool value)
    {
        // Arrange
        var first = Mock.Of<IPlayerV2>();
        var second = Mock.Of<IPlayerV2>();
        var state = new GameState(
            value ? first : second, value ? second : first);

        // Act
        var actual = state.GetOpponent(first);

        // Assert
        Assert.Equal(second, actual);
    }

    [Fact]
    public void OpponentNotFound()
    {
        // Arrange
        var state = new GameState(null, null);

        // Act
        var ex = Assert.Throws<InvalidOperationException>(
            () => state.GetOpponent(Mock.Of<IPlayerV2>()));

        // Assert
        Assert.Equal("Opponent not found", ex.Message);
    }
}