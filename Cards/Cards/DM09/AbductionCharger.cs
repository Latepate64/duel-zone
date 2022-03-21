﻿using Cards.OneShotEffects;
using Common;

namespace Cards.Cards.DM09
{
    class AbductionCharger : Charger
    {
        public AbductionCharger() : base("Abduction Charger", 7, Civilization.Water)
        {
            AddSpellAbilities(new BounceEffect(0, 2, new CardFilters.BattleZoneCreatureFilter()));
        }
    }
}
