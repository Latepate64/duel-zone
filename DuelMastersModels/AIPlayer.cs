using DuelMastersModels.PlayerActions;
using DuelMastersModels.PlayerActions.CardSelections;
using DuelMastersModels.PlayerActions.CreatureSelections;
using System;
using System.Linq;

namespace DuelMastersModels
{
    public class AIPlayer : Player
    {
        public static void PerformPlayerAction(Duel duel, PlayerAction playerAction)
        {
            if (duel == null)
            {
                throw new ArgumentNullException("duel");
            }
            if (playerAction is CardSelection cardSelection)
            {
                SelectCard(cardSelection);
            }
            else if (playerAction is CreatureSelection creatureSelection)
            {
                SelectCreature(creatureSelection);
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
            duel.CurrentTurn.CurrentStep.PlayerActions.Add(playerAction);
        }

        private static void SelectCard(CardSelection cardSelection)
        {
            if (cardSelection is ChargeMana chargeMana)
            {
                if (chargeMana.Cards.Count > 1)
                {
                    chargeMana.SelectedCard = chargeMana.Cards.First();
                }
            }
            else if (cardSelection is UseCardDeclaration useCardDeclaration)
            {
                useCardDeclaration.SelectedCard = useCardDeclaration.Cards.First();
            }
            else if (cardSelection is UseCardPayCivilization useCardPayCivilization)
            {
                useCardPayCivilization.SelectedCard = useCardPayCivilization.Cards.First();
            }
        }

        private static void SelectCreature(CreatureSelection creatureSelection)
        {
            creatureSelection.SelectedCreature = creatureSelection.Creatures.First();
        }
    }
}
