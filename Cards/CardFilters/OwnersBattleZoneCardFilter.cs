using Engine;
using System.Linq;

namespace Cards.CardFilters
{
    abstract class OwnersBattleZoneCardFilter : CardFilter
    {
        public OwnersBattleZoneCardFilter() : base()
        {
        }

        public override bool Applies(Card card, Game game, IPlayer player)
        {
            return player != null && game.BattleZone.GetCreatures(player.Id).Contains(card);
        }
    }
}
