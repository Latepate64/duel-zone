using Engine;

namespace Cards.CardFilters
{
    class OpponentsShieldZoneCardFilter : CardFilter
    {
        public OpponentsShieldZoneCardFilter()
        {
        }

        public OpponentsShieldZoneCardFilter(OpponentsShieldZoneCardFilter filter) : base(filter)
        {
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            return base.Applies(card, game, player) && player != null && game.GetOpponent(player).ShieldZone.Cards.Contains(card);
        }

        public override CardFilter Copy()
        {
            return new OpponentsShieldZoneCardFilter(this);
        }

        public override string ToString()
        {
            return $"{ToStringBase()} in your opponent's shield zone";
        }
    }
}
