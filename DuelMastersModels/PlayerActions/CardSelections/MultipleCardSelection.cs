using DuelMastersModels.Cards;
using System.Linq;

namespace DuelMastersModels.PlayerActions.CardSelections
{
    /// <summary>
    /// Player selects up to a number of cards.
    /// </summary>
    public abstract class MultipleCardSelection : CardSelection
    {
        internal MultipleCardSelection(Player player, ReadOnlyCardCollection cards) : base(player, 0, cards.Count, cards)
        { }

        internal CardCollection SelectedCards { get; } = new CardCollection();

        internal override PlayerAction TryToPerformAutomatically(Duel duel)
        {
            return Cards.Count == 0 ? Perform(duel, Cards) : (this);
        }

        internal void Validate(ReadOnlyCardCollection cards)
        {
            if (cards.Except(Cards).Any())
            {
                throw new Exceptions.MultipleCardSelectionException(ToString());
            }
        }

        internal abstract PlayerAction Perform(Duel duel, ReadOnlyCardCollection cards);
    }
}