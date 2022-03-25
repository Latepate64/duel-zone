using Common.GameEvents;
using Engine;
using Engine.Abilities;

namespace Cards.TriggeredAbilities
{
    public class BattleAbility : CardTriggeredAbility
    {
        public BattleAbility(OneShotEffect effect) : base(effect)
        {
        }

        public BattleAbility(BattleAbility ability) : base(ability)
        {
        }

        public override bool CanTrigger(IGameEvent gameEvent, IGame game)
        {
            return base.CanTrigger(gameEvent, game) && gameEvent is BattleEvent;
        }

        public override Ability Copy()
        {
            return new BattleAbility(this);
        }

        public override string ToString()
        {
            return $"When {Filter} battles, {GetEffectText()}";
        }
    }
}
