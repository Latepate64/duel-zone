﻿using Common;

namespace Cards.Cards.DM04
{
    class FuReilSeekerOfStorms : Creature
    {
        public FuReilSeekerOfStorms() : base("Fu Reil, Seeker of Storms", 6, 5000, Subtype.MechaThunder, Civilization.Light)
        {
            AddAbilities(new StaticAbilities.PlayersCannotUseShieldTriggerAbilitiesOfCivilizationCardsAbility(Civilization.Darkness));
        }
    }
}