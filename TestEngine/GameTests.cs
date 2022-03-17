using Engine;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace TestEngine
{
    public class GameTests
    {
        [Fact]
        public void Play_EmptyDeck_ThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => new Game().Play(Mock.Of<Player>(), Mock.Of<Player>()));
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
