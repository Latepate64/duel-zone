﻿namespace Cards.Cards.DM01
{
    class DeathligerLionOfChaos : Creature
    {
        public DeathligerLionOfChaos() : base("Deathliger, Lion of Chaos", 7, 9000, Engine.Subtype.DemonCommand, Common.Civilization.Darkness)
        {
            AddDoubleBreakerAbility();
        }
    }
}
