using DuelMastersModels.Cards;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.PlayerActions.CardSelections
{
    /// <summary>
    /// Player must select a number of cards.
    /// </summary>
    public abstract class MandatoryMultipleCardSelection<TCard> : CardSelection<TCard> where TCard : ICard
    {
        internal MandatoryMultipleCardSelection(Player player, int amount, ReadOnlyCardCollection<TCard> cards) : base(player, amount, amount, cards)
        {
        }

        internal override PlayerAction TryToPerformAutomatically(Duel duel)
        {
            return Cards.Count <= MaximumSelection ? Perform(duel, Cards) : (this);
        }

        internal abstract PlayerAction Perform(Duel duel, ReadOnlyCollection<TCard> cards);

        internal void Validate(ReadOnlyCollection<TCard> cards)
        {
            if (!(cards.Count == MinimumSelection && !cards.Except(Cards).Any()))
            {
                throw new Exceptions.MandatoryMultipleCardSelectionException(ToString());
            }
        }
    }
}
