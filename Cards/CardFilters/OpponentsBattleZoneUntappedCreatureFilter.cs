using Engine;

namespace Cards.CardFilters
{
    class OpponentsBattleZoneUntappedCreatureFilter : OpponentsBattleZoneCreatureFilter
    {
        public OpponentsBattleZoneUntappedCreatureFilter()
        {
        }

        public OpponentsBattleZoneUntappedCreatureFilter(OpponentsBattleZoneCardFilter filter) : base(filter)
        {
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            return base.Applies(card, game, player) && !card.Tapped;
        }

        public override CardFilter Copy()
        {
            return new OpponentsBattleZoneUntappedCreatureFilter(this);
        }

        public override string ToString()
        {
            return $"your opponent's untapped {ToStringBase()}s";
        }
    }
}
