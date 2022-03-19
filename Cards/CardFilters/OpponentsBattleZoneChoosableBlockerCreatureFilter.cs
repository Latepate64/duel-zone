using Cards.StaticAbilities;
using Engine;
using System.Linq;

namespace Cards.CardFilters
{
    class OpponentsBattleZoneChoosableBlockerCreatureFilter : OpponentsBattleZoneBlockerCreatureFilter
    {
        public OpponentsBattleZoneChoosableBlockerCreatureFilter()
        {
        }

        public override bool Applies(Card card, Game game, IPlayer player)
        {
            return base.Applies(card, game, player) && !card.GetAbilities<UnchoosableAbility>().Any();
        }

        public override CardFilter Copy()
        {
            return new OpponentsBattleZoneChoosableBlockerCreatureFilter();
        }
    }
}
