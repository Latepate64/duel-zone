using Interfaces;
using Interfaces.ContinuousEffects;

namespace Abilities.Static;

public class StaticAbilityFactory : IStaticAbilityWithEffectFactory
{
    public IStaticAbility Create(IContinuousEffect effect)
    {
        return new StaticAbility(effect);
    }
}
