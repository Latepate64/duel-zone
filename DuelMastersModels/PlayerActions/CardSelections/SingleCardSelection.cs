using DuelMastersModels.Cards;
using System.Collections.Generic;

namespace DuelMastersModels.PlayerActions.CardSelections
{
    /// <summary>
    /// Player may/must select a card.
    /// </summary>
    public abstract class SingleCardSelection<TCard> : CardSelection<TCard> where TCard : ICard
    {
        internal SingleCardSelection(IPlayer player, IEnumerable<TCard> cards, bool optional) : base(player, cards, optional ? 0 : 1, 1)
        { }

        internal abstract void Validate(TCard card);
        internal abstract PlayerAction Perform(IDuel duel, TCard card);
    }
}
