﻿using Common;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM12
{
    class PincerScarab : Creature
    {
        public PincerScarab() : base("Pincer Scarab", 4, 1000, Subtype.GiantInsect, Civilization.Nature)
        {
            AddStaticAbilities(new PincerScarabEffect(), new ContinuousEffects.PoweredDoubleBreaker());
        }
    }

    class PincerScarabEffect : ContinuousEffects.PowerModifyingMultiplierEffect
    {
        public PincerScarabEffect() : base(2000, new CardFilters.OpponentsHandCardFilter())
        {
        }

        public override IContinuousEffect Copy()
        {
            return new PincerScarabEffect();
        }

        public override string ToString()
        {
            return "This creature gets +2000 power for each card in your opponent's hand.";
        }
    }
}