﻿using Common;

namespace Cards.Cards.DM06
{
    class LupaPoisonTippedDoll : Creature
    {
        public LupaPoisonTippedDoll() : base("Lupa, Poison-Tipped Doll", 2, 1000, Subtype.DeathPuppet, Civilization.Darkness)
        {
            AddAbilities(new Engine.Abilities.TapAbility(new OneShotEffects.OneOfYourCreaturesGetsAbilityUntilTheEndOfTheTurnEffect(new StaticAbilities.SlayerAbility())));
        }
    }
}