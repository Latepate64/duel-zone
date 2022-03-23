﻿using Common;

namespace Cards.Cards.DM05
{
    class BladerushSkyterrorQ : Creature
    {
        public BladerushSkyterrorQ() : base("Bladerush Skyterror Q", 7, 5000, Civilization.Fire)
        {
            AddSubtypes(Subtype.Survivor, Subtype.ArmoredWyvern);
            AddAbilities(new StaticAbilities.SurvivorAbility(new StaticAbilities.DoubleBreakerAbility()));
        }
    }
}