using Engine;
using Engine.Abilities;
using Engine.GameEvents;

namespace Cards.TriggeredAbilities
{
    class WheneverThisCreatureAttacksAbility : WheneverCreatureAttacksAbility
    {
        public WheneverThisCreatureAttacksAbility(IOneShotEffect effect) : base(effect)
        {
        }

        public WheneverThisCreatureAttacksAbility(WheneverThisCreatureAttacksAbility ability) : base(ability)
        {
        }

        public override IAbility Copy()
        {
            return new WheneverThisCreatureAttacksAbility(this);
        }

        public override string ToString()
        {
            return $"Whenever this creature attacks, {GetEffectText()}";
        }

        protected override bool TriggersFrom(ICard card, IGame game)
        {
            return card == Source;
        }
    }

    abstract class WheneverCreatureAttacksAbility : CardTriggeredAbility
    {
        protected WheneverCreatureAttacksAbility(WheneverCreatureAttacksAbility ability) : base(ability)
        {
        }

        protected WheneverCreatureAttacksAbility(IOneShotEffect effect) : base(effect)
        {
        }

        public override bool CanTrigger(IGameEvent gameEvent)
        {
            return gameEvent is CreatureAttackedEvent e && TriggersFrom(e.Attacker, Game);
        }
    }

    class WheneverAnyOfYourCreaturesAttacksAbility : WheneverCreatureAttacksAbility
    {
        public WheneverAnyOfYourCreaturesAttacksAbility(IOneShotEffect effect) : base(effect)
        {
        }

        public WheneverAnyOfYourCreaturesAttacksAbility(WheneverAnyOfYourCreaturesAttacksAbility ability) : base(ability)
        {
        }

        public override IAbility Copy()
        {
            return new WheneverAnyOfYourCreaturesAttacksAbility(this);
        }

        public override string ToString()
        {
            return $"Whenever any of your creatures attacks, {GetEffectText()}";
        }

        protected override bool TriggersFrom(ICard card, IGame game)
        {
            return card.Owner == Controller;
        }
    }
}
