using Engine;

namespace Cards.CardFilters
{
    class OwnersBattleZoneCivilizationCreatureFilter : OwnersBattleZoneCreatureFilter, ICivilizationFilterable
    {
        public CivilizationFilter CivilizationFilter { get; }

        public OwnersBattleZoneCivilizationCreatureFilter(params Common.Civilization[] civilizations)
        {
            CivilizationFilter = new CivilizationFilter(civilizations);
        }

        public OwnersBattleZoneCivilizationCreatureFilter(OwnersBattleZoneCivilizationCreatureFilter filter) : base()
        {
            CivilizationFilter = filter.CivilizationFilter;
        }

        public override bool Applies(ICard card, IGame game, IPlayer player)
        {
            return base.Applies(card, game, player) && CivilizationFilter.Applies(card, game, player);
        }

        public override CardFilter Copy()
        {
            return new OwnersBattleZoneCivilizationCreatureFilter(this);
        }

        public override string ToString()
        {
            return $"your {CivilizationFilter} creatures";
        }
    }
}