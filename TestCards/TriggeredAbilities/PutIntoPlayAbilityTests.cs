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
            var filter = new Mock<ICardFilter>();
            filter.Setup(x => x.Applies(It.IsAny<ICard>(), It.IsAny<Game>(), It.IsAny<Player>())).Returns(true);
            var e = Mock.Of<CardMovedEvent>();
            e.Destination = Common.ZoneType.BattleZone;
            Assert.True(new PutIntoPlayAbility(Mock.Of<IOneShotEffect>(), filter.Object).CanTrigger(e, Mock.Of<Game>()));
        }
    }
}
