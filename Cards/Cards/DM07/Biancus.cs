﻿using Common;

namespace Cards.Cards.DM07
{
    class Biancus : Creature
    {
        public Biancus() : base("Biancus", 6, 3000, Subtype.SeaHacker, Civilization.Water)
        {
            AddBlockerAbility();
            AddAbilities(new Engine.Abilities.TapAbility(new OneShotEffects.ChooseOneOfYourCreaturesInTheBattleZoneItCannotBeBlockedThisTurnEffect()));
        }
    }
}
