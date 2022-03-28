﻿using Common;

namespace Cards.Cards.DM06
{
    class CosmogoldSpectralKnight : Creature
    {
        public CosmogoldSpectralKnight() : base("Cosmogold, Spectral Knight", 4, 3000, Subtype.RainbowPhantom, Civilization.Light)
        {
            AddTapAbility(new OneShotEffects.ReturnSpellFromYourManaZoneToYourHandEffect());
        }
    }
}
