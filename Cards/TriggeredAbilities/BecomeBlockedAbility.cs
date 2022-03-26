using Common.GameEvents;
using Engine;
using Engine.Abilities;

namespace Cards.TriggeredAbilities
{
    abstract class BecomeBlockedAbility : CardTriggeredAbility
    {
        protected BecomeBlockedAbility(BecomeBlockedAbility ability) : base(ability)
        {
        }

        protected BecomeBlockedAbility(IOneShotEffect effect, ICardFilter filter) : base(effect, filter)
        {
        }

        public override bool CanTrigger(IGameEvent gameEvent, IGame game)
        {
            return base.CanTrigger(gameEvent, game) && gameEvent is BecomeBlockedEvent;
        }
    }

    class WheneverThisCreatureBecomesBlockedAbility : BecomeBlockedAbility
    {
        public WheneverThisCreatureBecomesBlockedAbility(IOneShotEffect effect) : base(effect, new TargetFilter())
        { 
        }

        public WheneverThisCreatureBecomesBlockedAbility(WheneverThisCreatureBecomesBlockedAbility ability) : base(ability)
        {
        }

        public override IAbility Copy()
        {
            return new WheneverThisCreatureBecomesBlockedAbility(this);
        }

        public override string ToString()
        {
            return $"Whenever this creature becomes blocked, {GetEffectText()}";
        }
    }
}
