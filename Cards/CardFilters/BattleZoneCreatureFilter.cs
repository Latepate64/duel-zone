﻿using Engine;

namespace Cards.CardFilters
{
    class BattleZoneCreatureFilter : BattleZoneCardFilter
    {
        public BattleZoneCreatureFilter() : base()
        {
        }

        public BattleZoneCreatureFilter(Common.Subtype subtype) : base(subtype)
        {
        }

        public BattleZoneCreatureFilter(CardFilter filter) : base(filter)
        {
        }


        public override bool Applies(Card card, Game game, Player player)
        {
            return base.Applies(card, game, player) && new CreatureFilter().Applies(card, game, player);
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
