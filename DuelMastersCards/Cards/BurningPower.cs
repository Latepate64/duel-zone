﻿using DuelMastersCards.OneShotEffects;
using DuelMastersCards.StaticAbilities;
using DuelMastersModels;
using DuelMastersModels.Abilities;

namespace DuelMastersCards.Cards
{
    class BurningPower : Spell
    {
        public BurningPower() : base("Burning Power", 1, Civilization.Fire)
        {
            // One of your creatures gets "power attacker +2000" until the end of the turn. (While attacking, a creature that has "power attacker +2000" gets +2000 power.)
            Abilities.Add(new SpellAbility(new GrantAbilityToOwnersCreatureEffect(new PowerAttackerAbility(2000))));
        }
    }
}
