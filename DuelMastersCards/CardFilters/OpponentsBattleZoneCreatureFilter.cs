﻿using DuelMastersModels;

namespace DuelMastersCards.CardFilters
{
    class OpponentsBattleZoneCreatureFilter : OpponentsBattleZoneCardFilter
    {
        public OpponentsBattleZoneCreatureFilter()
        {
        }

        public OpponentsBattleZoneCreatureFilter(OpponentsBattleZoneCardFilter filter) : base(filter)
        {
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            return base.Applies(card, game, player) && card.CardType == CardType.Creature;
        }
    }
}
