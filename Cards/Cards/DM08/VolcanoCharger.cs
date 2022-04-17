namespace Cards.Cards.DM08
{
    class VolcanoCharger : Charger
    {
        public VolcanoCharger() : base("Volcano Charger", 4, Engine.Civilization.Fire)
        {
            AddSpellAbilities(new OneShotEffects.DestroyOnefYourOpponentsCreaturesThatHasMaxPowerEffect(2000));
        }
    }
}
