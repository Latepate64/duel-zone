﻿using Cards.StaticAbilities;
using Common;

namespace Cards.Cards.DM02
{
    class LadiaBaleTheInspirational : EvolutionCreature
    {
        public LadiaBaleTheInspirational() : base("Ladia Bale, the Inspirational", 6, 9500, Subtype.Guardian, Civilization.Light)
        {
            AddAbilities(new BlockerAbility(), new DoubleBreakerAbility());
        }
    }
}