using Engine;
using System.Linq;

namespace Cards.CardFilters
{
    class OpponentsBattleZoneCardFilter : CardFilter
    {
        public OpponentsBattleZoneCardFilter()
        {
        }

        public OpponentsBattleZoneCardFilter(OpponentsBattleZoneCardFilter filter) : base(filter)
        {
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            return base.Applies(card, game, player) && game.BattleZone.GetCreatures(game.GetOpponent(player).Id).Contains(card);
        }

        public override CardFilter Copy()
        {
            return new OpponentsBattleZoneCardFilter(this);
        }

        public override string ToString()
        {
            return $"of your opponent's cards";
        }
    }
}
