using Engine;
using System.Linq;

namespace Cards.CardFilters
{
    class ManaZoneCardFilter : CardFilter
    {
        public ManaZoneCardFilter()
        {
        }

        public ManaZoneCardFilter(ManaZoneCardFilter filter) : base(filter)
        {
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            return base.Applies(card, game, player) && game.Players.Any(x => x.ManaZone.Cards.Contains(card));
        }

        public override CardFilter Copy()
        {
            return new ManaZoneCardFilter(this);
        }

        public override string ToString()
        {
            return $"{ToStringBase()}s in all mana zones";
        }
    }
}
