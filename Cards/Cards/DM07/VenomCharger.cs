namespace Cards.Cards.DM07
{
    class VenomCharger : Charger
    {
        public VenomCharger() : base("Venom Charger", 3, Engine.Civilization.Darkness)
        {
            AddSpellAbilities(new OneShotEffects.OneOfYourCreaturesGetsAbilityUntilTheEndOfTheTurnEffect(new StaticAbilities.SlayerAbility()));
        }
    }
}
