using Cards.TriggeredAbilities;
using Common.GameEvents;
using Engine;
using Engine.Abilities;
using Moq;
using Xunit;

namespace TestCards.TriggeredAbilities
{
    public class PutIntoPlayAbilityTests
    {
        [Fact]
        public void CanTrigger_CardMovesToBattleZone_ReturnTrue()
        {
            var e = Mock.Of<CardMovedEvent>();
            e.Destination = Common.ZoneType.BattleZone;
            Assert.True(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(Mock.Of<IOneShotEffect>()).CanTrigger(e, Mock.Of<Game>()));
        }
    }
}
