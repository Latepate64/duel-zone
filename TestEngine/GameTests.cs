using Engine;
using Moq;
using System;
using Xunit;

namespace TestEngine
{
    public class GameTests
    {
        [Fact]
        public void Play_EmptyDeck_ThrowException()
        {
            var game = new Game();
            var player1 = Mock.Of<Player>();
            var player2 = Mock.Of<Player>();
            Assert.Throws<InvalidOperationException>(() => game.Play(player1, player2));
        }
    }
}
