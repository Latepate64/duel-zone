using System;
using DuelMastersModels.Cards;

namespace DuelMastersModels.PlayerActions.CardSelections
{
    public class ChooseOneOfYourShieldsAndPutItIntoYourHandYouCannotUseTheShieldTriggerAbilityOfThatShield : MandatoryCardSelection
    {
        public ChooseOneOfYourShieldsAndPutItIntoYourHandYouCannotUseTheShieldTriggerAbilityOfThatShield(Player player) : base(player, player.ShieldZone.Cards) { }

        public override PlayerAction Perform(Duel duel, Card card)
        {
            if (duel == null)
            {
                throw new ArgumentNullException("duel");
            }
            else if (card != null)
            {
                duel.PutFromShieldZoneToHand(Player, card, false);
            }
            return null;
        }
    }
}
