﻿namespace Cards.Cards.DM02
{
    class FonchTheOracle : Creature
    {
        public FonchTheOracle() : base("Fonch, the Oracle", 4, 2000, Common.Subtype.LightBringer, Common.Civilization.Light)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.YouMayChooseOneOfYourOpponentsCreaturesAndTapItEffect());
        }
    }
}
