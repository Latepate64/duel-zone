using Engine;

namespace Cards.CardFilters
{
    class OwnersManaZoneSpellFilter : OwnersManaZoneCardFilter
    {
        public OwnersManaZoneSpellFilter()
        {
        }

        public OwnersManaZoneSpellFilter(OwnersManaZoneSpellFilter filter) : base(filter)
        {
        }

        public override bool Applies(ICard card, IGame game, IPlayer player)
        {
            return base.Applies(card, game, player) && new SpellFilter().Applies(card, game, player);
        }

        public override CardFilter Copy()
        {
            return new OwnersManaZoneSpellFilter(this);
        }

        public override string ToString()
        {
            return $"{base.ToString()} spell";
        }
    }
}