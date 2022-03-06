﻿using Cards.CardFilters;
using Cards.OneShotEffects;
using Cards.TriggeredAbilities;
using Common;

namespace Cards.Cards.DM01
{
    class SaucerHeadShark : Creature
    {
        public SaucerHeadShark() : base("Saucer-Head Shark", 5, Civilization.Water, 3000, Subtype.GelFish)
        {
            // When you put this creature into the battle zone, return each creature in the battle zone that has power 2000 or less to its owner's hand.
            Abilities.Add(new PutIntoPlayAbility(new BounceAreaOfEffect(new BattleZoneMaxPowerCreatureFilter(2000))));
        }
    }
}
