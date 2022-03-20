﻿using Cards.OneShotEffects;
using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    class MagmaGazer : Spell
    {
        public MagmaGazer() : base("Magma Gazer", 3, Common.Civilization.Fire)
        {
            // One of your creatures gets "power attacker +4000" and "double breaker" until the end of the turn. (A creature that has "power attacker +4000" and "double breaker" gets +4000 power while attacking and breaks 2 shields.)
            AddSpellAbilities(new GrantAbilityChoiceEffect(new CardFilters.OwnersBattleZoneCreatureFilter(), 1, 1, true, new PowerAttackerAbility(4000), new DoubleBreakerAbility()));
        }
    }
}
