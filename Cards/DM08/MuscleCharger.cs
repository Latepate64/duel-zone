namespace Cards.DM08
{
    sealed class MuscleCharger : Charger
    {
        public MuscleCharger() : base("Muscle Charger", 3, Interfaces.Civilization.Nature)
        {
            AddSpellAbilities(new OneShotEffects.EachOfYourCreaturesGetsPowerUntilTheEndOfTheTurnEffect(3000));
        }
    }
}
