﻿using Cards.OneShotEffects;

namespace Cards.Cards.DM01
{
    class ExplosiveFighterUcarn : Creature
    {
        public ExplosiveFighterUcarn() : base("Explosive Fighter Ucarn", 5, 9000, Engine.Race.Dragonoid, Engine.Civilization.Fire)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new PutCardsFromYourManaZoneIntoYourGraveyard(2));
            AddDoubleBreakerAbility();
        }
    }
}
