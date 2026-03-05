using Interfaces;

namespace OneShotEffects;

public sealed class ReturnUpToTwoCreaturesFromYourGraveyardToYourHandEffect :
    ReturnUpToCreaturesFromYourGraveyardToYourHandEffect
{
    public ReturnUpToTwoCreaturesFromYourGraveyardToYourHandEffect() : base(2)
    {
    }

    public ReturnUpToTwoCreaturesFromYourGraveyardToYourHandEffect(
        ReturnUpToTwoCreaturesFromYourGraveyardToYourHandEffect effect) : base(effect)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new ReturnUpToTwoCreaturesFromYourGraveyardToYourHandEffect(this);
    }
}
