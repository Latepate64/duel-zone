using DuelMastersModels.Cards;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.PlayerActions.CardSelections
{
    /// <summary>
    /// Player must select a number of cards.
    /// </summary>
    public abstract class MandatoryMultipleCardSelection<TZoneCard> : CardSelection<TZoneCard> where TZoneCard : IZoneCard
    {
        internal MandatoryMultipleCardSelection(Player player, int amount, ReadOnlyCardCollection<TZoneCard> cards) : base(player, amount, amount, cards)
        {
        }

        internal override PlayerAction TryToPerformAutomatically(Duel duel)
        {
            return Cards.Count <= MaximumSelection ? Perform(duel, Cards) : (this);
        }

        internal abstract PlayerAction Perform(Duel duel, ReadOnlyCollection<TZoneCard> cards);

        internal void Validate(ReadOnlyCollection<TZoneCard> cards)
        {
            if (!(cards.Count == MinimumSelection && !cards.Except(Cards).Any()))
            {
                throw new Exceptions.MandatoryMultipleCardSelectionException(ToString());
            }
        }
    }
}
