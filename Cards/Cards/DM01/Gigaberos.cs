﻿using Cards.OneShotEffects;
using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    class Gigaberos : Creature
    {
        public Gigaberos() : base("Gigaberos", 5, Common.Civilization.Darkness, 8000, Common.Subtype.Chimera)
        {
            // When you put this creature into the battle zone, destroy 2 of your other creatures or destroy this creature.
            Abilities.Add(new TriggeredAbilities.PutIntoPlayAbility(new GigaberosEffect()));
            Abilities.Add(new DoubleBreakerAbility());
        }
    }
}
