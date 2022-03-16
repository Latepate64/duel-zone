using Engine;
using System.Linq;

namespace Cards.CardFilters
{
    abstract class OpponentsBattleZoneCardFilter : CardFilter
    {
        public OpponentsBattleZoneCardFilter() : base()
        {
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            return game.BattleZone.GetCreatures(game.GetOpponent(player).Id).Contains(card);
        }
    }
}
