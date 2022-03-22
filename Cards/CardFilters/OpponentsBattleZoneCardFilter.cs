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
            var opponent = game.GetOpponent(player);
            return opponent != null && game.BattleZone.GetCreatures(opponent.Id).Contains(card);
        }
    }
}
