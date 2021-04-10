using DuelMastersModels.Cards;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersModels.PlayerActions.CardSelections
{
    /// <summary>
    /// Player must select a number of cards.
    /// </summary>
    public abstract class MandatoryMultipleCardSelection<TCard> : MultipleCardSelection<TCard> where TCard : ICard
    {
        internal MandatoryMultipleCardSelection(IPlayer player, int amount, IEnumerable<TCard> cards) : base(player, cards, false, amount)
        {
        }

        public override IPlayerAction TryToPerformAutomatically(IDuel duel)
        {
            return Cards.Count() <= MaximumSelection ? Perform(duel, Cards) : (this);
        }

        internal override void Validate(IEnumerable<TCard> cards)
        {
            if (!(cards.Count() == MinimumSelection && !cards.Except(Cards).Any()))
            {
                throw new Exceptions.MandatoryMultipleCardSelectionException(ToString());
            }
        }
    }
}
