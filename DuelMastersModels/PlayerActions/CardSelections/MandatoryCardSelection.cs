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
        internal MandatoryCardSelection(IPlayer player, IEnumerable<TCard> cards) : base(player, cards, false)
        { }

        public override IPlayerAction TryToPerformAutomatically(IDuel duel)
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