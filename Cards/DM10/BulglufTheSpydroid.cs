namespace Cards.DM10
{
    sealed class BulglufTheSpydroid : SilentSkillCreature
    {
        public BulglufTheSpydroid() : base("Bulgluf, the Spydroid", 6, 4000, Interfaces.Race.Soltrooper, Interfaces.Civilization.Light)
        {
            AddSilentSkillAbility(new OneShotEffects.AddTheTopCardOfYourDeckToYourShieldsFaceDownEffect());
        }
    }
}
