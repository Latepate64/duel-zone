using System;
using DuelMastersModels.Cards;

namespace DuelMastersModels.PlayerActions.CardSelections
{
    /// <summary>
    /// Player chooses one of their shields and puts it into their hand. They can't use the "shield trigger" ability of that shield.
    /// </summary>
    public class ChooseOneOfYourShieldsAndPutItIntoYourHandYouCannotUseTheShieldTriggerAbilityOfThatShield : MandatoryCardSelection<IShieldZoneCard>
    {
        internal ChooseOneOfYourShieldsAndPutItIntoYourHandYouCannotUseTheShieldTriggerAbilityOfThatShield(Player player) : base(player, player.ShieldZone.Cards) { }

        internal override PlayerAction Perform(Duel duel, IShieldZoneCard card)
        {
            if (duel == null)
            {
                throw new ArgumentNullException(nameof(duel));
            }
            else if (card != null)
            {
                _ = duel.PutFromShieldZoneToHand(Player, card, false);
            }
            return null;
        }
    }
}
