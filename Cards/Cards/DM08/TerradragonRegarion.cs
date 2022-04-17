﻿namespace Cards.Cards.DM08
{
    class TerradragonRegarion : Creature
    {
        public TerradragonRegarion() : base("Terradragon Regarion", 5, 4000, Engine.Race.EarthDragon, Engine.Civilization.Nature)
        {
            AddPowerAttackerAbility(3000);
            AddDoubleBreakerAbility();
        }
    }
}
