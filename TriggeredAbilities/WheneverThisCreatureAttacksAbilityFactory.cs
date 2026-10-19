using Interfaces;

namespace TriggeredAbilities;

public class WheneverThisCreatureAttacksAbilityFactory
{
    public WheneverThisCreatureAttacksAbility Create(IOneShotEffect effect)
    {
        return new WheneverThisCreatureAttacksAbility(effect);
    }
}