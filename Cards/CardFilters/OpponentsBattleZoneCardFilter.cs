using Engine;
using System.Linq;

namespace Cards.CardFilters
{
    abstract class OpponentsBattleZoneCardFilter : CardFilter
    {
        public OpponentsBattleZoneCardFilter() : base()
        {
        }

        public override bool Applies(ICard card, IGame game, IPlayer player)
        {
            return game.BattleZone.GetCreatures(game.GetOpponent(player).Id).Contains(card);
        }
    }
}
