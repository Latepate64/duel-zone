namespace Cards.DM07
{
    class VenomCharger : Charger
    {
        public VenomCharger() : base("Venom Charger", 3, Interfaces.Civilization.Darkness)
        {
            AddSpellAbilities(new OneShotEffects.OneOfYourCreaturesGetsSlayerUntilTheEndOfTheTurnEffect());
        }
    }
}
