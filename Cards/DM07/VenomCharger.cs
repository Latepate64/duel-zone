namespace Cards.DM07
{
    sealed class VenomCharger : Charger
    {
        public VenomCharger() : base("Venom Charger", 3, Interfaces.Civilization.Darkness)
        {
            AddSpellAbilities(new OneShotEffects.OneOfYourCreaturesGetsSlayerUntilTheEndOfTheTurnEffect());
        }
    }
}
