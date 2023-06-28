using Engine;
using Engine.Abilities;
using Engine.GameEvents;
using System.Linq;

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

        public override bool CanTrigger(IGameEvent gameEvent)
        {
            return gameEvent is BattleEvent e && (TriggersFrom(e.AttackingCreature) || TriggersFrom(e.DefendingCreature)) && e.Winners.Any(x => x == Source);
        }

        public override IAbility Copy()
        {
            return new WhenThisCreatureWinsBattleAbility(this);
        }

        public override string ToString()
        {
            return $"When this creature wins a battle, {GetEffectText()}";
        }

        protected override bool TriggersFrom(ICard card)
        {
            return card == Source;
        }
    }
}
