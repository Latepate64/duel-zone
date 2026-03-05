namespace Cards.DM08
{
    sealed class EurekaCharger : Charger
    {
        public EurekaCharger() : base("Eureka Charger", 4, Interfaces.Civilization.Water)
        {
            AddSpellAbilities(new OneShotEffects.DrawCardEffect());
        }
    }
}
