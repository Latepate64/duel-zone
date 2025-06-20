using Engine.Abilities;

namespace Cards.OneShotEffects;

public class YouMayReturnCreatureFromYourGraveyardToYourHandEffect :
    ReturnUpToCreaturesFromYourGraveyardToYourHandEffect
{
    public YouMayReturnCreatureFromYourGraveyardToYourHandEffect() : base(1)
    {
    }

    public YouMayReturnCreatureFromYourGraveyardToYourHandEffect(
        ReturnUpToCreaturesFromYourGraveyardToYourHandEffect effect) : base(effect)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new YouMayReturnCreatureFromYourGraveyardToYourHandEffect(this);
    }
}
