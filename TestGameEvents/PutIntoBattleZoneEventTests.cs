using GameEvents;
using Interfaces;
using Moq;

namespace TestGameEvents;

public class PutIntoBattleZoneEventTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var player = new Mock<IPlayerV2>();
        player.Setup(x => x.Copy()).Returns(player.Object);
        var card = new Mock<ICard>();
        card.Setup(x => x.Copy()).Returns(card.Object);
        var e = new PutIntoBattleZoneEvent(player.Object, card.Object);

        // Act
        var actual = e.Copy();
        
        // Assert
        Assert.Equal(e, actual);
    }

    public enum EventType
    {
        Null,
        MoveCardEvent,
        OtherThanMoveCardEvent
    }

    [Theory]
    [InlineData(EventType.MoveCardEvent)]
    [InlineData(EventType.OtherThanMoveCardEvent)]
    [InlineData(EventType.Null)]
    public void DoesNotEqualEventOfAnotherType(EventType eventType)
    {
        // Arrange
        var player = Mock.Of<IPlayerV2>();
        var card = Mock.Of<ICard>();
        var e = new PutIntoBattleZoneEvent(player, card);

        // Act
        var actual = e.Equals(eventType == EventType.MoveCardEvent
            ? new MoveTopCardOfDeckEvent(player, ZoneType.ManaZone)
            : eventType == EventType.OtherThanMoveCardEvent
                ? new AttackEvent(player)
                : null);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void DoesNotEqualEventWithDifferentCard()
    {
        // Arrange
        var player = Mock.Of<IPlayerV2>();
        var e = new PutIntoBattleZoneEvent(player, Mock.Of<ICard>());
        var another = new PutIntoBattleZoneEvent(player, Mock.Of<ICard>());

        // Act
        var actual = e.Equals(another);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void HashCodesAreEqualForEqualEvents()
    {
        // Arrange
        var player = Mock.Of<IPlayerV2>();
        var card = Mock.Of<ICard>();
        var e = new PutIntoBattleZoneEvent(player, card);
        var another = new PutIntoBattleZoneEvent(player, card);
        var expected = another.GetHashCode();

        // Act
        var actual = e.GetHashCode();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void CreatureIsPutIntoBattleZone()
    {
        // Arrange
        var ability = Mock.Of<IStaticAbility>();
        var creature = new Mock<ICreature>();
        creature.Setup(x => x.GetAbilities<IStaticAbility>()).Returns(
            [ability]);
        var player = new Mock<IPlayerV2>();
        player.Setup(x => x.Copy()).Returns(player.Object);
        player.Setup(x => x.Hand.Remove(creature.Object));
        player.Setup(x => x.ManaZone.Add(creature.Object));
        var e = new PutIntoBattleZoneEvent(player.Object, creature.Object);
        var state = new Mock<IGameState>();
        state.Setup(x => x.BattleZone.Add(creature.Object));
        state.Setup(x => x.ContinuousEffects.Add(creature.Object));

        // Act
        var events = e.Happen(state.Object);
        
        // Assert
        Assert.Empty(events);
        player.Verify(x => x.Hand.Remove(creature.Object));
        state.Verify(x => x.BattleZone.Add(creature.Object));
        state.Verify(x => x.ContinuousEffects.Add(creature.Object));
    }
}