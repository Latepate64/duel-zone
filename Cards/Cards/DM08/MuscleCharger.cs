namespace Cards.Cards.DM08
{
    class MuscleCharger : Charger
    {
        public MuscleCharger() : base("Muscle Charger", 3, Engine.Civilization.Nature)
        {
            AddSpellAbilities(new OneShotEffects.EachOfYourCreaturesGetsPowerUntilTheEndOfTheTurnEffect(3000));
        }
    }
}
