﻿using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    class RedEyeScorpion : Creature
    {
        public RedEyeScorpion() : base("Red-Eye Scorpion", 5, 4000, Common.Subtype.GiantInsect, Common.Civilization.Nature)
        {
            Abilities.Add(new WhenThisCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadAbility());
        }
    }
}
