using Engine;
using Engine.Abilities;
using Engine.GameEvents;

namespace Cards.TriggeredAbilities
{
    class AfterBattleAbility : TriggeredAbility
    {
        public AfterBattleAbility(OneShotEffect effect) : base(effect)
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

    class AfterBattleDelayedTriggeredAbility : DelayedTriggeredAbility
    {
        public AfterBattleDelayedTriggeredAbility(AfterBattleDelayedTriggeredAbility ability) : base(ability)
        {
        }

        public AfterBattleDelayedTriggeredAbility(OneShotEffect effect, IAbility ability) : base(new AfterBattleAbility(effect), ability.Source, ability.Controller, true)
        {
        }

        public override DelayedTriggeredAbility Copy()
        {
            return new AfterBattleDelayedTriggeredAbility(this);
        }
    }
}
