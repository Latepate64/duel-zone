using Engine;

namespace Cards.CardFilters
{
    class OpponentsBattleZoneCivilizationCreatureFilter : OpponentsBattleZoneCreatureFilter, ICivilizationFilterable
    {
        public CivilizationFilter CivilizationFilter { get; }

        public OpponentsBattleZoneCivilizationCreatureFilter(Common.Civilization civilization)
        {
            CivilizationFilter = new CivilizationFilter(civilization);
        }

        public OpponentsBattleZoneCivilizationCreatureFilter(OpponentsBattleZoneCivilizationCreatureFilter filter) : base(filter)
        {
            CivilizationFilter = filter.CivilizationFilter;
        }


        public override bool Applies(Card card, Game game, Player player)
        {
            return base.Applies(card, game, player) && CivilizationFilter.Applies(card, game, player);
        }

        public override CardFilter Copy()
        {
            return new OpponentsBattleZoneCivilizationCreatureFilter(this);
        }

        public override string ToString()
        {
            return $"your opponent's {CivilizationFilter} {ToStringBase()}s";
        }
    }
}
