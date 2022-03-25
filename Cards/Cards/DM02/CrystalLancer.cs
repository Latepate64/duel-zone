﻿using Cards.StaticAbilities;
using Common;

namespace Cards.Cards.DM02
{
    class CrystalLancer : EvolutionCreature
    {
        public CrystalLancer() : base("Crystal Lancer", 6, 8000, Subtype.LiquidPeople, Civilization.Water)
        {
            AddAbilities(new ThisCreatureCannotBeBlockedAbility(), new DoubleBreakerAbility());
        }
    }
}
