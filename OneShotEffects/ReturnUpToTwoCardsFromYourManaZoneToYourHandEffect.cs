using Engine.Abilities;

namespace OneShotEffects;

public class ReturnUpToTwoCardsFromYourManaZoneToYourHandEffect : ReturnUpToCardsFromYourManaZoneToYourHandEffect
{
    public ReturnUpToTwoCardsFromYourManaZoneToYourHandEffect() : base(2)
    {
    }

    public ReturnUpToTwoCardsFromYourManaZoneToYourHandEffect(ReturnUpToCardsFromYourManaZoneToYourHandEffect effect) :
        base(effect)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new ReturnUpToTwoCardsFromYourManaZoneToYourHandEffect(this);
    }
}
