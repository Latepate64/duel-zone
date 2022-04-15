﻿namespace Cards.Cards.DM10
{
    class MessaBahnaExpanseGuardian : Creature
    {
        public MessaBahnaExpanseGuardian() : base("Messa Bahna, Expanse Guardian", 3, 5000, Engine.Subtype.Guardian, Engine.Civilization.Light)
        {
            AddBlockerAbility();
            AddStaticAbilities(new ContinuousEffects.ThisCreatureBlocksIfAble());
            AddThisCreatureCannotAttackPlayersAbility();
        }
    }
}
