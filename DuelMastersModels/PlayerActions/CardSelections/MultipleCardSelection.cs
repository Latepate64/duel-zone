using DuelMastersModels.Cards;
using System.Collections.Generic;

namespace DuelMastersModels.PlayerActions.CardSelections
{
    /// <summary>
    /// Player may/must select cards.
    /// </summary>
    public abstract class MultipleCardSelection<TCard> : CardSelection<TCard> where TCard : ICard
    {
        internal MultipleCardSelection(Player player, ReadOnlyCardCollection<TCard> cards, bool optional, int maximum) : base(player, optional ? 0 : maximum, maximum, cards)
        { }

        internal abstract void Validate(IEnumerable<TCard> cards);
        internal abstract PlayerAction Perform(Duel duel, IEnumerable<TCard> card);
    }
}
