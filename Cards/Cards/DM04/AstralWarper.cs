﻿namespace Cards.Cards.DM04
{
    class AstralWarper : EvolutionCreature
    {
        public AstralWarper() : base("Astral Warper", 6, 5000, Engine.Subtype.CyberVirus, Engine.Civilization.Water)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.YouMayDrawCardsEffect(3));
        }
    }
}
