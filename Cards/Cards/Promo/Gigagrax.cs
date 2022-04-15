﻿using Common;

namespace Cards.Cards.Promo
{
    class Gigagrax : Creature
    {
        public Gigagrax() : base("Gigagrax", 8, 5000, Engine.Subtype.Chimera, Civilization.Darkness)
        {
            AddWhenThisCreatureIsDestroyedAbility(new OneShotEffects.YouMayDestroyOneOfYourOpponentsCreaturesEffect());
        }
    }
}
