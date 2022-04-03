﻿using Common;

namespace Cards.Cards.DM11
{
    class AquaTrickster : WaveStrikerCreature
    {
        public AquaTrickster() : base("Aqua Trickster", 2, 1000, Subtype.LiquidPeople, Civilization.Water)
        {
            AddWaveStrikerAbility(new TriggeredAbilities.WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ChooseOneOfYourOpponentsCreaturesInTheBattleZoneAndTapItEffect()));
        }
    }
}