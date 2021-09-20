using DuelMastersModels.Cards;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersModels.Choices.CardSelections
{
    /// <summary>
    /// Player must select a number of cards.
    /// </summary>
    public abstract class MandatoryMultipleCardSelection : MultipleCardSelection
    {
        internal MandatoryMultipleCardSelection(Player player, int amount, IEnumerable<Card> cards) : base(player, cards, false, amount)
        {
        }

        internal override void Validate(IEnumerable<Card> cards)
        {
            if (!(cards.Count() == MinimumSelection && !cards.Except(Cards).Any()))
            {
                throw new System.Exception(ToString());
            }
        }
    }
}
