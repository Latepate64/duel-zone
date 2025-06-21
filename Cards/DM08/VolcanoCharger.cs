namespace Cards.DM08
{
    class VolcanoCharger : Charger
    {
        public VolcanoCharger() : base("Volcano Charger", 4, Interfaces.Civilization.Fire)
        {
            AddSpellAbilities(new OneShotEffects.DestroyOnefYourOpponentsCreaturesThatHasMaxPowerEffect(2000));
        }
    }
}
