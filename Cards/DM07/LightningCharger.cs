namespace Cards.DM07
{
    class LightningCharger : Charger
    {
        public LightningCharger() : base("Lightning Charger", 4, Interfaces.Civilization.Light)
        {
            AddSpellAbilities(new OneShotEffects.ChooseOneOfYourOpponentsCreaturesInTheBattleZoneAndTapItEffect());
        }
    }
}
