using DuelMastersModels.Cards;
using DuelMastersModels.Steps;
using System;
using System.Collections.Generic;

namespace DuelMastersModels.PlayerActions.CardSelections
{
    /// <summary>
    /// Player must pay the mana cost of a card.
    /// </summary>
    public class PayCost : MandatoryMultipleCardSelection<IManaZoneCard>
    {
        internal int Cost { get; set; }

        internal PayCost(IPlayer player, IEnumerable<IManaZoneCard> cards, int cost) : base(player, cost, cards)
        {
            Cost = cost;
        }

        internal void Validate(IEnumerable<IManaZoneCard> cards, Duel duel)
        {
            Validate(cards);
            if (!Duel.CanBeUsed((duel.CurrentTurn.CurrentStep as MainStep).CardToBeUsed, cards))
            {
                throw new Exceptions.PayCostException(ToString());
            }
        }

        internal override PlayerAction Perform(IDuel duel, IEnumerable<IManaZoneCard> cards)
        {
            if (duel == null)
            {
                throw new ArgumentNullException(nameof(duel));
            }
            if (cards == null)
            {
                throw new ArgumentNullException(nameof(cards));
            }
            else if (duel.CurrentTurn.CurrentStep is MainStep mainStep)
            {
                foreach (ManaZoneCard card in cards)
                {
                    card.Tapped = true;
                }
                duel.UseCard(Player, mainStep.CardToBeUsed);
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
