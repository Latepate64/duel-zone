namespace Cards.DM09
{
    class NexusCharger : Charger
    {
        public NexusCharger() : base("Nexus Charger", 6, Interfaces.Civilization.Light)
        {
            AddSpellAbilities(new OneShotEffects.AddCardFromYourHandToYourShieldsFaceDownEffect());
        }
    }
}
