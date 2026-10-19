using Interfaces;

namespace TriggeredAbilities;

public class AtTheEndOfTheTurnDelayedTriggeredAbilityFactory
    : IAtTheEndOfTheTurnDelayedTriggeredAbilityFactory
{
    public IDelayedTriggeredAbility Create(
        IAbility ability, Guid turn, IOneShotEffect effect)
    {
        return new AtTheEndOfTheTurnDelayedTriggeredAbility(
            ability, turn, effect);
    }
}