using DuelMastersModels.Cards;
using System;

namespace DuelMastersModels.Managers
{
    internal class PlayerManager
    {
        internal Player Player1 { get; private set; }

        internal Player Player2 { get; private set; }

        internal PlayerManager(Player player1, Player player2)
        {
            Player1 = player1;
            Player2 = player2;
        }

        internal Player GetOwner(ICard card)
        {
            //TODO: test if works
            if (Player1.DeckBeforeDuel.Contains(card))
            //if (Player1.DeckBeforeDuel.Select(c => c.GameId).Contains(card.GameId))
            {
                return Player1;
            }
            else if (Player2.DeckBeforeDuel.Contains(card))
            //else if (Player2.DeckBeforeDuel.Select(c => c.GameId).Contains(card.GameId))
            {
                return Player2;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(card));
            }
        }

        internal Player GetOpponent(Player player)
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
