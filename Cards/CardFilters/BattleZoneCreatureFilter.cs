using Engine;

namespace Cards.CardFilters
{
    class BattleZoneCreatureFilter : BattleZoneCardFilter
    {
        public BattleZoneCreatureFilter(params Common.Civilization[] civilizations) : base(civilizations)
        {
            CardType = Common.CardType.Creature;
        }

        public BattleZoneCreatureFilter(CardFilter filter) : base(filter)
        {
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            return base.Applies(card, game, player) && card.CardType == Common.CardType.Creature;
        }

        public override CardFilter Copy()
        {
            return new BattleZoneCreatureFilter(this);
        }

        public override string ToString()
        {
            return $"each {ToStringBase()}";
        }
    }
}
