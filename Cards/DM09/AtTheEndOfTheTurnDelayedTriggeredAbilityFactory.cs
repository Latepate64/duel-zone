using Interfaces;
using TriggeredAbilities;
using System;

namespace Cards.DM09;

public class AtTheEndOfTheTurnDelayedTriggeredAbilityFactory : IAtTheEndOfTheTurnDelayedTriggeredAbilityFactory
{
    public IDelayedTriggeredAbility CreateNew(IAbility ability, Guid turn, IOneShotEffect effect)
    {
        return new AtTheEndOfTheTurnDelayedTriggeredAbility(
            ability, turn, effect);
    }
}