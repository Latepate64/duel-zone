using DuelMastersModels.Cards;
using DuelMastersModels.PlayerActions;
using DuelMastersModels.PlayerActions.CardSelections;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.Steps
{
    public enum MainStepState
    {
        Use,
        Pay,
        MustBeEnded,
    }

    /// <summary>
    /// 504.1. Normally, the active player can use cards only during their main step.
    /// </summary>
    public class MainStep : Step
    {
        public MainStepState State { get; set; } = MainStepState.Use;

        public Card CardToBeUsed { get; set; }

        public MainStep(Player player) : base(player)
        {
        }

        public override PlayerAction PlayerActionRequired(Duel duel)
        {
            Collection<Card> usableCards = GetUsableCards(ActivePlayer.Hand.Cards, ActivePlayer.ManaZone.UntappedCards);
            if (State == MainStepState.Use && usableCards.Count > 0)
            {
                return new UseCard(ActivePlayer, usableCards);
            }
            else if (State == MainStepState.Pay)
            {
                return new PayCost(ActivePlayer, ActivePlayer.ManaZone.UntappedCards, CardToBeUsed.Cost);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Returns the cards that can be used.
        /// </summary>
        private static Collection<Card> GetUsableCards(Collection<Card> handCards, Collection<Card> manaCards)
        {
            Collection<Card> usableCards = new Collection<Card>();
            foreach (Card handCard in handCards)
            {
                if (CanBeUsed(handCard, manaCards))
                {
                    usableCards.Add(handCard);
                }
            }
            return usableCards;
        }

        /// <summary>
        /// Checks if a card can be used.
        /// </summary>
        private static bool CanBeUsed(Card card, Collection<Card> manaCards)
        {
            System.Collections.Generic.IEnumerable<Civilization> manaCivilizations = manaCards.SelectMany(manaCard => manaCard.Civilizations).Distinct();
            return card.Cost <= manaCards.Count && card.Civilizations.Intersect(manaCivilizations).Count() == 1; //TODO: Add support for multicolored cards.
        }
    }
}
