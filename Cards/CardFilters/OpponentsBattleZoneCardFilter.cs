using Engine;
using System.Linq;

namespace Cards.CardFilters
{
    abstract class OpponentsBattleZoneCardFilter : CardFilter
    {
        public OpponentsBattleZoneCardFilter() : base()
        {
        }

        public OpponentsBattleZoneCardFilter(OpponentsBattleZoneCardFilter filter) : base(filter)
        {
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            return game.BattleZone.GetCreatures(game.GetOpponent(player).Id).Contains(card);
        }
    }
}
