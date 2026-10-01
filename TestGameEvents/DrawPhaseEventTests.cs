using GameEvents;
using Interfaces;
using Moq;

namespace TestGameEvents;

public class DrawPhaseEventTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var player = new Mock<IPlayerV2>();
        player.Setup(x => x.Copy()).Returns(player.Object);
        var e = new DrawPhaseEvent(player.Object);

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
        player.Setup(x => x.Copy()).Returns(player.Object);
        var first = new DrawPhaseEvent(player.Object);
        GameEventV2 second = different == Different.Event
            ? new AttackEvent(player.Object)
            : new DrawPhaseEvent(different == Different.Player
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
    public void MoveTopCardOfDeckEventHappensAndNothingHappensAfterwards()
    {
        // Arrange
        var player = Mock.Of<IPlayerV2>();
        var e = new DrawPhaseEvent(player);
        var state = Mock.Of<IGameState>();
        var expected = new MoveTopCardOfDeckEvent(player, ZoneType.Hand);

        // Act
        var events1 = e.Happen(state);
        var events2 = e.Happen(state);
        
        // Assert
        Assert.Contains(expected, events1);
        Assert.Empty(events2);
    }

    [Fact]
    public void HashCodesAreEqualForEqualEvents()
    {
        // Arrange
        var player = Mock.Of<IPlayerV2>();
        var e = new DrawPhaseEvent(player);
        var another = new DrawPhaseEvent(player);
        var expected = another.GetHashCode();

        // Act
        var actual = e.GetHashCode();

        // Assert
        Assert.Equal(expected, actual);
    }
}