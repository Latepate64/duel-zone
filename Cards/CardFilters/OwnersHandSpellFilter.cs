﻿using Engine;

namespace Cards.CardFilters
{
    class OwnersHandSpellFilter : OwnersHandCardFilter
    {
        public OwnersHandSpellFilter()
        {
        }

        public OwnersHandSpellFilter(OwnersHandSpellFilter filter) : base(filter)
        {
        }

        public override CardFilter Copy()
        {
            return new OwnersHandSpellFilter(this);
        }

        public override string ToString()
        {
            return $"{base.ToString()} spell";
        }

        public override bool Applies(ICard card, IGame game, IPlayer player)
        {
            return base.Applies(card, game, player) && new SpellFilter().Applies(card, game, player);
        }
    }
}