using Engine;

namespace Cards.CardFilters
{
    class OpponentsBattleZoneChoosableCivilizationCreatureFilter : OpponentsBattleZoneChoosableCreatureFilter, ICivilizationFilterable
    {
        public CivilizationFilter CivilizationFilter { get; }

        public OpponentsBattleZoneChoosableCivilizationCreatureFilter(params Common.Civilization[] civilizations)
        {
            CivilizationFilter = new CivilizationFilter(civilizations);
        }

        public OpponentsBattleZoneChoosableCivilizationCreatureFilter(OpponentsBattleZoneChoosableCivilizationCreatureFilter filter) : base()
        {
            CivilizationFilter = filter.CivilizationFilter;
        }

        public override bool Applies(ICard card, IGame game, IPlayer player)
        {
            return base.Applies(card, game, player) && CivilizationFilter.Applies(card, game, player);
        }

        public override CardFilter Copy()
        {
            return new OpponentsBattleZoneChoosableCivilizationCreatureFilter(this);
        }

        public override string ToString()
        {
            return $"{CivilizationFilter} {base.ToString()}";
        }
    }
}
