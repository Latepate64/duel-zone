using Engine;

namespace Cards.CardFilters
{
    class OpponentsBattleZoneUntappedCivilizationCreatureFilter : OpponentsBattleZoneUntappedCreatureFilter, ICivilizationFilterable
    {
        public CivilizationFilter CivilizationFilter { get; }

        public OpponentsBattleZoneUntappedCivilizationCreatureFilter(params Common.Civilization[] civilizations)
        {
            CivilizationFilter = new CivilizationFilter(civilizations);
        }

        public OpponentsBattleZoneUntappedCivilizationCreatureFilter(OpponentsBattleZoneUntappedCivilizationCreatureFilter filter) : base(filter)
        {
            CivilizationFilter = filter.CivilizationFilter;
        }

        public override bool Applies(ICard card, IGame game, IPlayer player)
        {
            return base.Applies(card, game, player) && CivilizationFilter.Applies(card, game, player);
        }

        public override CardFilter Copy()
        {
            return new OpponentsBattleZoneUntappedCivilizationCreatureFilter(this);
        }

        public override string ToString()
        {
            return $"your opponent's untapped {CivilizationFilter} creatures";
        }
    }
}
