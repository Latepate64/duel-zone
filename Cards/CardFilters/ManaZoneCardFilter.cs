using Engine;
using System.Linq;

namespace Cards.CardFilters
{
    class ManaZoneCardFilter : CardFilter
    {
        public ManaZoneCardFilter()
        {
        }

        public override bool Applies(ICard card, IGame game, IPlayer player)
        {
            return game.Players.Any(x => x.ManaZone.Cards.Contains(card));
        }

        public override CardFilter Copy()
        {
            return new ManaZoneCardFilter();
        }

        public override string ToString()
        {
            return "cards in all mana zones";
        }
    }
}
