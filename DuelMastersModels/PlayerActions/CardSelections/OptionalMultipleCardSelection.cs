using DuelMastersModels.Cards;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.PlayerActions.CardSelections
{
    /// <summary>
    /// Player selects up to a number of cards.
    /// </summary>
    public abstract class OptionalMultipleCardSelection<TCard> : MultipleCardSelection<TCard> where TCard : ICard
    {
        internal OptionalMultipleCardSelection(IPlayer player, IEnumerable<TCard> cards) : base(player, cards, false, cards.Count())
        { }

        internal Collection<TCard> SelectedCards { get; } = new Collection<TCard>();

        public override IPlayerAction TryToPerformAutomatically(IDuel duel)
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