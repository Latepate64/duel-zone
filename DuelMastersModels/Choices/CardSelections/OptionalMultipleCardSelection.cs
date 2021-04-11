using DuelMastersModels.Cards;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersModels.Choices.CardSelections
{
    /// <summary>
    /// Player selects up to a number of cards.
    /// </summary>
    public abstract class OptionalMultipleCardSelection<TCard> : MultipleCardSelection<TCard> where TCard : ICard
    {
        internal OptionalMultipleCardSelection(IPlayer player, IEnumerable<TCard> cards) : base(player, cards, false, cards.Count())
        { }

        internal override void Validate(IEnumerable<TCard> cards)
        {
            if (cards.Except(Cards).Any())
            {
                throw new Exceptions.MultipleCardSelectionException(ToString());
            }
        }
    }
}