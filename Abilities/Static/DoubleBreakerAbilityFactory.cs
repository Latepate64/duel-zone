using Interfaces;

namespace Abilities.Static;

public class DoubleBreakerAbilityFactory : IStaticAbilityFactory
{
    public IStaticAbility Create()
    {
        return new DoubleBreakerAbility();
    }
}