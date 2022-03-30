using Common;

namespace Cards.Cards.DM08
{
    class MuscleCharger : Charger
    {
        public MuscleCharger() : base("Muscle Charger", 3, Civilization.Nature)
        {
            AddSpellAbilities(new OneShotEffects.EachOfYourCreaturesGetsPowerUntilTheEndOfTheTurnEffect(3000));
        }
    }
}
