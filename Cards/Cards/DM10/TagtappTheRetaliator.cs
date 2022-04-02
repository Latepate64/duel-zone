﻿using Common;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM10
{
    class TagtappTheRetaliator : Creature
    {
        public TagtappTheRetaliator() : base("Tagtapp, the Retaliator", 3, 3000, Subtype.SpiritQuartz, Civilization.Fire, Civilization.Nature)
        {
            AddStaticAbilities(new TagtappTheRetaliatorEffect(), new ContinuousEffects.PoweredDoubleBreaker());
        }
    }

    class TagtappTheRetaliatorEffect : ContinuousEffects.PowerModifyingMultiplierEffect
    {
        public TagtappTheRetaliatorEffect() : base(1000, new CardFilters.OpponentsManaZoneCivilizationCardFilter(Civilization.Water))
        {
        }

        public override IContinuousEffect Copy()
        {
            return new TagtappTheRetaliatorEffect();
        }

        public override string ToString()
        {
            return "This creature gets +1000 power for each water card in your opponent's mana zone.";
        }
    }
}