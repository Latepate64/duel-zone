using Engine;

namespace Cards.CardFilters
{
    class OwnersBattleZoneAnotherCivilizationCreatureFilter : OwnersBattleZoneCreatureExceptFilter, ICivilizationFilterable
    {
        public CivilizationFilter CivilizationFilter { get; }

        public OwnersBattleZoneAnotherCivilizationCreatureFilter(Common.Civilization civilization)
        {
            CivilizationFilter = new CivilizationFilter(civilization);
        }

        public OwnersBattleZoneAnotherCivilizationCreatureFilter(OwnersBattleZoneAnotherCivilizationCreatureFilter filter) : base()
        {
            CivilizationFilter = filter.CivilizationFilter;
        }

        public override bool Applies(Card card, Game game, IPlayer player)
        {
            return base.Applies(card, game, player) && CivilizationFilter.Applies(card, game, player);
        }

        public override CardFilter Copy()
        {
            return new OwnersBattleZoneAnotherCivilizationCreatureFilter(this);
        }

        public override string ToString()
        {
            return $"your other {CivilizationFilter} creatures";
        }
    }
}