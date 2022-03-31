namespace Cards.Cards.DM08
{
    class QuixoticHeroSwineSnout : Creature
    {
        public QuixoticHeroSwineSnout() : base("Quixotic Hero Swine Snout", 2, 1000, Common.Subtype.BeastFolk, Common.Civilization.Nature)
        {
            AddTriggeredAbility(new TriggeredAbilities.WheneverAnotherCreatureIsPutIntoTheBattleZoneAbility(new OneShotEffects.ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect()));
        }
    }
}
