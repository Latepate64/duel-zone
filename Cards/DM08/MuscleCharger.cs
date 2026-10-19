using ContinuousEffects.AbilityAddingPowerModifying;
using Interfaces;
using OneShotEffects;

namespace Cards.DM08;

sealed class MuscleCharger : Charger
{
    public MuscleCharger() : base("Muscle Charger", 3, Civilization.Nature)
    {
        AddSpellAbilities(
            new CreatureIntegerAffectingContinuousEffectAddingEffect(
            3000,
            new ThisCreatureGetsPowerUntilTheEndOfTheTurnEffectFactory(),
            new UntilEndOfThisTurnDuration()));
    }
}