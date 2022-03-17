using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.CardFilters
{
    class OpponentsBattleZoneChoosableCreatureFilter : OpponentsBattleZoneCreatureFilter
    {
        public OpponentsBattleZoneChoosableCreatureFilter()
        {
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            return base.Applies(card, game, player) && !game.GetContinuousEffects<UnchoosableEffect>(card).Any();
        }

        public override CardFilter Copy()
        {
            return new OpponentsBattleZoneChoosableCreatureFilter();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
