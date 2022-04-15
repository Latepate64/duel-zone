﻿using Common;

namespace Cards.Cards.DM12
{
    class MizoyTheOracle : Creature
    {
        public MizoyTheOracle() : base("Mizoy, the Oracle", 3, 2500, Engine.Subtype.LightBringer, Civilization.Light)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.YouMayChooseDarknessOrFireCreatureInTheBattleZoneAndTapItEffect());
        }
    }
}
