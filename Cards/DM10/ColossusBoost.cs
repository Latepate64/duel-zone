using CardFilters;
using ContinuousEffects.AbilityAddingPowerModifying;
using Interfaces;
using OneShotEffects;

namespace Cards.DM10;

sealed class ColossusBoost : Spell
{
    public ColossusBoost() : base("Colossus Boost", 1, Civilization.Fire)
    {
        AddSpellAbilities(
            new AddChosenCreatureAffectingNumberEffect(
                4000,
                new CreatureFilter(),
                new ThisCreatureGetsPowerUntilTheEndOfTheTurnEffectFactory(),
                new UntilEndOfThisTurnDuration()));
    }
}