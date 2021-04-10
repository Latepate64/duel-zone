using DuelMastersModels.Cards;
using System;

namespace DuelMastersModels.Managers
{
    internal class PlayerManager : IPlayerManager
    {
        public IPlayer Player1 { get; private set; }

        public IPlayer Player2 { get; private set; }

        public PlayerManager(IPlayer player1, IPlayer player2)
        {
            Player1 = player1;
            Player2 = player2;
        }

        public IPlayer GetOwner(ICard card)
        {
            if (Player1.AnyZoneContains(card))
            {
                return Player1;
            }
            else if (Player2.AnyZoneContains(card))
            {
                return Player2;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(card));
            }
        }

        public IPlayer GetOpponent(IPlayer player)
        {
            if (player == Player1)
            {
                return Player2;
            }
            else if (player == Player2)
            {
                return Player1;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(player));
            }
        }
    }
}
