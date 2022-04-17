﻿namespace Cards.Cards.DM01
{
    class RoaringGreatHorn : Creature
    {
        public RoaringGreatHorn() : base("Roaring Great-Horn", 7, 8000, Engine.Race.HornedBeast, Engine.Civilization.Nature)
        {
            AddPowerAttackerAbility(2000);
            AddDoubleBreakerAbility();
        }
    }
}
