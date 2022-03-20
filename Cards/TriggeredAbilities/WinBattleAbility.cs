using Common.GameEvents;
using Engine;
using Engine.Abilities;

namespace Cards.TriggeredAbilities
{
    public class WinBattleAbility : CardTriggeredAbility
    {
        public WinBattleAbility(OneShotEffect effect) : base(effect)
        {
        }

        public WinBattleAbility(WinBattleAbility ability) : base(ability)
        {
        }

        public override bool CanTrigger(IGameEvent gameEvent, IGame game)
        {
            return base.CanTrigger(gameEvent, game) && gameEvent is WinBattleEvent;
        }

        public override Ability Copy()
        {
            return new WinBattleAbility(this);
        }

        public override string ToString()
        {
            return $"When {Filter} wins a battle, {ToStringBase()}";
        }
    }
}
