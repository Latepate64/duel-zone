﻿using Common;

namespace Cards.Cards.DM10
{
    class GaulezalDragon : Creature
    {
        public GaulezalDragon() : base("Gaulezal Dragon", 9, 11000, Engine.Subtype.ArmoredDragon, Civilization.Fire)
        {
            AddDoubleBreakerAbility();
        }
    }
}
