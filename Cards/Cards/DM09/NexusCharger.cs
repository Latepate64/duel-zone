namespace Cards.Cards.DM09
{
    class NexusCharger : Charger
    {
        public NexusCharger() : base("Nexus Charger", 6, Engine.Civilization.Light)
        {
            AddSpellAbilities(new OneShotEffects.AddCardFromYourHandToYourShieldsFaceDownEffect());
        }
    }
}
