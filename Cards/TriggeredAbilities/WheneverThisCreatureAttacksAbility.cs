using Common.GameEvents;
using Engine;
using Engine.Abilities;

namespace Cards.TriggeredAbilities
{
    public class WheneverThisCreatureAttacksAbility : CardTriggeredAbility
    {
        public WheneverThisCreatureAttacksAbility(OneShotEffect effect) : base(effect)
        {
        }

        public WheneverThisCreatureAttacksAbility(WheneverThisCreatureAttacksAbility ability) : base(ability)
        {
        }

        public override bool CanTrigger(IGameEvent gameEvent, IGame game)
        {
            return base.CanTrigger(gameEvent, game) && gameEvent is CreatureAttackedEvent;
        }

        public override Ability Copy()
        {
            return new WheneverThisCreatureAttacksAbility(this);
        }

        public override string ToString()
        {
            return $"Whenever this creature attacks, {GetEffectText()}";
        }
    }
}
