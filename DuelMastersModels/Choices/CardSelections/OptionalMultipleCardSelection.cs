using DuelMastersModels.Cards;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersModels.Choices.CardSelections
{
    /// <summary>
    /// Player selects up to a number of cards.
    /// </summary>
    public abstract class OptionalMultipleCardSelection : MultipleCardSelection
    {
        internal OptionalMultipleCardSelection(IPlayer player, IEnumerable<Card> cards) : base(player, cards, false, cards.Count())
        { }

        internal override void Validate(IEnumerable<Card> cards)
        {
            if (cards.Except(Cards).Any())
            {
                throw new System.Exception(ToString());
            }
        }
    }
}