using DuelMastersModels.Cards;
using System.Linq;

namespace DuelMastersModels.PlayerActions.CardSelections
{
    /// <summary>
    /// Player selects up to a number of cards.
    /// </summary>
    public abstract class MultipleCardSelection<TCard> : CardSelection<TCard> where TCard : ICard
    {
        internal MultipleCardSelection(Player player, ReadOnlyCardCollection<TCard> cards) : base(player, 0, cards.Count, cards)
        { }

        internal CardCollection<TCard> SelectedCards { get; } = new CardCollection<TCard>();

        internal override PlayerAction TryToPerformAutomatically(Duel duel)
        {
            return Cards.Count == 0 ? Perform(duel, Cards) : (this);
        }

        internal void Validate(ReadOnlyCardCollection<TCard> cards)
        {
            if (cards.Except(Cards).Any())
            {
                throw new Exceptions.MultipleCardSelectionException(ToString());
            }
        }

        internal abstract PlayerAction Perform(Duel duel, ReadOnlyCardCollection<TCard> cards);
    }
}