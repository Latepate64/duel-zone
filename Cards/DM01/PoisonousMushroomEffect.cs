using OneShotEffects;
using Engine.Abilities;

namespace Cards.DM01;

public class PoisonousMushroomEffect : YouMayPutUpToCardsFromYourHandIntoYourManaZoneEffect
{
    public PoisonousMushroomEffect() : base(1)
    {
    }

    public PoisonousMushroomEffect(PoisonousMushroomEffect effect) : base(effect)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new PoisonousMushroomEffect(this);
    }
}
