namespace Cards.Cards.DM07
{
    class LightningCharger : Charger
    {
        public LightningCharger() : base("Lightning Charger", 4, Engine.Civilization.Light)
        {
            AddSpellAbilities(new OneShotEffects.ChooseOneOfYourOpponentsCreaturesInTheBattleZoneAndTapItEffect());
        }
    }
}
