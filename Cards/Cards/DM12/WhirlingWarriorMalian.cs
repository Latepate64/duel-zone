﻿using Common;

namespace Cards.Cards.DM12
{
    class WhirlingWarriorMalian : Creature
    {
        public WhirlingWarriorMalian() : base("Whirling Warrior Malian", 4, 6000, Subtype.Armorloid, Civilization.Fire)
        {
            AddAbilities(new TriggeredAbilities.PutIntoPlayAbility(new OneShotEffects.TapAreaOfEffect(new Engine.TargetFilter()), new CardFilters.AnotherBattleZoneCreatureFilter()));
        }
    }
}