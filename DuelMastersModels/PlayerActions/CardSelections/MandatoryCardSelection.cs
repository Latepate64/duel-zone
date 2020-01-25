using DuelMastersModels.Cards;


namespace DuelMastersModels.PlayerActions.CardSelections
{
    /// <summary>
    /// Player must select a card.
    /// </summary>
    public abstract class MandatoryCardSelection<TCard> : CardSelection<TCard> where TCard : ICard
    {
        internal MandatoryCardSelection(Player player, ReadOnlyCardCollection<TCard> cards) : base(player, 1, 1, cards)
        { }

        internal override PlayerAction TryToPerformAutomatically(Duel duel)
        {
            return Cards.Count == 1 ? Perform(duel, Cards[0]) : (this);
        }

        internal void Validate(TCard card)
        {
            if (!Cards.Contains(card))
            {
                throw new Exceptions.MandatoryCardSelectionException(ToString());
            }
        }

        internal abstract PlayerAction Perform(Duel duel, TCard card);
    }
}