using Engine;

namespace Cards.CardFilters
{
    class OpponentsBattleZoneCivilizationCreatureFilter : OpponentsBattleZoneCreatureFilter, ICivilizationFilterable
    {
        public CivilizationFilter CivilizationFilter { get; }

        public OpponentsBattleZoneCivilizationCreatureFilter(params Common.Civilization[] civilizations)
        {
            CivilizationFilter = new CivilizationFilter(civilizations);
        }

        public OpponentsBattleZoneCivilizationCreatureFilter(OpponentsBattleZoneCivilizationCreatureFilter filter) : base()
        {
            CivilizationFilter = filter.CivilizationFilter;
        }


        public override bool Applies(ICard card, IGame game, IPlayer player)
        {
            return base.Applies(card, game, player) && CivilizationFilter.Applies(card, game, player);
        }

        public override CardFilter Copy()
        {
            return new OpponentsBattleZoneCivilizationCreatureFilter(this);
        }

        public override string ToString()
        {
            return $"your opponent's {CivilizationFilter} creatures";
        }
    }
}
