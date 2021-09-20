using DuelMastersModels.Cards;
using System.Collections.Generic;

namespace DuelMastersModels.Choices.CardSelections
{
    /// <summary>
    /// Player may/must select a card.
    /// </summary>
    public abstract class SingleCardSelection : CardSelection
    {
        internal SingleCardSelection(Player player, IEnumerable<Card> cards, bool optional) : base(player, cards, optional ? 0 : 1, 1)
        { }

        internal abstract void Validate(Card card);
    }
}
