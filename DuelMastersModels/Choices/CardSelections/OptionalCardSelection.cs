using DuelMastersModels.Cards;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersModels.Choices.CardSelections
{
    /// <summary>
    /// Player may select up to one card.
    /// </summary>
    public class OptionalCardSelection : SingleCardSelection
    {
        internal OptionalCardSelection(Player player, IEnumerable<Card> cards) : base(player, cards, true)
        { }

        internal override void Validate(Card card)
        {
            if (!(card == null || Cards.Contains(card)))
            {
                throw new System.Exception(ToString());
            }
        }
    }
}
