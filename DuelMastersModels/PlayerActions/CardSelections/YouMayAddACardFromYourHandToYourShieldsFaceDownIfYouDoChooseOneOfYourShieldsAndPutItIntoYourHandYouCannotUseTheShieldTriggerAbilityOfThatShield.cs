using DuelMastersModels.Cards;
using System;

namespace DuelMastersModels.PlayerActions.CardSelections
{
    /// <summary>
    /// Player may add a card from their hand to their shields face down. If they do, they choose one of their shields and put it into their hand. They can't use the "shield trigger" ability of that shield.
    /// </summary>
    public class YouMayAddACardFromYourHandToYourShieldsFaceDownIfYouDoChooseOneOfYourShieldsAndPutItIntoYourHandYouCannotUseTheShieldTriggerAbilityOfThatShield : OptionalCardSelection
    {
        internal YouMayAddACardFromYourHandToYourShieldsFaceDownIfYouDoChooseOneOfYourShieldsAndPutItIntoYourHandYouCannotUseTheShieldTriggerAbilityOfThatShield(Player player) : base(player, new ReadOnlyCardCollection(player.Hand.Cards))
        { }

        internal override PlayerAction Perform(Duel duel, Card card)
        {
            if (duel == null)
            {
                throw new ArgumentNullException("duel");
            }
            else if (card != null)
            {
                duel.AddFromYourHandToYourShieldsFaceDown(card);
                return new ChooseOneOfYourShieldsAndPutItIntoYourHandYouCannotUseTheShieldTriggerAbilityOfThatShield(Player);
            }
            else
            {
                return null;
            }
        }
    }
}
