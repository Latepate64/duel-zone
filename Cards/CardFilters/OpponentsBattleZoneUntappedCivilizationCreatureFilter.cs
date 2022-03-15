using Engine;

namespace Cards.CardFilters
{
    class OpponentsBattleZoneUntappedCivilizationCreatureFilter : OpponentsBattleZoneUntappedCreatureFilter, ICivilizationFilterable
    {
        public CivilizationFilter CivilizationFilter { get; }

        public OpponentsBattleZoneUntappedCivilizationCreatureFilter(Common.Civilization civilization)
        {
            CivilizationFilter = new CivilizationFilter(civilization);
        }

        public OpponentsBattleZoneUntappedCivilizationCreatureFilter(OpponentsBattleZoneUntappedCivilizationCreatureFilter filter) : base(filter)
        {
            CivilizationFilter = filter.CivilizationFilter;
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            return base.Applies(card, game, player) && CivilizationFilter.Applies(card, game, player);
        }

        public override CardFilter Copy()
        {
            return new OpponentsBattleZoneUntappedCivilizationCreatureFilter(this);
        }

        public override string ToString()
        {
            return $"your opponent's untapped {CivilizationFilter} {ToStringBase()}s";
        }
    }
}
