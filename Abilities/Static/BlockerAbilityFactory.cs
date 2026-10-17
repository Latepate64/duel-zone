using Interfaces;

namespace Abilities.Static;

public class BlockerAbilityFactory : IStaticAbilityFactory
{
    public IStaticAbility Create()
    {
        return new BlockerAbility();
    }

    public IStaticAbility Create(ICardFilter attackerFilter)
    {
        return new BlockerAbility(attackerFilter);
    }
}