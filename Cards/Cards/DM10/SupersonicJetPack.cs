﻿using Cards.OneShotEffects;
using Cards.StaticAbilities;

namespace Cards.Cards.DM10
{
    class SupersonicJetPack : Spell
    {
        public SupersonicJetPack() : base("Supersonic Jet Pack", 1, Common.Civilization.Fire)
        {
            // One of your creatures in the battle zone gets "speed attacker" until the end of the turn. (It doesn't get summoning sickness.)
            AddSpellAbilities(new GrantAbilityChoiceEffect(new CardFilters.OwnersBattleZoneCreatureFilter(), 1, 1, true, new SpeedAttackerAbility()));
        }
    }
}
