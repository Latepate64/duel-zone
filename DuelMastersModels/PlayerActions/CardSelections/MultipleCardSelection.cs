using DuelMastersModels.Cards;
using System.Linq;

namespace DuelMastersModels.PlayerActions.CardSelections
{
    /// <summary>
    /// Player selects up to a number of cards.
    /// </summary>
    public abstract class MultipleCardSelection<TZoneCard> : CardSelection<TZoneCard> where TZoneCard : IZoneCard
    {
        internal MultipleCardSelection(Player player, ReadOnlyCardCollection<TZoneCard> cards) : base(player, 0, cards.Count, cards)
        { }

        internal CardCollection<TZoneCard> SelectedCards { get; } = new CardCollection<TZoneCard>();

        internal override PlayerAction TryToPerformAutomatically(Duel duel)
        {
            return Cards.Count == 0 ? Perform(duel, Cards) : (this);
        }

        internal void Validate(ReadOnlyCardCollection<TZoneCard> cards)
        {
            if (cards.Except(Cards).Any())
            {
                throw new Exceptions.MultipleCardSelectionException(ToString());
            }
        }

        internal abstract PlayerAction Perform(Duel duel, ReadOnlyCardCollection<TZoneCard> cards);
    }
}