﻿using DuelMastersModels;

namespace DuelMastersCards.CardFilters
{
    class OwnersDeckCardFilter : CardFilter
    {
        public OwnersDeckCardFilter()
        {
        }

        public OwnersDeckCardFilter(CardFilter filter) : base(filter)
        {
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            return player != null && player.Graveyard.Cards.Contains(card);
        }

        public override CardFilter Copy()
        {
            return new OwnersDeckCardFilter(this);
        }
    }
}