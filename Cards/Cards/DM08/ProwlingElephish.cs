﻿namespace Cards.Cards.DM08
{
    class ProwlingElephish : Creature
    {
        public ProwlingElephish() : base("Prowling Elephish", 4, 2000, Engine.Subtype.GelFish, Engine.Civilization.Water)
        {
            AddBlockerAbility();
        }
    }
}
