﻿using Common;

namespace Cards.Cards.DM07
{
    class GeoshineSpectralKnight : Creature
    {
        public GeoshineSpectralKnight() : base("Geoshine, Spectral Knight", 5, 4000, Subtype.RainbowPhantom, Civilization.Light)
        {
            AddAbilities(new TriggeredAbilities.AttackAbility(new OneShotEffects.TapChoiceEffect(1, 1, true, new CardFilters.BattleZoneCreatureFilter(Civilization.Darkness, Civilization.Fire))));
        }
    }
}