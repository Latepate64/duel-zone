using DuelMastersModels.PlayerActions;
using System;
using System.Linq;

namespace DuelMastersModels
{
    public class AIPlayer : Player
    {
        public void PerformPlayerAction(Duel duel, PlayerAction playerAction)
        {
            if (playerAction is ChargeMana chargeMana)
            {
                chargeMana.SelectedCard = Hand.Cards.First();
            }
            else
            {
                throw new ArgumentOutOfRangeException("playerAction");
            }
            playerAction.Perform(duel);
        }
    }
}
