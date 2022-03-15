using Engine;

namespace Cards.CardFilters
{
    class OwnersBattleZoneCreatureFilter : OwnersBattleZoneCardFilter
    {
        public OwnersBattleZoneCreatureFilter() : base()
        {
        }

        public OwnersBattleZoneCreatureFilter(Common.Subtype subtype) : base(subtype) { }

        public OwnersBattleZoneCreatureFilter(OwnersBattleZoneCreatureFilter filter) : base(filter)
        {
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            return base.Applies(card, game, player) && new CreatureFilter().Applies(card, game, player);
        }

        public override CardFilter Copy()
        {
            return new OwnersBattleZoneCreatureFilter(this);
        }

        public override string ToString()
        {
            return $"your {ToStringBase()}s";
        }
    }
}
