﻿using Cards.StaticAbilities;
using Engine;

namespace Cards.Cards.DM01
{
    public class Gigagiele : Creature
    {
        public Gigagiele() : base("Gigagiele", 5, Civilization.Darkness, 3000, Subtype.Chimera)
        {
            Abilities.Add(new SlayerAbility());
        }
    }
}