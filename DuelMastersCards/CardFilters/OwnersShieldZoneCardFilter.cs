﻿using DuelMastersModels;

namespace Cards.CardFilters
{
    class OwnersShieldZoneCardFilter : CardFilter
    {
        public OwnersShieldZoneCardFilter()
        {
        }

        public OwnersShieldZoneCardFilter(OwnersShieldZoneCardFilter filter) : base(filter)
        {
        }

        public override bool Applies(Card card, Game game, Player player)
        {
            return base.Applies(card, game, player) && player != null && player.ShieldZone.Cards.Contains(card);
        }

        public override CardFilter Copy()
        {
            return new OwnersShieldZoneCardFilter(this);
        }
    }
}
