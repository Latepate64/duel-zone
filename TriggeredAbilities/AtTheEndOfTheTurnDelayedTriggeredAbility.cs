using Interfaces;

namespace TriggeredAbilities;

public sealed class AtTheEndOfTheTurnDelayedTriggeredAbility
    : DelayedTriggeredAbility
{
    public AtTheEndOfTheTurnDelayedTriggeredAbility(
        IAbility ability, Guid turn, IOneShotEffect effect) : base(
            new AtTheEndOfTurnAbility(turn, effect),
            ability.Source,
            ability.Controller,
            null)
    {
    }

    public AtTheEndOfTheTurnDelayedTriggeredAbility(
        AtTheEndOfTheTurnDelayedTriggeredAbility ability) : base(ability)
    {
    }

    public override DelayedTriggeredAbility Copy()
    {
        return new AtTheEndOfTheTurnDelayedTriggeredAbility(this);
    }
}