﻿using Common;

namespace Cards.Cards.DM07
{
    class Biancus : Creature
    {
        public Biancus() : base("Biancus", 6, 3000, Subtype.SeaHacker, Civilization.Water)
        {
            AddAbilities(new StaticAbilities.BlockerAbility(), new Engine.Abilities.TapAbility(new OneShotEffects.ChooseOneOfYourCreaturesInTheBattleZoneItCannotBeBlockedThisTurnEffect()));
        }
    }
}
