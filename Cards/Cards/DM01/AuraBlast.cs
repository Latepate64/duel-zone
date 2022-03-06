﻿using Cards.OneShotEffects;
using Cards.StaticAbilities;
using Engine.Abilities;

namespace Cards.Cards.DM01
{
    class AuraBlast : Spell
    {
        public AuraBlast() : base("Aura Blast", 4, Common.Civilization.Nature)
        {
            // Each of your creatures in the battle zone gets "power attacker +2000" until the end of the turn. (While attacking, a creature that has "power attacker +2000" gets +2000 power.)
            AddAbilities(new SpellAbility(new GrantAbilityAreaOfEffect(new PowerAttackerAbility(2000))));
        }
    }
}
