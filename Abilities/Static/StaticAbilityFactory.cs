using Interfaces;
using Interfaces.ContinuousEffects;

namespace Abilities.Static;

public class StaticAbilityFactory : IStaticAbilityFactory
{
    public IStaticAbility Create(IContinuousEffect effect)
    {
        return new StaticAbility(effect);
    }
}
