﻿namespace Cards.Cards.DM01
{
    class Seamine : Creature
    {
        public Seamine() : base("Seamine", 6, 4000, Engine.Subtype.Fish, Common.Civilization.Water)
        {
            AddBlockerAbility();
        }
    }
}
