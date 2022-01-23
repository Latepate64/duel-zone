﻿using DuelMastersModels;

namespace DuelMastersCards.CardFilters
{
    class OwnersDeckCreatureFilter : OwnersDeckCardFilter
    {
        public OwnersDeckCreatureFilter()
        {
        }

        public OwnersDeckCreatureFilter(CardFilter filter) : base(filter)
        {
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            return base.Applies(card, game, player) && card.CardType == CardType.Creature;
        }

        public override CardFilter Copy()
        {
            return new OwnersDeckCreatureFilter(this);
        }
    }
}
