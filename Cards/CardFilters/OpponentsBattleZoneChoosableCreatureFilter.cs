﻿using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.CardFilters
{
    class OpponentsBattleZoneChoosableCreatureFilter : OpponentsBattleZoneCreatureFilter
    {
        public OpponentsBattleZoneChoosableCreatureFilter()
        {
        }

        public override bool Applies(ICard card, IGame game, IPlayer player)
        {
            return base.Applies(card, game, player) && !game.GetContinuousEffects<IUnchoosableEffect>(card).Any(effect => effect.Applies(card, game));
        }

        public override CardFilter Copy()
        {
            return new OpponentsBattleZoneChoosableCreatureFilter();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
