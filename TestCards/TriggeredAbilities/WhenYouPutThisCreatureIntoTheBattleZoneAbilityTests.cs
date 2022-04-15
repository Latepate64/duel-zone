using Cards.TriggeredAbilities;
using Engine;
using Engine.Abilities;
using Engine.GameEvents;
using Moq;
using Xunit;

namespace TestCards.TriggeredAbilities
{
    public class WhenYouPutThisCreatureIntoTheBattleZoneAbilityTests
    {
        [Fact]
        public void CanTrigger_CardMovesToBattleZone_ReturnTrue()
        {
            var e = new Mock<ICardMovedEvent>();
            e.SetupGet(x => x.Card).Returns(Mock.Of<ICard>());
            e.SetupGet(x => x.Destination).Returns(ZoneType.BattleZone);
            var ability = new WhenYouPutThisCreatureIntoTheBattleZoneAbility(Mock.Of<IOneShotEffect>());
            Assert.True(ability.CanTrigger(e.Object, Mock.Of<IGame>()));
        }
    }
}
