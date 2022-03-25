﻿using Cards.CardFilters;

namespace Cards.Cards.DM02
{
    class PoisonWorm : Creature
    {
        public PoisonWorm() : base("Poison Worm", 4, 4000, Common.Subtype.ParasiteWorm, Common.Civilization.Darkness)
        {
            // When you put this creature into the battle zone, destroy one of your creatures that has power 3000 or less.
            AddAbilities(new TriggeredAbilities.WhenThisCreatureIsPutIntoTheBattleZoneAbility(new OneShotEffects.DestroyEffect(new OwnersBattleZoneMaxPowerCreatureFilter(3000), 1, 1, true)));
        }
    }
}
