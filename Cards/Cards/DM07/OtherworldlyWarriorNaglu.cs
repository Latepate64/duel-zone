﻿namespace Cards.Cards.DM07
{
    class OtherworldlyWarriorNaglu : Creature
    {
        public OtherworldlyWarriorNaglu() : base("Otherworldly Warrior Naglu", 6, 4000, Engine.Subtype.Armorloid, Engine.Civilization.Fire)
        {
            AddThisCreatureCannotBeAttackedAbility();
            AddPowerAttackerAbility(3000);
            AddDoubleBreakerAbility();
        }
    }
}
