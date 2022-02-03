﻿using Cards.OneShotEffects;
using Cards.TriggeredAbilities;
using Engine;

namespace Cards.Cards.DM01
{
    public class UnicornFish : Creature
    {
        public UnicornFish() : base("Unicorn Fish", 4, Civilization.Water, 1000, Subtype.Fish)
        {
            // When you put this creature into the battle zone, you may choose 1 creature in the battle zone and return it to its owner's hand.
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new BounceEffect(0, 1, new CardFilters.BattleZoneChoosableCreatureFilter())));
        }
    }
}