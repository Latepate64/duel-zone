﻿using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM05
{
    class AquaSurfer : Creature
    {
        public AquaSurfer() : base("Aqua Surfer", 6, 2000, Common.Subtype.LiquidPeople, Common.Civilization.Water)
        {
            ShieldTrigger = true;
            AddAbilities(new PutIntoPlayAbility(new YouMayChooseCreatureInTheBattleZoneAndReturnItToItsOwnersHandEffect()));
        }
    }
}
