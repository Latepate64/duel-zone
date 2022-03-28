﻿using Cards.OneShotEffects;
using Common;

namespace Cards.Cards.DM02
{
    class BurstShot : Spell
    {
        public BurstShot() : base("Burst Shot", 6, Civilization.Fire)
        {
            ShieldTrigger = true;
            AddSpellAbilities(new DestroyMaxPowerAreaOfEffect(2000));
        }
    }
}
