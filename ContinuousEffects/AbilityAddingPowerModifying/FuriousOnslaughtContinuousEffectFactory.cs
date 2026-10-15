using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAddingPowerModifying;

public class FuriousOnslaughtContinuousEffectFactory : IContinuousEffectFactory
{
    public IContinuousEffect Create(IEnumerable<ICreature> creatures)
    {
        return new FuriousOnslaughtContinuousEffect([.. creatures]);
    }
}