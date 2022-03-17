using Engine;

namespace Cards.CardFilters
{
    class OwnersGraveyardCivilizationCreatureFilter : OwnersGraveyardCreatureFilter, ICivilizationFilterable
    {
        public OwnersGraveyardCivilizationCreatureFilter(params Common.Civilization[] civilizations)
        {
            CivilizationFilter = new CivilizationFilter(civilizations);
        }

        public OwnersGraveyardCivilizationCreatureFilter(OwnersGraveyardCivilizationCreatureFilter filter) : base(filter)
        {
            CivilizationFilter = filter.CivilizationFilter;
        }

        public CivilizationFilter CivilizationFilter { get; }

        public override bool Applies(Card card, Game game, Player player)
        {
            return base.Applies(card, game, player);
        }

        public override CardFilter Copy()
        {
            return new OwnersGraveyardCivilizationCreatureFilter(this);
        }

        public override string ToString()
        {
            return $"{base.ToString()} {CivilizationFilter} creature";
        }
    }
}