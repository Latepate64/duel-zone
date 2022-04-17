namespace Cards.Cards.DM10
{
    class KaemiraTheOracle : SilentSkillCreature
    {
        public KaemiraTheOracle() : base("Kaemira, the Oracle", 4, 1000, Engine.Race.LightBringer, Engine.Civilization.Light)
        {
            AddSilentSkillAbility(new OneShotEffects.AddTheTopCardOfYourDeckToYourShieldsFaceDownEffect());
        }
    }
}
