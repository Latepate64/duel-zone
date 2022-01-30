using Cards.StaticAbilities;
using DuelMastersModels;
using System.Linq;

namespace Cards.CardFilters
{
    class BattleZoneBlockerCreatureFilter : BattleZoneCreatureFilter
    {
        public BattleZoneBlockerCreatureFilter()
        {
        }

        public BattleZoneBlockerCreatureFilter(CardFilter filter) : base(filter)
        {
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            return base.Applies(card, game, player) && card.Abilities.OfType<BlockerAbility>().Any();
        }

        public override CardFilter Copy()
        {
            return new BattleZoneBlockerCreatureFilter(this);
        }
    }
}
