using Engine;
using System.Linq;

namespace Cards.CardFilters
{
    class HandCardFilter : CardFilter
    {
        public HandCardFilter()
        {
        }

        public override bool Applies(ICard card, IGame game, IPlayer player)
        {
            return game.Players.Any(x => x.Hand.Cards.Contains(card));
        }

        public override CardFilter Copy()
        {
            return new HandCardFilter();
        }

        public override string ToString()
        {
            return "hand";
        }
    }
}
