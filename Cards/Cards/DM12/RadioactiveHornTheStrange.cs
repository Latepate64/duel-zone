﻿using Common;

namespace Cards.Cards.DM12
{
    class RadioactiveHornTheStrange : Creature
    {
        public RadioactiveHornTheStrange() : base("Radioactive Horn, the Strange", 3, 1000, Subtype.HornedBeast, Civilization.Nature)
        {
            AddDoubleBreakerAbility();
        }
    }
}