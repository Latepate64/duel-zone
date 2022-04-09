﻿using Cards.ContinuousEffects;
using Common;

namespace Cards.Cards.DM05
{
    class BladerushSkyterrorQ : Creature
    {
        public BladerushSkyterrorQ() : base("Bladerush Skyterror Q", 7, 5000, Subtype.Survivor, Subtype.ArmoredWyvern, Civilization.Fire)
        {
            AddSurvivorAbility(new DoubleBreakerEffect());
        }
    }
}
