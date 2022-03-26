using Common.GameEvents;
using Engine;
using Engine.Abilities;

namespace Cards.TriggeredAbilities
{
    public class WhenThisCreatureWinsBattleAbility : CardTriggeredAbility
    {
        public WhenThisCreatureWinsBattleAbility(IOneShotEffect effect) : base(effect)
        {
        }

        public WhenThisCreatureWinsBattleAbility(WhenThisCreatureWinsBattleAbility ability) : base(ability)
        {
        }

        public override bool CanTrigger(IGameEvent gameEvent, IGame game)
        {
            return base.CanTrigger(gameEvent, game) && gameEvent is WinBattleEvent;
        }

        public override IAbility Copy()
        {
            return new WhenThisCreatureWinsBattleAbility(this);
        }

        public override string ToString()
        {
            return $"When this creature wins a battle, {GetEffectText()}";
        }
    }
}
