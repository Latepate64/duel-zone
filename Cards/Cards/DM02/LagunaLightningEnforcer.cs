﻿namespace Cards.Cards.DM02
{
    class LagunaLightningEnforcer : Creature
    {
        public LagunaLightningEnforcer() : base("Laguna, Lightning Enforcer", 5, 2500, Engine.Race.Berserker, Engine.Civilization.Light)
        {
            AddWheneverThisCreatureAttacksAbility(new OneShotEffects.SearchSpellEffect());
        }
    }
}
