using Common.GameEvents;
using Engine;
using Engine.Abilities;

namespace Cards.TriggeredAbilities
{
    public class BecomeBlockedAbility : CardTriggeredAbility
    {
        public BecomeBlockedAbility(BecomeBlockedAbility ability) : base(ability)
        {
        }

        public BecomeBlockedAbility(OneShotEffect effect) : base(effect)
        {
        }

        public override bool CanTrigger(GameEvent gameEvent, Game game)
        {
            return base.CanTrigger(gameEvent, game) && gameEvent is BecomeBlockedEvent;
        }

        public override Ability Copy()
        {
            return new BecomeBlockedAbility(this);
        }

        public override string ToString()
        {
            return $"Whenever {Filter} becomes blocked, {ToStringBase()}";
        }
    }
}
