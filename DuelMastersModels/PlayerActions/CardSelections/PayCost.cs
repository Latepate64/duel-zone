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
        //public Collection<Civilization> Civilizations { get; } //TODO: Check that required civilizations are used in paying the mana cost.

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
            else if (duel.CurrentTurn.CurrentStep is MainStep mainStep && cards.SelectMany(c => c.Civilizations).Intersect(mainStep.CardToBeUsed. Civilizations).Any())
            {
                foreach (var card in cards)
                {
                    card.Tapped = true;
                }
                Player.BattleZone.Add(mainStep.CardToBeUsed);
                mainStep.CardToBeUsed = null;
                mainStep.State = MainStepState.Use;
            }
            else
            {
                throw new NotSupportedException();
            }
        }
    }
}
