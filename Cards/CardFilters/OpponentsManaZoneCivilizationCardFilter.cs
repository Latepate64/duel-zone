using Engine;

namespace Cards.CardFilters
{
    class OpponentsManaZoneCivilizationCardFilter : OpponentsManaZoneCardFilter, ICivilizationFilterable
    {
        public CivilizationFilter CivilizationFilter { get; }

        public OpponentsManaZoneCivilizationCardFilter(params Common.Civilization[] civilizations)
        {
            CivilizationFilter = new CivilizationFilter(civilizations);
        }

        public OpponentsManaZoneCivilizationCardFilter(OpponentsManaZoneCivilizationCardFilter filter) : base(filter)
        {
            CivilizationFilter = filter.CivilizationFilter;
        }

        public override string ToString()
        {
            return $"{base.ToString()} {CivilizationFilter}";
        }

        public override bool Applies(ICard card, IGame game, IPlayer player)
        {
            return base.Applies(card, game, player) && CivilizationFilter.Applies(card, game, player);
        }

        public override CardFilter Copy()
        {
            return new OpponentsManaZoneCivilizationCardFilter(this);
        }
    }
}