using Common;
using Engine;

namespace Cards.CardFilters
{
    class AnotherBattleZoneCivilizationCreatureFilter : AnotherBattleZoneCreatureFilter, ICivilizationFilterable
    {
        public AnotherBattleZoneCivilizationCreatureFilter(params Civilization[] civilizations) : base()
        {
            CivilizationFilter = new CivilizationFilter(civilizations);
        }

        public AnotherBattleZoneCivilizationCreatureFilter(AnotherBattleZoneCivilizationCreatureFilter filter) : base(filter)
        {
            CivilizationFilter = filter.CivilizationFilter;
        }

        public CivilizationFilter CivilizationFilter { get; }

        public override bool Applies(Engine.ICard card, IGame game, Engine.IPlayer player)
        {
            return base.Applies(card, game, player) && CivilizationFilter.Applies(card, game, player);
        }

        public override CardFilter Copy()
        {
            return new AnotherBattleZoneCivilizationCreatureFilter(this);
        }

        public override string ToString()
        {
            return $"Each other {CivilizationFilter} creature in the battle zone";
        }
    }
}