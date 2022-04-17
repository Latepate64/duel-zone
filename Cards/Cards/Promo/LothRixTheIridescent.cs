namespace Cards.Cards.Promo
{
    class LothRixTheIridescent : EvolutionCreature
    {
        public LothRixTheIridescent() : base("Loth Rix, the Iridescent", 6, 4000, Engine.Race.Guardian, Engine.Civilization.Light)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.AddTheTopCardOfYourDeckToYourShieldsFaceDownEffect());
        }
    }
}
