using DuelMastersModels.Cards;
using System;

namespace DuelMastersModels.PlayerActions.CardSelections
{
    public class YouMayAddACardFromYourHandToYourShieldsFaceDownIfYouDoChooseOneOfYourShieldsAndPutItIntoYourHandYouCannotUseTheShieldTriggerAbilityOfThatShield : OptionalCardSelection
    {
        public YouMayAddACardFromYourHandToYourShieldsFaceDownIfYouDoChooseOneOfYourShieldsAndPutItIntoYourHandYouCannotUseTheShieldTriggerAbilityOfThatShield(Player player) : base(player, player.Hand.Cards)
        { }

        public override PlayerAction Perform(Duel duel, Card card)
        {
            if (duel == null)
            {
                throw new ArgumentNullException("duel");
            }
            else if (card != null)
            {
                Duel.AddFromYourHandToYourShieldsFaceDown(Player, card);
                return new ChooseOneOfYourShieldsAndPutItIntoYourHandYouCannotUseTheShieldTriggerAbilityOfThatShield(Player);
            }
            else
            {
                return null;
            } 
        }
    }
}
