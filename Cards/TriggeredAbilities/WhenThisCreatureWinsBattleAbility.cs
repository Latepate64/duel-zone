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

        public override bool CanTrigger(IGameEvent gameEvent, IGame game)
        {
            return gameEvent is BattleEvent e && (TriggersFrom(e.AttackingCreature, game) || TriggersFrom(e.DefendingCreature, game)) && e.Winners.Any(x => x.Id == Source);
        }

        public override IAbility Copy()
        {
            return new WhenThisCreatureWinsBattleAbility(this);
        }

        public override string ToString()
        {
            return $"When this creature wins a battle, {GetEffectText()}";
        }

        protected override bool TriggersFrom(ICard card, IGame game)
        {
            return card.Id == Source;
        }
    }
}
