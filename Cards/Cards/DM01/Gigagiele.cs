﻿namespace Cards.Cards.DM01
{
    class Gigagiele : Creature
    {
        public Gigagiele() : base("Gigagiele", 5, 3000, Common.Subtype.Chimera, Common.Civilization.Darkness)
        {
            AddSlayerAbility();
        }
    }
}
