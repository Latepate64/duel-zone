namespace Cards.DM08
{
    sealed class RootCharger : Charger
    {
        public RootCharger() : base("Root Charger", 3, Interfaces.Civilization.Nature)
        {
            AddSpellAbilities(new OneShotEffects.WheneverAnyOfYourCreaturesWouldBeDestroyedThisTurnPutItIntoYourManaZoneInsteadEffect());
        }
    }
}
