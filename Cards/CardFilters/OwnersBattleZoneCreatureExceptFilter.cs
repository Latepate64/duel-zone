using Engine;

namespace Cards.CardFilters
{
    class OwnersBattleZoneCreatureExceptFilter : OwnersBattleZoneCreatureFilter
    {
        public OwnersBattleZoneCreatureExceptFilter() : base()
        {
        }

        public OwnersBattleZoneCreatureExceptFilter(OwnersBattleZoneCreatureExceptFilter filter) : base(filter)
        {
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            return base.Applies(card, game, player) && card.Id != Target;
        }

        public override CardFilter Copy()
        {
            return new OwnersBattleZoneCreatureExceptFilter(this);
        }

        public override string ToString()
        {
            return $"your other {ToStringBase()}s";
        }
    }
}
