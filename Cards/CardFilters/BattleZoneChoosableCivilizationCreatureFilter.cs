using Engine;

namespace Cards.CardFilters
{
    class BattleZoneChoosableCivilizationCreatureFilter : BattleZoneChoosableCreatureFilter, ICivilizationFilterable
    {
        public CivilizationFilter CivilizationFilter { get; }

        public BattleZoneChoosableCivilizationCreatureFilter(params Common.Civilization[] civilizations)
        {
            CivilizationFilter = new CivilizationFilter(civilizations);
        }

        public BattleZoneChoosableCivilizationCreatureFilter(BattleZoneChoosableCivilizationCreatureFilter filter) : base()
        {
            CivilizationFilter = filter.CivilizationFilter;
        }

        public override bool Applies(ICard card, IGame game, IPlayer player)
        {
            return base.Applies(card, game, player) && CivilizationFilter.Applies(card, game, player);
        }

        public override CardFilter Copy()
        {
            return new BattleZoneChoosableCivilizationCreatureFilter(this);
        }

        public override string ToString()
        {
            return $"{CivilizationFilter} {base.ToString()}";
        }
    }
}