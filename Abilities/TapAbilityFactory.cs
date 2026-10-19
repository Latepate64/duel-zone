using Interfaces;

namespace Abilities;

public class TapAbilityFactory
{
    public ITapAbility Create(IOneShotEffect effect)
    {
        return new TapAbility(effect);
    }
}