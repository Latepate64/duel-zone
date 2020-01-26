using DuelMastersModels.Cards;
using System.Collections.Generic;

namespace DuelMastersModels.PlayerActions.CardSelections
{
    /// <summary>
    /// Player may declare shield trigger to be used.
    /// </summary>
    public class DeclareShieldTriggers : OptionalMultipleCardSelection<IHandCard>
    {
        internal DeclareShieldTriggers(Player player, IEnumerable<IHandCard> cards) : base(player, cards)
        { }

        internal override PlayerAction Perform(Duel duel, IEnumerable<IHandCard> cards)
        {
            foreach (IHandCard card in cards)
            {
                Player.AddShieldTriggerToUse(card);
            }
            return null;
        }
    }
}
