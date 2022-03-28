﻿using Common;

namespace Cards.Cards.DM02
{
    class AmberPiercer : Creature
    {
        public AmberPiercer() : base("Amber Piercer", 4, 2000, Subtype.BrainJacker, Civilization.Darkness)
        {
            AddWheneverThisCreatureAttacksAbility(new OneShotEffects.YouMayReturnCreatureFromYourGraveyardToYourHandEffect());
        }
    }
}