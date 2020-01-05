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

        internal override PlayerAction TryToPerformAutomatically(Duel duel)
        {
            return Cards.Count == 0 ? Perform(duel, null) : (this);
        }

        internal void Validate(Card card)
        {
            if (!(card == null || Cards.Contains(card)))
            {
                throw new Exceptions.OptionalCardSelectionException(ToString());
            }
        }

        internal abstract PlayerAction Perform(Duel duel, Card card);
    }
}
