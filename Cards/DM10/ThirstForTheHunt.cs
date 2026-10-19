using StaticAbilities;
using CardFilters;
using ContinuousEffects.AbilityAdding;
using Interfaces;
using OneShotEffects;

namespace Cards.DM10;

sealed class ThirstForTheHunt : Spell
{
    public ThirstForTheHunt(
        PowerAttackerAbilityFactory powerAttackerAbilityFactory,
        EachOfYourCreaturesGetsAbilityEffectFactory effectFactory,
        ThisCreatureGetsAbilitiesUntilTheEndOfTheTurnEffectFactory continuousEffectFactory) : base(
        "Thirst for the Hunt", 1, Civilization.Nature)
    {
        AddSpellAbilities(
            effectFactory.Create(
                new CreatureFilter(),
                continuousEffectFactory,
                new UntilEndOfThisTurnDuration(),
                powerAttackerAbilityFactory.Create(1000)
        ));
    }
}