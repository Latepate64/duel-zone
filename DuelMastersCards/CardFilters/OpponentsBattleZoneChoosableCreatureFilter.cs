using DuelMastersModels;
using DuelMastersModels.ContinuousEffects;
using System.Linq;

namespace DuelMastersCards.CardFilters
{
    class OpponentsBattleZoneChoosableCreatureFilter : OpponentsBattleZoneCreatureFilter
    {
        public OpponentsBattleZoneChoosableCreatureFilter()
        {
        }

        public OpponentsBattleZoneChoosableCreatureFilter(OpponentsBattleZoneCardFilter filter) : base(filter)
        {
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            return base.Applies(card, game, player) && !game.GetContinuousEffects<UnchoosableEffect>(card).Any();
        }
    }
}
