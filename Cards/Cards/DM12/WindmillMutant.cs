﻿using Cards.OneShotEffects;

namespace Cards.Cards.DM12
{
    class WindmillMutant : Creature
    {
        public WindmillMutant() : base("Windmill Mutant", 3, 2000, Engine.Subtype.Hedrian, Engine.Civilization.Darkness)
        {
            AddWheneverThisCreatureAttacksAbility(new OpponentRandomDiscardEffect());
        }
    }
}
