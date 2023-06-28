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
            IGame game = new Game();
            game.Play(new PlayerMock(game), new PlayerMock(game));
        }
    }

    class PlayerMock : Player
    {
        public PlayerMock(IGame game) : base(game)
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
