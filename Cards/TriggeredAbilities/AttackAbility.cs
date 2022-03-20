using Common.GameEvents;
using Engine;
using Engine.Abilities;

namespace Cards.TriggeredAbilities
{
    public class AttackAbility : CardTriggeredAbility
    {
        public AttackAbility(OneShotEffect effect) : base(effect)
        {
        }

        public AttackAbility(AttackAbility ability) : base(ability)
        {
        }

        public override bool CanTrigger(IGameEvent gameEvent, IGame game)
        {
            return base.CanTrigger(gameEvent, game) && gameEvent is CreatureAttackedEvent;
        }

        public override Ability Copy()
        {
            return new AttackAbility(this);
        }

        public override string ToString()
        {
            return $"Whenever {Filter} attacks, {ToStringBase()}";
        }
    }
}
