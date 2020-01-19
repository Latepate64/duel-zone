using DuelMastersModels.Cards;


namespace DuelMastersModels.PlayerActions.CardSelections
{
    /// <summary>
    /// Player must select a card.
    /// </summary>
    public abstract class MandatoryCardSelection<TZoneCard> : CardSelection<TZoneCard> where TZoneCard : IZoneCard
    {
        internal MandatoryCardSelection(Player player, ReadOnlyCardCollection<TZoneCard> cards) : base(player, 1, 1, cards)
        { }

        internal override PlayerAction TryToPerformAutomatically(Duel duel)
        {
            return Cards.Count == 1 ? Perform(duel, Cards[0]) : (this);
        }

        internal void Validate(TZoneCard card)
        {
            if (!Cards.Contains(card))
            {
                throw new Exceptions.MandatoryCardSelectionException(ToString());
            }
        }

        internal abstract PlayerAction Perform(Duel duel, TZoneCard card);
    }
}