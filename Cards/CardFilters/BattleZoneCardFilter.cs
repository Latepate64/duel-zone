﻿using Engine;

namespace Cards.CardFilters
{
    abstract class BattleZoneCardFilter : CardFilter
    {
        public BattleZoneCardFilter() : base()
        {
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            return game.BattleZone.Cards.Contains(card);
        }
    }
}
