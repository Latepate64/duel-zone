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
            throw new System.NotImplementedException();
            //return CheckInterveningIfClause(game) && gameEvent is AfterBattleEvent;
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
