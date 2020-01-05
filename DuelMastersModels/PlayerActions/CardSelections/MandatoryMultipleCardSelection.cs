using DuelMastersModels.Cards;
using System.Linq;

namespace DuelMastersModels.PlayerActions.CardSelections
{
    /// <summary>
    /// Player must select a number of cards.
    /// </summary>
    public abstract class MandatoryMultipleCardSelection : CardSelection
    {
        internal MandatoryMultipleCardSelection(Player player, int amount, ReadOnlyCardCollection cards) : base(player, amount, amount, cards)
        {
        }

        internal override PlayerAction TryToPerformAutomatically(Duel duel)
        {
            return Cards.Count <= MaximumSelection ? Perform(duel, Cards) : (this);
        }

        internal abstract PlayerAction Perform(Duel duel, ReadOnlyCardCollection cards);

        internal void Validate(ReadOnlyCardCollection cards)
        {
            if (!(cards.Count == MinimumSelection && !cards.Except(Cards).Any()))
            {
                throw new Exceptions.MandatoryMultipleCardSelectionException(ToString());
            }
        }
    }
}
