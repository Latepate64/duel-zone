using Abilities;
using Engine.GameEvents;
using Interfaces;

namespace TriggeredAbilities;

public sealed class AfterBattleAbility : TriggeredAbility
{
    public AfterBattleAbility(IOneShotEffect effect) : base(effect)
    {
    }

    public AfterBattleAbility(AfterBattleAbility ability) : base(ability)
    {
    }

    public override bool CanTrigger(IGameEvent gameEvent, IGame game)
    {
        return CheckInterveningIfClause(game) && gameEvent is BattleEvent;
    }

    public override Ability Copy()
    {
        return new AfterBattleAbility(this);
    }

    public override string ToString()
    {
        return "After the battle";
    }
}

