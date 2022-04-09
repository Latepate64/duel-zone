using Common.GameEvents;
using Engine;
using Engine.Abilities;

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

        public override bool CanTrigger(IGameEvent gameEvent, IGame game)
        {
            return base.CanTrigger(gameEvent, game) && gameEvent is BattleEvent;
        }

        public override IAbility Copy()
        {
            return new WhenThisCreatureBattlesAbility(this);
        }

        public override string ToString()
        {
            return $"When this creature battles, {GetEffectText()}";
        }

        protected override bool TriggersFrom(Engine.ICard card, IGame game)
        {
            return card.Id == Source;
        }
    }
}
