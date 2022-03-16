using Cards.StaticAbilities;
using Engine;
using System.Linq;

namespace Cards.CardFilters
{
    class BattleZoneBlockerCreatureFilter : BattleZoneCreatureFilter
    {
        public BattleZoneBlockerCreatureFilter()
        {
        }

        public BattleZoneBlockerCreatureFilter(BattleZoneBlockerCreatureFilter filter) : base(filter)
        {
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            return base.Applies(card, game, player) && card.GetAbilities<BlockerAbility>().Any();
        }

        public override CardFilter Copy()
        {
            return new BattleZoneBlockerCreatureFilter(this);
        }

        public override string ToString()
        {
            return "blockers";
        }
    }
}
