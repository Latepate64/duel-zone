﻿using Cards.OneShotEffects;

namespace Cards.Cards.DM01
{
    class CrystalMemory : Spell
    {
        public CrystalMemory() : base("Crystal Memory", 4, Engine.Civilization.Water)
        {
            AddShieldTrigger();
            AddSpellAbilities(new SearchCardNoRevealEffect());
        }
    }
}
