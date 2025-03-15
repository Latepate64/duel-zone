using Cards.TriggeredAbilities;
using Engine;
using Engine.Abilities;
using Engine.GameEvents;
using Moq;
using Xunit;

namespace TestCards.TriggeredAbilities;

public class WhenYouPutThisCreatureIntoTheBattleZoneAbilityTests
{
    [Fact]
    public void CanTriggerWhenCardMovesToBattleZone()
    {
        // Arrange
        var card = Mock.Of<ICard>();
        var ability = new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
            Mock.Of<IOneShotEffect>())
        {
            Source = card
        };
        var ev = new Mock<ICardMovedEvent>();
        ev.SetupGet(x => x.Destination).Returns(ZoneType.BattleZone);
        ev.SetupGet(x => x.CardInDestinationZone).Returns(card);
        var game = new Game();

        // Act
        var canTrigger = ability.CanTrigger(ev.Object, game);

        // Assert
        Assert.True(canTrigger);
    }
}
