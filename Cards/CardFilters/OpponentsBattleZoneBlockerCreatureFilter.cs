using Cards.StaticAbilities;
using Engine;
using System.Linq;

namespace Cards.CardFilters
{
    class OpponentsBattleZoneBlockerCreatureFilter : OpponentsBattleZoneCreatureFilter
    {
        public OpponentsBattleZoneBlockerCreatureFilter()
        {
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            return base.Applies(card, game, player) && card.GetAbilities<BlockerAbility>().Any();
        }

        public override CardFilter Copy()
        {
            return new OpponentsBattleZoneBlockerCreatureFilter();
        }

        public override string ToString()
        {
            return base.ToString() + " that has \"blocker.\"";
        }
    }
}