namespace Cards.DM09
{
    sealed class NexusCharger : Charger
    {
        public NexusCharger() : base("Nexus Charger", 6, Interfaces.Civilization.Light)
        {
            AddSpellAbilities(new OneShotEffects.AddCardFromYourHandToYourShieldsFaceDownEffect());
        }
    }
}
