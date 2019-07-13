using DuelMastersModels.Cards;
using System.Collections.ObjectModel;

namespace DuelMastersModels.PlayerActions.CardSelections
{
    public abstract class OptionalCardSelection : CardSelection
    {
        protected OptionalCardSelection() { }

        protected OptionalCardSelection(Player player, Collection<Card> cards) : base(player, 0, 1, cards)
        { }

        public Card SelectedCard { get; set; }

        public override bool PerformAutomatically(Duel duel)
        {
            return Cards.Count == 0;
        }

        public bool Validate(Card card)
        {
            return card == null || Cards.Contains(card);
        }

        public abstract PlayerAction Perform(Duel duel, Card card);
    }
}
