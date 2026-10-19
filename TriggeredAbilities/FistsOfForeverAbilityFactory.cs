using Interfaces;

namespace TriggeredAbilities;

public class FistsOfForeverAbilityFactory : ITriggeredAbilityWithCreatureFactory
{
    public ITriggeredAbility Create(ICreature creature)
    {
        return new FistsOfForeverAbility(creature);
    }
}