using Interfaces;

namespace TriggeredAbilities;

public sealed class AfterBattleDelayedTriggeredAbility : DelayedTriggeredAbility
{
    public AfterBattleDelayedTriggeredAbility(AfterBattleDelayedTriggeredAbility ability) : base(ability)
    {
    }

    public AfterBattleDelayedTriggeredAbility(IOneShotEffect effect, IAbility ability) : base(
        new AfterBattleAbility(effect), ability.Source, ability.Controller, true)
    {
    }

    public override DelayedTriggeredAbility Copy()
    {
        return new AfterBattleDelayedTriggeredAbility(this);
    }
}

