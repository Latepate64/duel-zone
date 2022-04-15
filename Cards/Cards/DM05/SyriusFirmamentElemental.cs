﻿namespace Cards.Cards.DM05
{
    class SyriusFirmamentElemental : Creature
    {
        public SyriusFirmamentElemental() : base("Syrius, Firmament Elemental", 11, 12000, Engine.Subtype.AngelCommand, Engine.Civilization.Light)
        {
            AddBlockerAbility();
            AddTripleBreakerAbility();
        }
    }
}
