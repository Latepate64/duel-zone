using Common;

namespace Cards.StaticAbilities
{
    class ThisCreatureGetsPowerForEachCivilizationCreatureYourOpponentControlsAbility : Engine.Abilities.StaticAbility
    {
        public ThisCreatureGetsPowerForEachCivilizationCreatureYourOpponentControlsAbility(int power, params Civilization[] civilizations) : base(new ContinuousEffects.ThisCreatureGetsPowerForEachCivilizationCreatureYourOpponentControlsEffect(power, civilizations))
        {
        }
    }
}