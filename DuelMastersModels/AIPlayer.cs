using DuelMastersModels.PlayerActions;
using System;
using System.Linq;

namespace DuelMastersModels
{
    public class AIPlayer : Player
    {
        public static void PerformPlayerAction(Duel duel, PlayerAction playerAction)
        {
            if (playerAction is ChargeMana chargeMana)
            {
                if (chargeMana.Cards.Count > 1)
                {
                    chargeMana.SelectedCard = chargeMana.Cards.First();
                }
            }
            else if (playerAction is UseCardDeclaration useCardDeclaration)
            {
                useCardDeclaration.SelectedCard = useCardDeclaration.Cards.First();
            }
            else if (playerAction is UseCardPayCivilization useCardPayCivilization)
            {
                useCardPayCivilization.SelectedCard = useCardPayCivilization.Cards.First();
            }
            else if (playerAction is UseCardPayRemainingMana useCardPayRemainingMana)
            {
                foreach (var card in useCardPayRemainingMana.ManaCards.ToList().GetRange(0, useCardPayRemainingMana.PayAmount))
                {
                    useCardPayRemainingMana.SelectedCards.Add(card);
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("playerAction");
            }
            playerAction.Perform(duel);
        }
    }
}
