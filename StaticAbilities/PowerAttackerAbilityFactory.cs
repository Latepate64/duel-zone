using Interfaces;

namespace StaticAbilities;

public class PowerAttackerAbilityFactory : IStaticAbilityWithIntegerFactory
{
    public IStaticAbility Create(int value)
    {
        return new PowerAttackerAbility(value);
    }
}