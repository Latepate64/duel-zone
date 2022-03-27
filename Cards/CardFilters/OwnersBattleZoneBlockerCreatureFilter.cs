using Cards.StaticAbilities;
using Engine;
using System.Linq;

namespace Cards.CardFilters
{
    class OwnersBattleZoneBlockerCreatureFilter : OwnersBattleZoneCreatureFilter
    {
        public OwnersBattleZoneBlockerCreatureFilter()
        {
        }

        public override bool Applies(ICard card, IGame game, IPlayer player)
        {
            return base.Applies(card, game, player) && card.GetAbilities<BlockerAbility>().Any();
        }

        public override CardFilter Copy()
        {
            return new OwnersBattleZoneBlockerCreatureFilter();
        }

        public override string ToString()
        {
            return base.ToString() + " that has \"blocker.\"";
        }
    }
}