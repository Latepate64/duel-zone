﻿namespace Cards.Cards.DM02
{
    class FortressShell : Creature
    {
        public FortressShell() : base("Fortress Shell", 9, 5000, Engine.Race.ColonyBeetle, Engine.Civilization.Nature)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ChooseUpToTwoCardsInYourOpponentsManaZoneAndPutThemIntoHisGraveyardEffect());
        }
    }
}
