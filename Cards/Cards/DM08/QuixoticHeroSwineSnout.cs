﻿namespace Cards.Cards.DM08
{
    class QuixoticHeroSwineSnout : Creature
    {
        public QuixoticHeroSwineSnout() : base("Quixotic Hero Swine Snout", 2, 1000, Engine.Race.BeastFolk, Engine.Civilization.Nature)
        {
            AddTriggeredAbility(new TriggeredAbilities.WheneverAnotherCreatureIsPutIntoTheBattleZoneAbility(new OneShotEffects.ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect(3000)));
        }
    }
}
