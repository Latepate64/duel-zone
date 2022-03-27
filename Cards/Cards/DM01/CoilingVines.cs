﻿using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    class CoilingVines : Creature
    {
        public CoilingVines() : base("Coiling Vines", 4, 3000, Common.Subtype.TreeFolk, Common.Civilization.Nature)
        {
            AddAbilities(new WhenThisCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadAbility());
        }
    }
}
