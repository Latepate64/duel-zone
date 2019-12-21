using DuelMastersModels.Cards;
using DuelMastersModels.Steps;
using System;
using System.Collections.ObjectModel;

namespace DuelMastersModels.PlayerActions.CardSelections
{
    public class PayCost : MandatoryMultipleCardSelection
    {
        public int Cost { get; set; }

        public PayCost(Player player, Collection<Card> cards, int cost) : base(player, cost, cards)
        {
            Cost = cost;
        }

        public static bool Validate(Collection<Card> cards, Card cardToBeUsed)
        {
            return Duel.CanBeUsed(cardToBeUsed, cards);
        }

        public override PlayerAction Perform(Duel duel, Collection<Card> cards)
        {
            if (duel == null)
            {
                throw new ArgumentNullException("duel");
            }
            if (cards == null)
            {
                throw new ArgumentNullException("cards");
            }
            else if (duel.CurrentTurn.CurrentStep is MainStep mainStep)
            {
                foreach (Card card in cards)
                {
                    card.Tapped = true;
                }
                duel.PlayCard(mainStep.CardToBeUsed, Player);
                mainStep.CardToBeUsed = null;
                mainStep.State = MainStepState.Use;
                return null;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}
