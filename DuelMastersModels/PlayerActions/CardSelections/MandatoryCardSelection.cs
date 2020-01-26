using DuelMastersModels.Cards;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersModels.PlayerActions.CardSelections
{
    /// <summary>
    /// Player must select a card.
    /// </summary>
    public abstract class MandatoryCardSelection<TCard> : SingleCardSelection<TCard> where TCard : ICard
    {
        internal MandatoryCardSelection(Player player, IEnumerable<TCard> cards) : base(player, cards, false)
        { }

        internal override PlayerAction TryToPerformAutomatically(Duel duel)
        {
            return Cards.Count() == 1 ? Perform(duel, Cards.First()) : (this);
        }

        internal override void Validate(TCard card)
        {
            if (!Cards.Contains(card))
            {
                throw new Exceptions.MandatoryCardSelectionException(ToString());
            }
        }
    }
}