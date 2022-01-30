﻿using Engine;

namespace Cards.CardFilters
{
    class BattleZoneCreatureFilter : BattleZoneCardFilter
    {
        public BattleZoneCreatureFilter()
        {
        }

        public BattleZoneCreatureFilter(CardFilter filter) : base(filter)
        {
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            return base.Applies(card, game, player) && card.CardType == CardType.Creature;
        }

        public override CardFilter Copy()
        {
            return new BattleZoneCreatureFilter(this);
        }
    }
}
