using Engine;

namespace Cards.CardFilters
{
    class OwnersDeckSpellFilter : OwnersDeckCardFilter
    {
        public OwnersDeckSpellFilter()
        {
        }

        public OwnersDeckSpellFilter(OwnersDeckSpellFilter filter) : base(filter)
        {
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            return base.Applies(card, game, player) && new SpellFilter().Applies(card, game, player);
        }

        public override CardFilter Copy()
        {
            return new OwnersDeckSpellFilter(this);
        }

        public override string ToString()
        {
            return $"{base.ToString()} spell";
        }
    }
}