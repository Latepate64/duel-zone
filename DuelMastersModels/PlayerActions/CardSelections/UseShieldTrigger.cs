using DuelMastersModels.Cards;
using System.Collections.Generic;

namespace DuelMastersModels.PlayerActions.CardSelections
{
    /// <summary>
    /// Player must use a shield trigger.
    /// </summary>
    public class UseShieldTrigger : MandatoryCardSelection<IHandCard>
    {
        internal UseShieldTrigger(IPlayer player, IEnumerable<IHandCard> cards) : base(player, cards) { }

        public override IPlayerAction Perform(IDuel duel, IHandCard card)
        {
            Player.Hand.Remove(card);
            duel.UseCard(Player, card);
            Player.RemoveShieldTriggerToUse(card);
            return null;
        }
    }
}
