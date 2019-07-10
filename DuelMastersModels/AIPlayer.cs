using DuelMastersModels.Cards;
using DuelMastersModels.PlayerActions;
using DuelMastersModels.PlayerActions.CardSelections;
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
                SelectCard(duel, cardSelection);
            }
            /*else if (playerAction is DeclareAttack declareAttack)
            {
                declareAttack.Declare(duel, declareAttack.CreaturesThatCanAttack.First(), null);
            }*/
            else
            {
                throw new ArgumentOutOfRangeException("playerAction");
            }
        }

        private static void SelectCard(Duel duel, CardSelection cardSelection)
        {
            if (cardSelection is OptionalCardSelection optionalCardSelection)
            {
                Card card = null;
                if (optionalCardSelection.Cards.Count > 1)
                {
                    card = optionalCardSelection.Cards.First();
                }
                optionalCardSelection.SelectedCard = card;
                optionalCardSelection.Perform(duel, card);
                duel.CurrentTurn.CurrentStep.PlayerActions.Add(optionalCardSelection);
            }
            else if (cardSelection is PayCost payCost)
            {
                Card civCard = payCost.Player.ManaZone.Cards.First(c => !c.Tapped && c.Civilizations.Intersect((duel.CurrentTurn.CurrentStep as Steps.MainStep).CardToBeUsed.Civilizations).Any());
                System.Collections.Generic.List<Card> manaCards = payCost.Player.ManaZone.Cards.Where(c => !c.Tapped && c != civCard).Take(payCost.Cost - 1).ToList();
                manaCards.Add(civCard);
                payCost.Perform(duel, new System.Collections.ObjectModel.Collection<Card>(manaCards));
            }
            else
            {
                throw new ArgumentOutOfRangeException("cardSelection");
            }
        }
    }
}
