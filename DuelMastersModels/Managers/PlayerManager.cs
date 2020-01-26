using DuelMastersModels.Cards;
using System;

namespace DuelMastersModels.Managers
{
    internal class PlayerManager : IPlayerManager
    {
        public Player Player1 { get; private set; }

        public Player Player2 { get; private set; }

        public PlayerManager(Player player1, Player player2)
        {
            Player1 = player1;
            Player2 = player2;
        }

        public Player GetOwner(ICard card)
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

        public Player GetOpponent(IPlayer player)
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
