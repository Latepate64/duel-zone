﻿using Common;

namespace Cards.Cards.DM06
{
    class AquaRider : Creature
    {
        public AquaRider() : base("Aqua Rider", 4, 2000, Subtype.LiquidPeople, Civilization.Water)
        {
            AddAbilities(new TriggeredAbilities.OpponentSummonOrCastAbility(new OneShotEffects.ThisCreatureGetsBlockerUntilTheEndOfTheTurnEffect()));
        }
    }
}
