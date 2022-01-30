
using DuelMastersModels;

namespace Cards.CardFilters
{
    class OwnersBattleZoneCreatureFilter : OwnersBattleZoneCardFilter
    {
        public OwnersBattleZoneCreatureFilter()
        {
        }

        public OwnersBattleZoneCreatureFilter(OwnersBattleZoneCreatureFilter filter) : base(filter)
        {
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            return base.Applies(card, game, player) && card.CardType == CardType.Creature;
        }

        public override CardFilter Copy()
        {
            return new OwnersBattleZoneCreatureFilter(this);
        }
    }
}
