using Engine;

namespace Cards.CardFilters
{
    class OpponentsBattleZoneChoosableEvolutionCreatureFilter : OpponentsBattleZoneChoosableCreatureFilter
    {
        public OpponentsBattleZoneChoosableEvolutionCreatureFilter()
        {
        }

        public override bool Applies(ICard card, IGame game, IPlayer player)
        {
            return base.Applies(card, game, player) && card.IsEvolutionCreature;
        }

        public override CardFilter Copy()
        {
            return new OpponentsBattleZoneChoosableEvolutionCreatureFilter();
        }

        public override string ToString()
        {
            return "your opponents evolution creatures";
        }
    }
}