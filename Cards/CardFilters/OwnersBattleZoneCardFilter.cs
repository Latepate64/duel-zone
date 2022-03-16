using Engine;
using System.Linq;

namespace Cards.CardFilters
{
    abstract class OwnersBattleZoneCardFilter : CardFilter
    {
        public OwnersBattleZoneCardFilter() : base()
        {
        }

        public OwnersBattleZoneCardFilter(OwnersBattleZoneCardFilter filter) : base(filter)
        {
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            return player != null && game.BattleZone.GetCreatures(player.Id).Contains(card);
        }
    }
}
