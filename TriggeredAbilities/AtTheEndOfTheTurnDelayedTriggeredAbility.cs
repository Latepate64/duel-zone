using Interfaces;

namespace TriggeredAbilities;

public sealed class AtTheEndOfTheTurnDelayedTriggeredAbility
    : DelayedTriggeredAbility
{
    AtTheEndOfTheTurnDelayedTriggeredAbility(
        IAbility ability, Guid turn, IOneShotEffect effect) : base(
            new AtTheEndOfTurnAbility(turn, effect),
            ability.Source,
            ability.Controller,
            true)
    {
    }

    public AtTheEndOfTheTurnDelayedTriggeredAbility(
        AtTheEndOfTheTurnDelayedTriggeredAbility ability) : base(ability)
    {
    }

    public AtTheEndOfTheTurnDelayedTriggeredAbility() : base()
    {
        
    }

    public override DelayedTriggeredAbility Copy()
    {
        return new AtTheEndOfTheTurnDelayedTriggeredAbility(this);
    }

    public override IDelayedTriggeredAbility CreateNew(
        IAbility ability, Guid turn, IOneShotEffect effect)
    {
        return new AtTheEndOfTheTurnDelayedTriggeredAbility(
            ability, turn, effect);
    }
}