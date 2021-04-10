using DuelMastersModels.PlayerActions;

namespace DuelMastersModels.Effects.OneShotEffects
{
    internal class YouMayAddACardFromYourHandToYourShieldsFaceDownIfYouDoChooseOneOfYourShieldsAndPutItIntoYourHandYouCannotUseTheShieldTriggerAbilityOfThatShieldEffect : OneShotEffect
    {
        internal override PlayerAction Apply(IDuel duel, IPlayer player)
        {
            return new PlayerActions.CardSelections.YouMayAddACardFromYourHandToYourShieldsFaceDownIfYouDoChooseOneOfYourShieldsAndPutItIntoYourHandYouCannotUseTheShieldTriggerAbilityOfThatShield(player);
        }
    }
}