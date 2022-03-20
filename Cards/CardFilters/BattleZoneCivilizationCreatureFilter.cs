using Engine;

namespace Cards.CardFilters
{
    class BattleZoneCivilizationCreatureFilter : BattleZoneCreatureFilter, ICivilizationFilterable
    {
        public BattleZoneCivilizationCreatureFilter(params Common.Civilization[] civilizations)
        {
            CivilizationFilter = new CivilizationFilter(civilizations);
        }

        public BattleZoneCivilizationCreatureFilter(BattleZoneCivilizationCreatureFilter filter)
        {
            CivilizationFilter = filter.CivilizationFilter;
        }

        public CivilizationFilter CivilizationFilter { get; }

        public override bool Applies(ICard card, IGame game, IPlayer player)
        {
            return base.Applies(card, game, player) && CivilizationFilter.Applies(card, game, player);
        }

        public override CardFilter Copy()
        {
            return new BattleZoneCivilizationCreatureFilter(this);
        }

        public override string ToString()
        {
            return $"{CivilizationFilter} creatures";
        }
    }
}