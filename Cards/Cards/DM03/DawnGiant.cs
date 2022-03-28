﻿namespace Cards.Cards.DM03
{
    class DawnGiant : Creature
    {
        public DawnGiant() : base("Dawn Giant", 7, 11000, Common.Subtype.Giant, Common.Civilization.Nature)
        {
            AddStaticAbilities(new ContinuousEffects.ThisCreatureCannotAttackCreaturesEffect());
            AddDoubleBreakerAbility();
        }
    }
}
