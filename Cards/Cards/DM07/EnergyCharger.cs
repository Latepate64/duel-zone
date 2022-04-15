namespace Cards.Cards.DM07
{
    class EnergyCharger : Charger
    {
        public EnergyCharger() : base("Energy Charger", 3, Engine.Civilization.Fire)
        {
            AddSpellAbilities(new OneShotEffects.OneOfYourCreaturesGetsUntilTheEndOfTheTurnEffect(2000));
        }
    }
}
