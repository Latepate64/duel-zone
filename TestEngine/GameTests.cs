using Engine;
using System;
using Xunit;

namespace TestEngine
{
    public class GameTests
    {
        [Fact]
        public void Play_NoCardsInDecks_Pass()
        {
            new Game().Play(new PlayerMock(), new PlayerMock());
        }
    }

    class PlayerMock : Player
    {
        public PlayerMock()
        {
        }

        public PlayerMock(IPlayer player) : base(player)
        {
        }

        public override T ChooseAbstractly<T>(T choice)
        {
            throw new NotImplementedException();
        }

        public override IPlayer Copy()
        {
            return new PlayerMock(this);
        }
    }
}
