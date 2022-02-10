using Cards.StaticAbilities;
using Engine;
using System.Linq;

namespace Cards.CardFilters
{
    class OpponentsBattleZoneChoosableBlockerCreatureFilter : OpponentsBattleZoneChoosableCreatureFilter
    {
        public OpponentsBattleZoneChoosableBlockerCreatureFilter()
        {
        }

        public OpponentsBattleZoneChoosableBlockerCreatureFilter(OpponentsBattleZoneChoosableBlockerCreatureFilter filter) : base(filter)
        {
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            return base.Applies(card, game, player) && card.Abilities.OfType<BlockerAbility>().Any();
        }

        public override CardFilter Copy()
        {
            return new OpponentsBattleZoneChoosableBlockerCreatureFilter(this);
        }

        public override string ToString()
        {
            return base.ToString() + " that has \"blocker.\"";
        }
    }
}
