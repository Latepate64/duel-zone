using Common;
using Engine;

namespace Cards.CardFilters
{
    class BattleZoneNonCivilizationCreatureFilter : BattleZoneCreatureFilter
    {
        private readonly Civilization _civilization;

        public BattleZoneNonCivilizationCreatureFilter(BattleZoneNonCivilizationCreatureFilter filter)
        {
            _civilization = filter._civilization;
        }

        public BattleZoneNonCivilizationCreatureFilter(Civilization civilization)
        {
            _civilization = civilization;
        }

        public override bool Applies(Engine.ICard card, IGame game, Engine.IPlayer player)
        {
            return base.Applies(card, game, player) && !card.HasCivilization(_civilization);
        }

        public override CardFilter Copy()
        {
            return new BattleZoneNonCivilizationCreatureFilter(this);
        }

        public override string ToString()
        {
            return $"all creatures except {_civilization} creatures";
        }
    }
}