using DuelMastersModels.Cards;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersModels.PlayerActions.CardSelections
{
    /// <summary>
    /// Player may select up to one card.
    /// </summary>
    public abstract class OptionalCardSelection<TCard> : SingleCardSelection<TCard> where TCard : class, ICard
    {
        internal OptionalCardSelection(IPlayer player, IEnumerable<TCard> cards) : base(player, cards, true)
        { }

        public override IPlayerAction TryToPerformAutomatically(IDuel duel)
        {
            return Cards.Any() ? (this) : Perform(duel, null);
        }

        internal override void Validate(TCard card)
        {
            if (!(card == null || Cards.Contains(card)))
            {
                throw new Exceptions.OptionalCardSelectionException(ToString());
            }
        }
    }
}
