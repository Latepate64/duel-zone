﻿using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    class MightyShouter : Creature
    {
        public MightyShouter() : base("Mighty Shouter", 3, 2000, Common.Subtype.BeastFolk, Common.Civilization.Nature)
        {
            // When this creature would be destroyed, put it into your mana zone instead.
            Abilities.Add(new WhenThisCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadAbility());
        }
    }
}
