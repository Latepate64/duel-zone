using Interfaces;

namespace TriggeredAbilities;

public sealed class AfterAttackDelayedTriggeredAbility : DelayedTriggeredAbility
{
    public AfterAttackDelayedTriggeredAbility(AfterAttackDelayedTriggeredAbility ability) : base(ability)
    {
    }

    public AfterAttackDelayedTriggeredAbility(IOneShotEffect effect, IAbility ability, Guid attacker) : base(
        new AfterAttackAbility(effect, attacker), ability.Source, ability.Controller, true)
    {
    }

    public override DelayedTriggeredAbility Copy()
    {
        return new AfterAttackDelayedTriggeredAbility(this);
    }
}
