namespace Cards.DM07
{
    class EnergyCharger : Charger
    {
        public EnergyCharger() : base("Energy Charger", 3, Interfaces.Civilization.Fire)
        {
            AddSpellAbilities(new OneShotEffects.OneOfYourCreaturesGetsPowerUntilTheEndOfTheTurnEffect(2000));
        }
    }
}
