using Cards.StaticAbilities;
using Engine;
using System.Linq;

namespace Cards.CardFilters
{
    class BattleZoneNonBlockerCreatureFilter : BattleZoneCreatureFilter
    {
        public BattleZoneNonBlockerCreatureFilter()
        {
        }

        public BattleZoneNonBlockerCreatureFilter(CardFilter filter) : base(filter)
        {
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            return base.Applies(card, game, player) && !card.GetAbilities<BlockerAbility>().Any();
        }

        public override CardFilter Copy()
        {
            return new BattleZoneNonBlockerCreatureFilter(this);
        }

        public override string ToString()
        {
            return "creatures that don't have \"blocker\"";
        }
    }
}
