using DuelMastersModels.Cards;
using DuelMastersModels.Steps;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.PlayerActions.CardSelections
{
    public class PayCost : CardSelection
    {
        public int Cost { get; set; }

        public PayCost() { }

        public PayCost(Player player, Collection<Card> cards, int cost) : base(player, cost, cost, cards)
        {
            Cost = cost;
        }

        public override bool PerformAutomatically(Duel duel)
        {
            if (MinimumSelection == MaximumSelection && Cards.Count == MaximumSelection)
            {
                Perform(duel, Cards);
                return true;
            }
            return false;
        }

        public bool Validate(Collection<Card> cards, Card cardToBeUsed)
        {
            return Cards.Intersect(cards).Count() == Cost && CivilizationsPaid(cards, cardToBeUsed);
        }

        public void Perform(Duel duel, Collection<Card> cards)
        {
            if (duel == null)
            {
                throw new ArgumentNullException("duel");
            }
            if (cards == null)
            {
                throw new ArgumentNullException("cards");
            }
            else if (duel.CurrentTurn.CurrentStep is MainStep mainStep && CivilizationsPaid(cards, mainStep.CardToBeUsed))
            {
                foreach (Card card in cards)
                {
                    card.Tapped = true;
                }
                Player.BattleZone.Add(mainStep.CardToBeUsed);
                mainStep.CardToBeUsed = null;
                mainStep.State = MainStepState.Use;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        private bool CivilizationsPaid(Collection<Card> cards, Card cardToBeUsed)
        {
            return cards.SelectMany(c => c.Civilizations).Intersect(cardToBeUsed.Civilizations).Any();
            //TODO: Check that ALL civilization are paid.
        }
    }
}
