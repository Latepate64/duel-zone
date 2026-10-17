using Interfaces;

namespace Abilities.Static;

public class PowerAttackerAbilityFactory : IStaticAbilityWithIntegerFactory
{
    public IStaticAbility Create(int value)
    {
        return new PowerAttackerAbility(value);
    }
}