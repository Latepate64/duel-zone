using Engine;
using System.Linq;

namespace Cards.CardFilters
{
    abstract class OwnersBattleZoneCardFilter : CardFilter
    {
        public OwnersBattleZoneCardFilter(params Common.Civilization[] civilizations) : base(civilizations)
        {
        }

        public OwnersBattleZoneCardFilter(OwnersBattleZoneCardFilter filter) : base(filter)
        {
        }

        public OwnersBattleZoneCardFilter(Common.Subtype subtype) : base(subtype)
        {
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            return base.Applies(card, game, player) && game.BattleZone.GetCreatures(player.Id).Contains(card);
        }
    }
}
