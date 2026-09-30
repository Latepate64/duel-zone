using GameEvents;
using Interfaces;
using Moq;

namespace TestGameEvents;

public class ChargePhaseEventTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var player = new Mock<IPlayerV2>();
        player.Setup(x => x.Copy()).Returns(player.Object);
        var e = new ChargePhaseEvent(player.Object);

        // Act
        var actual = e.Copy();
        
        // Assert
        Assert.Equal(e, actual);
    }

    public enum Different
    {
        Player,
        Event,
        ShouldEnd
    }

    [Theory]
    [InlineData(Different.Player)]
    [InlineData(Different.Event)]
    [InlineData(Different.ShouldEnd)]
    public void CopyWithDifferentPropertiesDoesNotEqualOriginal(
        Different different)
    {
        // Arrange
        var player = new Mock<IPlayerV2>();
        player.Setup(x => x.Hand.HasCards).Returns(true);
        var first = new ChargePhaseEvent(player.Object);
        GameEventV2 second = different == Different.Event
            ? new AttackEvent(player.Object)
            : new ChargePhaseEvent(
                different == Different.Player
                    ? Mock.Of<IPlayerV2>() : player.Object);
        if (different == Different.ShouldEnd)
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
        var e = new ChargePhaseEvent(player);
        var another = new ChargePhaseEvent(player);
        var expected = another.GetHashCode();

        // Act
        var actual = e.GetHashCode();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void LetActivePlayerChargeWhenHeHasHandCards()
    {
        // Arrange
        var player = new Mock<IPlayerV2>();
        player.Setup(x => x.Hand.HasCards).Returns(true);
        var e = new ChargePhaseEvent(player.Object);
        var expected = new ChargeEvent(player.Object);

        // Act
        var events = e.Happen(Mock.Of<IGameState>());

        // Assert
        Assert.Contains(expected, events);
    }

    [Fact]
    public void NothingHappensWhenActivePlayerHasNoHandCards()
    {
        // Arrange
        var player = new Mock<IPlayerV2>();
        player.Setup(x => x.Hand.HasCards).Returns(false);
        var e = new ChargePhaseEvent(player.Object);
        var expected = new ChargeEvent(player.Object);

        // Act
        var events = e.Happen(Mock.Of<IGameState>());

        // Assert
        Assert.Empty(events);
    }

    [Fact]
    public void NothingHappensAfterCharge()
    {
        // Arrange
        var player = new Mock<IPlayerV2>();
        player.Setup(x => x.Hand.HasCards).Returns(true);
        var e = new ChargePhaseEvent(player.Object);
        var expected = new ChargeEvent(player.Object);
        _ = e.Happen(Mock.Of<IGameState>());

        // Act
        var events = e.Happen(Mock.Of<IGameState>());

        // Assert
        Assert.Empty(events);
    }
}