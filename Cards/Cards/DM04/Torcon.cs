﻿namespace Cards.Cards.DM04
{
    class Torcon : Creature
    {
        public Torcon() : base("Torcon", 2, 1000, Engine.Subtype.BeastFolk, Engine.Civilization.Nature)
        {
            AddShieldTrigger();
        }
    }
}
