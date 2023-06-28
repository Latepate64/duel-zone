using Engine;
using System;

namespace Server
{
    public class ComputerPlayer : Player
    {
        static readonly Random Rnd = new();

        public ComputerPlayer() : base()
        {
        }

        public ComputerPlayer(Player player) : base(player)
        {
        }

        public override T ChooseAbstractly<T>(T choice)
        {
            throw new NotImplementedException();
        }

        public override IPlayer Copy()
        {
            throw new NotImplementedException();
        }
    }
}
