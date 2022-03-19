using Engine;
using Engine.Zones;
using System.Linq;

namespace Cards.CardFilters
{
    abstract class ZoneCardFilter<T> : CardFilter where T : Zone
    {
        public bool OwnerInsteadOfOpponent { get; }

        protected ZoneCardFilter(bool ownerInsteadOfOpponent) : base()
        {
            OwnerInsteadOfOpponent = ownerInsteadOfOpponent;
        }

        protected ZoneCardFilter(ZoneCardFilter<T> filter) : base()
        {
            OwnerInsteadOfOpponent = filter.OwnerInsteadOfOpponent;
        }

        public override string ToString()
        {
            return $"{(OwnerInsteadOfOpponent ? "Your" : "Your opponent's")} {typeof(T)}";
        }

        public override bool Applies(Card card, Game game, IPlayer player)
        {
            var targetPlayer = OwnerInsteadOfOpponent ? player : game.GetOpponent(player);
            return targetPlayer != null && targetPlayer.Zones.OfType<T>().Single().Cards.Contains(card);
        }
    }
}
