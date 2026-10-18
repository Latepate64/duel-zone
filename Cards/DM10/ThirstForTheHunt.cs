using Abilities.Static;
using CardFilters;
using ContinuousEffects.AbilityAdding;
using Interfaces;
using OneShotEffects;

namespace Cards.DM10;

sealed class ThirstForTheHunt : Spell
{
    public ThirstForTheHunt(
        PowerAttackerAbilityFactory powerAttackerAbilityFactory,
        EachOfYourCreaturesGetsAbilityUntilEndOfTurnEffectFactory effectFactory,
        ThisCreatureGetsAbilityUntilTheEndOfTheTurnEffectFactory continuousEffectFactory) : base(
        "Thirst for the Hunt", 1, Civilization.Nature)
    {
        AddSpellAbilities(
            effectFactory.Create(
                powerAttackerAbilityFactory.Create(1000),
                new CreatureFilter(),
                continuousEffectFactory
        ));
    }
}