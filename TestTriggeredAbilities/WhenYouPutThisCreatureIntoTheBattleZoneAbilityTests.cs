using Interfaces;
using Moq;
using TriggeredAbilities;

namespace TestTriggeredAbilities;

public class WhenYouPutThisCreatureIntoTheBattleZoneAbilityTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var effect = new Mock<IOneShotEffect>();
        effect.Setup(x => x.Copy()).Returns(effect.Object);
        var ability = new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
            effect.Object);

        // Act
        var copy = ability.Copy();

        // Assert
        Assert.Equal(ability, copy);
    }

    [Fact]
    public void DoesNotTriggerWhenCardDoesNotMove()
    {
        // Arrange
        var effect = Mock.Of<IOneShotEffect>();
        var ability = new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
            effect);
        var gameEvent = Mock.Of<IGameEvent>();

        // Act
        var actual = ability.CanTrigger(gameEvent, Mock.Of<IGame>());

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void DoesNotTriggerWhenCardDoesNotMoveIntoBattleZone()
    {
        // Arrange
        var effect = Mock.Of<IOneShotEffect>();
        var ability = new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
            effect);
        var gameEvent = new Mock<ICardMovedEvent>();
        gameEvent.SetupGet(x => x.Destination).Returns(ZoneType.ManaZone);

        // Act
        var actual = ability.CanTrigger(gameEvent.Object, Mock.Of<IGame>());

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void DoesNotTriggerWhenCardIsNotCreature()
    {
        // Arrange
        var gameEvent = new Mock<ICardMovedEvent>();
        gameEvent.SetupGet(x => x.Destination).Returns(ZoneType.BattleZone);
        gameEvent.SetupGet(x => x.CardInDestinationZone).Returns(
            Mock.Of<ICard>());
        var effect = Mock.Of<IOneShotEffect>();
        var ability = new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
            effect);

        // Act
        var actual = ability.CanTrigger(gameEvent.Object, Mock.Of<IGame>());

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void DoesNotTriggerWhenCreatureIsNotSource()
    {
        // Arrange
        var gameEvent = new Mock<ICardMovedEvent>();
        gameEvent.SetupGet(x => x.Destination).Returns(ZoneType.BattleZone);
        gameEvent.SetupGet(x => x.CardInDestinationZone).Returns(
            Mock.Of<ICreature>());
        var effect = Mock.Of<IOneShotEffect>();
        var ability = new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
            effect);

        // Act
        var actual = ability.CanTrigger(gameEvent.Object, Mock.Of<IGame>());

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void TriggersWhenSourceIsMovedIntoBattleZone()
    {
        // Arrange
        var creature = Mock.Of<ICreature>();
        var gameEvent = new Mock<ICardMovedEvent>();
        gameEvent.SetupGet(x => x.Destination).Returns(ZoneType.BattleZone);
        gameEvent.SetupGet(x => x.CardInDestinationZone).Returns(creature);
        var effect = Mock.Of<IOneShotEffect>();
        var ability = new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
            effect) { Source = creature };

        // Act
        var actual = ability.CanTrigger(gameEvent.Object, Mock.Of<IGame>());

        // Assert
        Assert.True(actual);
    }
}
