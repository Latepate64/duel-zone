using Interfaces;
using Interfaces.ContinuousEffects;

namespace StaticAbilities;

public class StaticAbilityFactory : IStaticAbilityWithEffectFactory
{
    public IStaticAbility Create(IContinuousEffect effect)
    {
        return new StaticAbility(effect);
    }
}
