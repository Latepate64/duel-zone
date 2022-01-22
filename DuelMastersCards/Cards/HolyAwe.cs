﻿using DuelMastersCards.OneShotEffects;
using DuelMastersModels;
using DuelMastersModels.Abilities;

namespace DuelMastersCards.Cards
{
    public class HolyAwe : Spell
    {
        public HolyAwe() : base("Holy Awe", 6, Civilization.Light)
        {
            ShieldTrigger = true;
            // Tap all your opponent's creatures in the battle zone.
            Abilities.Add(new SpellAbility(new HolyAweEffect()));
        }
    }
}
