using Engine.Abilities;

namespace OneShotEffects;

public class ReturnUpToThreeCardsFromYourManaZoneToYourHandEffect : ReturnUpToCardsFromYourManaZoneToYourHandEffect
{
    public ReturnUpToThreeCardsFromYourManaZoneToYourHandEffect() : base(3)
    {
    }

    public ReturnUpToThreeCardsFromYourManaZoneToYourHandEffect(ReturnUpToCardsFromYourManaZoneToYourHandEffect effect)
        : base(effect)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new ReturnUpToThreeCardsFromYourManaZoneToYourHandEffect(this);
    }
}
