using Engine;
using Engine.Abilities;
using Engine.GameEvents;

namespace Cards.TriggeredAbilities
{
    class WhenThisCreatureAttacksPlayerAbility : WheneverThisCreatureAttacksAbility
    {
        public WhenThisCreatureAttacksPlayerAbility(IOneShotEffect effect) : base(effect)
        {
        }

        public WhenThisCreatureAttacksPlayerAbility(WheneverThisCreatureAttacksAbility ability) : base(ability)
        {
        }

        public override bool CanTrigger(IGameEvent gameEvent)
        {
            return base.CanTrigger(gameEvent) && gameEvent is CreatureAttackedEvent e && e.Target == Game.GetAttackable(Controller.Opponent.Id);
        }

        public override IAbility Copy()
        {
            return new WhenThisCreatureAttacksPlayerAbility(this);
        }

        public override string ToString()
        {
            return $"When this creature attacks a player, {GetEffectText()}";
        }
    }
}
