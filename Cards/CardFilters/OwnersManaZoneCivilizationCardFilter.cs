using Engine;

namespace Cards.CardFilters
{
    class OwnersManaZoneCivilizationCardFilter : OwnersManaZoneCardFilter, ICivilizationFilterable
    {
        public CivilizationFilter CivilizationFilter { get; }

        public OwnersManaZoneCivilizationCardFilter(params Common.Civilization[] civilizations)
        {
            CivilizationFilter = new CivilizationFilter(civilizations);
        }

        public OwnersManaZoneCivilizationCardFilter(OwnersManaZoneCivilizationCardFilter filter) : base(filter)
        {
            CivilizationFilter = filter.CivilizationFilter;
        }

        public override string ToString()
        {
            return $"{base.ToString()} {CivilizationFilter}";
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            return base.Applies(card, game, player) && CivilizationFilter.Applies(card, game, player);
        }

        public override CardFilter Copy()
        {
            return new OwnersManaZoneCivilizationCardFilter(this);
        }
    }
}