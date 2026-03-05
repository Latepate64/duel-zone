namespace Cards.DM07
{
    sealed class LightningCharger : Charger
    {
        public LightningCharger() : base("Lightning Charger", 4, Interfaces.Civilization.Light)
        {
            AddSpellAbilities(new OneShotEffects.ChooseOneOfYourOpponentsCreaturesInTheBattleZoneAndTapItEffect());
        }
    }
}
