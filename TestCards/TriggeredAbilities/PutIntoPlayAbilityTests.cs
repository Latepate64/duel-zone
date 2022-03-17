﻿using Cards.TriggeredAbilities;
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
            var filter = new Mock<CardFilter>();
            filter.Setup(x => x.Applies(It.IsAny<Card>(), It.IsAny<Game>(), It.IsAny<Player>())).Returns(true);
            var e = Mock.Of<CardMovedEvent>();
            e.Destination = Common.ZoneType.BattleZone;
            Assert.True(new PutIntoPlayAbility(Mock.Of<OneShotEffect>(), filter.Object).CanTrigger(e, Mock.Of<Game>()));
        }
    }
}
