using Engine;
using Engine.Abilities;
using Engine.GameEvents;

namespace Cards.TriggeredAbilities
{
    public class WhenThisCreatureBattlesAbility : CardTriggeredAbility
    {
        public WhenThisCreatureBattlesAbility(IOneShotEffect effect) : base(effect)
        {
        }

        public WhenThisCreatureBattlesAbility(WhenThisCreatureBattlesAbility ability) : base(ability)
        {
        }

        public override bool CanTrigger(IGameEvent gameEvent)
        {
            return gameEvent is BattleEvent e && (TriggersFrom(e.AttackingCreature, Game) || TriggersFrom(e.DefendingCreature, Game));
        }

        public override IAbility Copy()
        {
            return new WhenThisCreatureBattlesAbility(this);
        }

        public override string ToString()
        {
            return $"When this creature battles, {GetEffectText()}";
        }

        protected override bool TriggersFrom(ICard card, IGame game)
        {
            return card == Source;
        }
    }
}
