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

        public OpponentsBattleZoneBlockerCreatureFilter(OpponentsBattleZoneBlockerCreatureFilter filter) : base(filter)
        {
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            return base.Applies(card, game, player) && card.GetAbilities<BlockerAbility>().Any();
        }

        public override CardFilter Copy()
        {
            return new OpponentsBattleZoneBlockerCreatureFilter(this);
        }

        public override string ToString()
        {
            return base.ToString() + " that has \"blocker.\"";
        }
    }
}