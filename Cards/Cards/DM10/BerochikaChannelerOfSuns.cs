﻿using Common;

namespace Cards.Cards.DM10
{
    class BerochikaChannelerOfSuns : Creature
    {
        public BerochikaChannelerOfSuns() : base("Berochika, Channeler of Suns", 5, 5000, Subtype.MechaDelSol, Civilization.Light)
        {
            AddTriggeredAbility(new TriggeredAbilities.AncientHornTheWatcherAbility(new OneShotEffects.AddTheTopCardOfYourDeckToYourShieldsFaceDownEffect()));
        }
    }
}