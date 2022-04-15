using Common.Choices;
using Engine;
using Engine.Zones;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace TestEngine
{
    public class GameTests
    {
        [Fact]
        public void Play_EmptyDeck_ThrowException()
        {
            var players = new List<IPlayer>();
            for (int i = 0; i < 2; ++i)
            {
                var player = new Mock<IPlayer>();
                player.SetupGet(x => x.Deck).Returns(new Engine.Zones.Deck());
                players.Add(player.Object);
            }
            Assert.Throws<InvalidOperationException>(() => new Game().Play(players.First(), players.Last()));
        }

        [Fact]
        public void Play_NonEmptyDeck_Pass()
        {
            var game = new Game();
            game.Play(GetPlayerMock(), GetPlayerMock());
        }

        private static IPlayer GetPlayerMock()
        {
            List<ICard> cards = new();
            for (int i = 0; i < 40; ++i)
            {
                cards.Add(Mock.Of<ICard>());
            }
            var player = new Mock<IPlayer>();
            var manaZone = new Mock<IManaZone>();
            manaZone.Setup(x => x.Cards).Returns(new List<ICard>());
            player.SetupGet(x => x.ManaZone).Returns(manaZone.Object);
            player.SetupGet(x => x.Hand).Returns(Mock.Of<Hand>());
            var decision = new Mock<IGuidDecision>();
            decision.Setup(x => x.Decision).Returns(new List<Guid>());
            var deck = new Mock<IDeck>();
            deck.Setup(x => x.Cards).Returns(cards);
            player.SetupGet(x => x.Deck).Returns(deck.Object);
            return player.Object;
        }
    }
}
