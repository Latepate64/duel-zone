using GameEvents;
using Interfaces;
using Moq;

namespace TestGameEvents;

public class TakeTurnEventTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var player = new Mock<IPlayerV2>();
        player.Setup(x => x.Copy()).Returns(player.Object);
        var e = new TakeTurnEvent(player.Object, 1);

        // Act
        var actual = e.Copy();
        
        // Assert
        Assert.Equal(e, actual);
    }

    public enum Different
    {
        Player,
        Event,
        TurnNumber,
        NextPhase
    }

    [Theory]
    [InlineData(Different.Player)]
    [InlineData(Different.Event)]
    [InlineData(Different.TurnNumber)]
    [InlineData(Different.NextPhase)]
    public void CopyWithDifferentPropertiesDoesNotEqualOriginal(
        Different different)
    {
        // Arrange
        var player = new Mock<IPlayerV2>();
        player.Setup(x => x.Copy()).Returns(player.Object);
        var first = new TakeTurnEvent(player.Object, 1);
        GameEventV2 second = different == Different.Event
            ? new AttackEvent(player.Object)
            : new TakeTurnEvent(
                different == Different.Player
                    ? Mock.Of<IPlayerV2>() : player.Object,
                different == Different.TurnNumber
                    ? 2 : 1);
        if (different == Different.NextPhase)
        {
            second.Happen(Mock.Of<IGameState>());
        }

        // Act
        var actual = first.Equals(second);
        
        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void HashCodesAreEqualForEqualEvents()
    {
        // Arrange
        var player = Mock.Of<IPlayerV2>();
        var e = new TakeTurnEvent(player, 1);
        var another = new TakeTurnEvent(player, 1);
        var expected = another.GetHashCode();

        // Act
        var actual = e.GetHashCode();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(PhaseType.Draw)]
    [InlineData(PhaseType.Charge)]
    [InlineData(PhaseType.Main)]
    [InlineData(PhaseType.Attack)]
    [InlineData(PhaseType.EndOfTurn)]
    public void NextPhaseIsDrawAfterStartOfTurn(PhaseType phaseType)
    {
        // Arrange
        var player = Mock.Of<IPlayerV2>();
        var e = new TakeTurnEvent(player, 2);
        GameEventV2 expected = phaseType == PhaseType.Draw
            ? new StartOfTurnEvent(player)
            : phaseType == PhaseType.Charge
                ? new DrawPhaseEvent(player)
                : phaseType == PhaseType.Main
                    ? new ChargePhaseEvent(player)
                    : phaseType == PhaseType.EndOfTurn
                        ? new MainPhaseEvent(player)
                        : new AttackPhaseEvent(player);
        var state = Mock.Of<IGameState>();
        for (var i = 1; i < ((int)phaseType); ++i)
        {
            _ = e.Happen(state);
        }

        // Act
        var events = e.Happen(state);

        // Assert
        Assert.Equal(phaseType, e.NextPhase);
        Assert.Contains(expected, events);
    }

    [Fact]
    public void NextPhaseIsMainAfterDrawWhenTurnNumberIsOne()
    {
        // Arrange
        var player = Mock.Of<IPlayerV2>();
        var e = new TakeTurnEvent(player, 1);
        var expected = new ChargePhaseEvent(player);
        _ = e.Happen(Mock.Of<IGameState>());

        // Act
        var events = e.Happen(Mock.Of<IGameState>());

        // Assert
        Assert.Equal(PhaseType.Main, e.NextPhase);
        Assert.Contains(expected, events);
    }

    [Fact]
    public void NothingHappensAfterEndOfTurn()
    {
        // Arrange
        var player = Mock.Of<IPlayerV2>();
        var e = new TakeTurnEvent(player, 2);
        for (var i = 0; i < 5; ++i)
        {
            _ = e.Happen(Mock.Of<IGameState>());
        }

        // Act
        var events = e.Happen(Mock.Of<IGameState>());

        // Assert
        Assert.Equal(PhaseType.EndOfTurn, e.NextPhase);
        Assert.Empty(events);
    }
}