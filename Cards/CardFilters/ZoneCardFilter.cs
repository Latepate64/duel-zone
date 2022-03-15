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

        protected ZoneCardFilter(ZoneCardFilter<T> filter) : base(filter)
        {
            OwnerInsteadOfOpponent = filter.OwnerInsteadOfOpponent;
        }

        public override string ToString()
        {
            return $"{(OwnerInsteadOfOpponent ? "Your" : "Your opponent's")} {typeof(T)}";
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            var targetPlayer = OwnerInsteadOfOpponent ? player : game.GetOpponent(player);
            return base.Applies(card, game, player) && targetPlayer != null && targetPlayer.Zones.OfType<T>().Single().Cards.Contains(card);
        }
    }
}
