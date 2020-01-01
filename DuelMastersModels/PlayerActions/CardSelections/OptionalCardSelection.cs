using DuelMastersModels.Cards;

namespace DuelMastersModels.PlayerActions.CardSelections
{
    /// <summary>
    /// Player may select up to one card.
    /// </summary>
    public abstract class OptionalCardSelection : CardSelection
    {
        internal OptionalCardSelection(Player player, ReadOnlyCardCollection cards) : base(player, 0, 1, cards)
        { }

        internal Card SelectedCard { get; set; }

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

        internal bool Validate(Card card)
        {
            return card == null || Cards.Contains(card);
        }

        internal abstract PlayerAction Perform(Duel duel, Card card);
    }
}
