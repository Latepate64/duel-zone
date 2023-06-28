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

        public override bool CanTrigger(IGameEvent gameEvent)
        {
            return CheckInterveningIfClause() && gameEvent is BattleEvent;
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
}
