namespace Cards.Cards.Promo
{
    class LothRixTheIridescent : EvolutionCreature
    {
        public LothRixTheIridescent() : base("Loth Rix, the Iridescent", 6, 4000, Engine.Subtype.Guardian, Engine.Civilization.Light)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.AddTheTopCardOfYourDeckToYourShieldsFaceDownEffect());
        }
    }
}
