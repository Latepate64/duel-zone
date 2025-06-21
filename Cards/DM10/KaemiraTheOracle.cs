namespace Cards.DM10
{
    class KaemiraTheOracle : SilentSkillCreature
    {
        public KaemiraTheOracle() : base("Kaemira, the Oracle", 4, 1000, Interfaces.Race.LightBringer, Interfaces.Civilization.Light)
        {
            AddSilentSkillAbility(new OneShotEffects.AddTheTopCardOfYourDeckToYourShieldsFaceDownEffect());
        }
    }
}
