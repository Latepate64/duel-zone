﻿using Common;

namespace Cards.Cards.DM06
{
    class ThrashCrawler : Creature
    {
        public ThrashCrawler() : base("Thrash Crawler", 4, 5000, Engine.Subtype.EarthEater, Civilization.Water)
        {
            AddBlockerAbility();
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ReturnCardsFromYourManaZoneToYourHandEffect(1));
            AddThisCreatureCannotAttackAbility();
        }
    }
}
