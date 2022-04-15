﻿namespace Cards.Cards.DM03
{
    class AquaDeformer : Creature
    {
        public AquaDeformer() : base("Aqua Deformer", 8, 3000, Engine.Subtype.LiquidPeople, Engine.Civilization.Water)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.MutualManaRecoveryEffect(2));
        }
    }
}
