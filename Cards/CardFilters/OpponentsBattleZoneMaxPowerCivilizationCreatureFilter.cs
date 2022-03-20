using Engine;

namespace Cards.CardFilters
{
    class OpponentsBattleZoneMaxPowerCivilizationCreatureFilter : OpponentsBattleZoneMaxPowerCreatureFilter, ICivilizationFilterable
    {
        public CivilizationFilter CivilizationFilter { get; }

        public OpponentsBattleZoneMaxPowerCivilizationCreatureFilter(int power, Common.Civilization civilization) : base(power)
        {
            CivilizationFilter = new CivilizationFilter(civilization);
        }

        public OpponentsBattleZoneMaxPowerCivilizationCreatureFilter(OpponentsBattleZoneMaxPowerCivilizationCreatureFilter filter) : base(filter)
        {
            CivilizationFilter = filter.CivilizationFilter;
        }

        public override bool Applies(ICard card, IGame game, IPlayer player)
        {
            return base.Applies(card, game, player) && CivilizationFilter.Applies(card, game, player);
        }

        public override CardFilter Copy()
        {
            return new OpponentsBattleZoneMaxPowerCivilizationCreatureFilter(this);
        }

        public override string ToString()
        {
            return $"{CivilizationFilter} {base.ToString()}";
        }
    }
}