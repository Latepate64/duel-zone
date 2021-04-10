using DuelMastersModels.Cards;
using System.Collections.Generic;

namespace DuelMastersModels.PlayerActions.CardSelections
{
    /// <summary>
    /// Player may/must select cards.
    /// </summary>
    public abstract class MultipleCardSelection<TCard> : CardSelection<TCard> where TCard : ICard
    {
        internal MultipleCardSelection(IPlayer player, IEnumerable<TCard> cards, bool optional, int maximum) : base(player, cards, optional ? 0 : maximum, maximum)
        { }

        internal abstract void Validate(IEnumerable<TCard> cards);
        internal abstract IPlayerAction Perform(IDuel duel, IEnumerable<TCard> card);
    }
}
