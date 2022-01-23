﻿using DuelMastersCards.OneShotEffects;
using DuelMastersCards.StaticAbilities;
using DuelMastersModels;
using DuelMastersModels.Abilities;

namespace DuelMastersCards.Cards
{
    class MagmaGazer : Spell
    {
        public MagmaGazer() : base("Magma Gazer", 3, Civilization.Fire)
        {
            // One of your creatures gets "power attacker +4000" and "double breaker" until the end of the turn. (A creature that has "power attacker +4000" and "double breaker" gets +4000 power while attacking and breaks 2 shields.)
            Abilities.Add(new SpellAbility(new GrantAbilityToOwnersCreatureEffect(new PowerAttackerAbility(4000), new DoubleBreakerAbility())));
        }
    }
}
