using Interfaces;

namespace TriggeredAbilities;

public sealed class AfterAttackDelayedTriggeredAbility : DelayedTriggeredAbility
{
    private AfterAttackDelayedTriggeredAbility(
        AfterAttackDelayedTriggeredAbility ability) : base(ability)
    {
    }

    public AfterAttackDelayedTriggeredAbility(
        IOneShotEffect effect,
        IAbility ability) : base(
            new AfterAttackAbility(
                effect, (ICreature)ability.Source), ability.Source, ability.Controller, true)
    {
    }

    public override DelayedTriggeredAbility Copy()
    {
        return new AfterAttackDelayedTriggeredAbility(this);
    }
}
