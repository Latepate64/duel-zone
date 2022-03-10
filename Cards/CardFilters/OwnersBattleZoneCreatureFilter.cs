
using Engine;

namespace Cards.CardFilters
{
    class OwnersBattleZoneCreatureFilter : OwnersBattleZoneCardFilter
    {
        public OwnersBattleZoneCreatureFilter(params Common.Civilization[] civilizations) : base(civilizations)
        {
            CardType = Common.CardType.Creature;
        }

        public OwnersBattleZoneCreatureFilter(OwnersBattleZoneCreatureFilter filter) : base(filter)
        {
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            return base.Applies(card, game, player) && card.CardType == Common.CardType.Creature;
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
