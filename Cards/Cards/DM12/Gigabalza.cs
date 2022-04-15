﻿using Cards.OneShotEffects;

namespace Cards.Cards.DM12
{
    class Gigabalza : Creature
    {
        public Gigabalza() : base("Gigabalza", 4, 1000, Engine.Subtype.Chimera, Common.Civilization.Darkness)
        {
            AddShieldTrigger();
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OpponentRandomDiscardEffect());
        }
    }
}
