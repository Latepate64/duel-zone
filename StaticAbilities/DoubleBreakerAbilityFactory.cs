using Interfaces;

namespace StaticAbilities;

public class DoubleBreakerAbilityFactory : IStaticAbilityFactory
{
    public IStaticAbility Create()
    {
        return new DoubleBreakerAbility();
    }
}