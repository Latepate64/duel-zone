using DuelMastersModels.Cards;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersModels.PlayerActions.CardSelections
{
    /// <summary>
    /// Player selects up to a number of cards.
    /// </summary>
    public abstract class OptionalMultipleCardSelection<TCard> : MultipleCardSelection<TCard> where TCard : ICard
    {
        internal OptionalMultipleCardSelection(Player player, ReadOnlyCardCollection<TCard> cards) : base(player, cards, false, cards.Count)
        { }

        internal CardCollection<TCard> SelectedCards { get; } = new CardCollection<TCard>();

        internal override PlayerAction TryToPerformAutomatically(Duel duel)
        {
            return Cards.Any() ? (this) : Perform(duel, Cards);
        }

        internal override void Validate(IEnumerable<TCard> cards)
        {
            if (cards.Except(Cards).Any())
            {
                throw new Exceptions.MultipleCardSelectionException(ToString());
            }
        }
    }
}