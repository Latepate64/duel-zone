namespace Cards.Cards.DM08
{
    class RootCharger : Charger
    {
        public RootCharger() : base("Root Charger", 3, Engine.Civilization.Nature)
        {
            AddSpellAbilities(new OneShotEffects.WheneverAnyOfYourCreaturesWouldBeDestroyedThisTurnPutItIntoYourManaZoneInsteadEffect());
        }
    }
}
