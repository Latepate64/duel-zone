using DuelMastersModels.Cards;

namespace DuelMastersModels.PlayerActions.CardSelections
{
    public abstract class OptionalCardSelection : CardSelection
    {
        protected OptionalCardSelection() { }

        protected OptionalCardSelection(Player player, ReadOnlyCardCollection cards) : base(player, 0, 1, cards)
        { }

        public Card SelectedCard { get; set; }

        internal override PlayerAction TryToPerformAutomatically(Duel duel)
        {
            if (Cards.Count == 0)
            {
                return Perform(duel, null);
            }
            else
            {
                return this;
            }
        }

        public bool Validate(Card card)
        {
            return card == null || Cards.Contains(card);
        }

        public abstract PlayerAction Perform(Duel duel, Card card);
    }
}
