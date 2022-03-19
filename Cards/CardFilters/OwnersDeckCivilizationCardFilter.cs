using Engine;

namespace Cards.CardFilters
{
    class OwnersDeckCivilizationCardFilter : OwnersDeckCardFilter, ICivilizationFilterable
    {
        public OwnersDeckCivilizationCardFilter(Common.Civilization civilization)
        {
            CivilizationFilter = new CivilizationFilter(civilization);
        }

        public OwnersDeckCivilizationCardFilter(OwnersDeckCivilizationCardFilter filter) : base(filter)
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
            return new OwnersDeckCivilizationCardFilter(this);
        }

        public override string ToString()
        {
            return $"a {CivilizationFilter} card from your deck";
        }
    }
}