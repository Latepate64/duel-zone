﻿using Common;

namespace Cards.Cards.DM10
{
    class GajirabuteVileCenturion : Creature
    {
        public GajirabuteVileCenturion() : base("Gajirabute, Vile Centurion", 6, 3000, Subtype.DemonCommand, Civilization.Darkness)
    {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ChooseOneOfYourOpponentsShieldsAndPutItIntoHisGraveyardEffect());
        }
    }
}
