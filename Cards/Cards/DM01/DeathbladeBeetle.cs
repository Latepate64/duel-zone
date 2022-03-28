﻿using Cards.ContinuousEffects;

namespace Cards.Cards.DM01
{
    class DeathbladeBeetle : Creature
    {
        public DeathbladeBeetle() : base("Deathblade Beetle", 5, 3000, Common.Subtype.GiantInsect, Common.Civilization.Nature)
        {
            AddStaticAbilities(new PowerAttackerEffect(4000), new DoubleBreakerEffect());
        }
    }
}
