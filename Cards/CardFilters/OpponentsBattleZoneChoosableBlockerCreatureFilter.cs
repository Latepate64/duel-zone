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

        public override bool Applies(ICard card, IGame game, IPlayer player)
        {
            return base.Applies(card, game, player) && !card.GetAbilities<OpponentCannotChooseThisCreatureAbility>().Any();
        }

        public override CardFilter Copy()
        {
            return new OpponentsBattleZoneChoosableBlockerCreatureFilter();
        }
    }
}
