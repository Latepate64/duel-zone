using DuelMastersModels.Cards;
using System.Collections.Generic;

namespace DuelMastersModels.Choices.CardSelections
{
    /// <summary>
    /// Player may/must select cards.
    /// </summary>
    public abstract class MultipleCardSelection : CardSelection
    {
        internal MultipleCardSelection(Player player, IEnumerable<Card> cards, bool optional, int maximum) : base(player, cards, optional ? 0 : maximum, maximum)
        { }

        internal abstract void Validate(IEnumerable<Card> cards);
    }
}
