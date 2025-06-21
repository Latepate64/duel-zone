namespace Cards.DM08
{
    class RootCharger : Charger
    {
        public RootCharger() : base("Root Charger", 3, Interfaces.Civilization.Nature)
        {
            AddSpellAbilities(new OneShotEffects.WheneverAnyOfYourCreaturesWouldBeDestroyedThisTurnPutItIntoYourManaZoneInsteadEffect());
        }
    }
}
