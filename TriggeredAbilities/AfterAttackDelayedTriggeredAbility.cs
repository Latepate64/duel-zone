using Engine.Abilities;
using Interfaces;

namespace TriggeredAbilities;

public class AfterAttackDelayedTriggeredAbility : DelayedTriggeredAbility
{
    public AfterAttackDelayedTriggeredAbility(AfterAttackDelayedTriggeredAbility ability) : base(ability)
    {
    }

    public AfterAttackDelayedTriggeredAbility(OneShotEffect effect, IAbility ability, Guid attacker) : base(
        new AfterAttackAbility(effect, attacker), ability.Source, ability.Controller, true)
    {
    }

    public override DelayedTriggeredAbility Copy()
    {
        return new AfterAttackDelayedTriggeredAbility(this);
    }
}
