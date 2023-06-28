using Engine;
using Engine.Abilities;
using Engine.GameEvents;

namespace Cards.TriggeredAbilities
{
    abstract class BecomeBlockedAbility : CardTriggeredAbility
    {
        protected BecomeBlockedAbility(BecomeBlockedAbility ability) : base(ability)
        {
        }

        protected BecomeBlockedAbility(IOneShotEffect effect) : base(effect)
        {
        }

        public override bool CanTrigger(IGameEvent gameEvent)
        {
            return gameEvent is BecomeBlockedEvent e && TriggersFrom(e.Attacker, Game);
        }
    }

    class WheneverThisCreatureBecomesBlockedAbility : BecomeBlockedAbility
    {
        public WheneverThisCreatureBecomesBlockedAbility(IOneShotEffect effect) : base(effect)
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

        protected override bool TriggersFrom(ICard card, IGame game)
        {
            return card == Source;
        }
    }
}
