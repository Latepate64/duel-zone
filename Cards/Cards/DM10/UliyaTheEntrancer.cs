﻿using Common;

namespace Cards.Cards.DM10
{
    class UliyaTheEntrancer : Creature
    {
        public UliyaTheEntrancer() : base("Uliya, the Entrancer", 6, 5000, Engine.Subtype.DarkLord, Civilization.Darkness)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ShieldRecoveryCanUseShieldTriggerEffect());
        }
    }
}
