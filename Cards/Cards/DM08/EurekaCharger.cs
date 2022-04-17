namespace Cards.Cards.DM08
{
    class EurekaCharger : Charger
    {
        public EurekaCharger() : base("Eureka Charger", 4, Engine.Civilization.Water)
        {
            AddSpellAbilities(new OneShotEffects.DrawCardsEffect(1));
        }
    }
}
