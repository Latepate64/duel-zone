using Common;
using Engine;

namespace Cards.CardFilters
{
    abstract class CardTypeFilter : CardFilter
    {
        public CardType CardType { get; }

        protected CardTypeFilter(CardType cardType) : base()
        {
            CardType = cardType;
        }

        protected CardTypeFilter(CardTypeFilter filter) : base()
        {
            CardType = filter.CardType;
        }

        public override bool Applies(Engine.Card card, Game game, Engine.IPlayer player)
        {
            return card.CardType == CardType;
        }
    }

    class CreatureFilter : CardTypeFilter
    {
        public CreatureFilter() : base(CardType.Creature)
        {
        }

        public CreatureFilter(CreatureFilter filter) : base(filter)
        {
        }

        public override CardFilter Copy()
        {
            return new CreatureFilter(this);
        }

        public override string ToString()
        {
            return "creature";
        }
    }

    sealed class CreaturePowerFilter : CreatureFilter
    {
        public PowerFilter Power { get; }

        public CreaturePowerFilter(PowerFilter power)
        {
            Power = power;
        }

        public CreaturePowerFilter(CreaturePowerFilter filter) : base(filter)
        {
            Power = filter.Power;
        }

        public override bool Applies(Engine.Card card, Game game, Engine.IPlayer player)
        {
            return base.Applies(card, game, player) && Power.Applies(card);
        }

        public override CardFilter Copy()
        {
            return new CreaturePowerFilter(this);
        }

        public override string ToString()
        {
            return $"{base.ToString()} with {Power}";
        }
    }

    sealed class SpellFilter : CardTypeFilter
    {
        public SpellFilter() : base(CardType.Spell)
        {
        }

        public SpellFilter(SpellFilter filter) : base(filter)
        {
        }

        public override CardFilter Copy()
        {
            return new SpellFilter(this);
        }

        public override string ToString()
        {
            return "spell";
        }
    }
}
