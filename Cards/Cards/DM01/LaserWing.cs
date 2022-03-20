﻿using Cards.CardFilters;
using Cards.OneShotEffects;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM01
{
    class LaserWing : Spell
    {
        public LaserWing() : base("Laser Wing", 5, Common.Civilization.Light)
        {
            // Choose up to 2 of your creatures in the battle zone. They can't be blocked this turn.
            AddSpellAbilities(new CreateContinuousEffectChoiceEffect(new OwnersBattleZoneCreatureFilter(), 0, 2, true, new UnblockableEffect(null, new Engine.Durations.UntilTheEndOfTheTurn(), new BattleZoneCreatureFilter())));
        }
    }
}
