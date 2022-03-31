﻿using Common;

namespace Cards.Cards.DM08
{
    class BakkraHornTheSilent : Creature
    {
        public BakkraHornTheSilent() : base("Bakkra Horn, the Silent", 4, 2000, Subtype.HornedBeast, Civilization.Nature)
        {
            AddTriggeredAbility(new TriggeredAbilities.WheneverYouPutDragonoidOrDragonIntoTheBattleZoneAbility(new OneShotEffects.PutTopCardsOfDeckIntoManaZoneEffect(1)));
        }
    }
}