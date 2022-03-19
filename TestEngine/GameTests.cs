using Engine;
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
            new Game().Play(GetPlayerMock(), GetPlayerMock());
        }

        private static Player GetPlayerMock()
        {
            List<Card> cards = new();
            for (int i = 0; i < 40; ++i)
            {
                cards.Add(Mock.Of<Card>());
            }
            var player = Mock.Of<Player>();
            player.Deck.Setup(cards, player.Id);
            return player;
        }
    }
}
