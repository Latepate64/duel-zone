using Common.GameEvents;
using Engine;
using Engine.Abilities;

namespace Cards.TriggeredAbilities
{
    class WheneverThisCreatureAttacksAbility : WheneverCreatureAttacksAbility
    {
        public WheneverThisCreatureAttacksAbility(IOneShotEffect effect) : base(effect, new TargetFilter())
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
            return card.Id == Source;
        }
    }

    abstract class WheneverCreatureAttacksAbility : CardTriggeredAbility
    {
        protected WheneverCreatureAttacksAbility(WheneverCreatureAttacksAbility ability) : base(ability)
        {
        }

        protected WheneverCreatureAttacksAbility(IOneShotEffect effect, ICardFilter filter) : base(effect)
        {
        }

        public override bool CanTrigger(IGameEvent gameEvent, IGame game)
        {
            return base.CanTrigger(gameEvent, game) && gameEvent is CreatureAttackedEvent;
        }
    }

    class WheneverAnyOfYourCreaturesAttacksAbility : WheneverCreatureAttacksAbility
    {
        public WheneverAnyOfYourCreaturesAttacksAbility(IOneShotEffect effect) : base(effect, new CardFilters.OwnersBattleZoneCreatureFilter())
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
