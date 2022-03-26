namespace Cards.Cards.DM08
{
    class VolcanoCharger : Charger
    {
        public VolcanoCharger() : base("Volcano Charger", 4, Common.Civilization.Fire)
        {
            AddSpellAbilities(new OneShotEffects.DestroyOnefYourOpponentsCreaturesThatHasMaxPowerEffect(2000));
        }
    }
}
