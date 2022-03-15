using Engine;

namespace Cards.CardFilters
{
    class OwnersBattleZoneCivilizationCreatureExceptFilter : OwnersBattleZoneCreatureExceptFilter, ICivilizationFilterable
    {
        public CivilizationFilter CivilizationFilter { get; }

        public OwnersBattleZoneCivilizationCreatureExceptFilter(Common.Civilization civilization)
        {
            CivilizationFilter = new CivilizationFilter(civilization);
        }

        public OwnersBattleZoneCivilizationCreatureExceptFilter(OwnersBattleZoneCivilizationCreatureExceptFilter filter) : base(filter)
        {
            CivilizationFilter = filter.CivilizationFilter;
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            return base.Applies(card, game, player) && CivilizationFilter.Applies(card, game, player);
        }

        public override CardFilter Copy()
        {
            return new OwnersBattleZoneCivilizationCreatureExceptFilter(this);
        }

        public override string ToString()
        {
            return $"your other {CivilizationFilter} {ToStringBase()}s";
        }
    }
}