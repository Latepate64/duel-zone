using DuelMastersModels;
using System.Linq;

namespace Cards.CardFilters
{
    class OwnersBattleZoneCardFilter : CardFilter
    {
        public OwnersBattleZoneCardFilter()
        {
        }

        public OwnersBattleZoneCardFilter(OwnersBattleZoneCardFilter filter) : base(filter)
        {
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            return base.Applies(card, game, player) && game.BattleZone.GetCreatures(player.Id).Contains(card);
        }

        public override CardFilter Copy()
        {
            return new OwnersBattleZoneCardFilter(this);
        }
    }
}
