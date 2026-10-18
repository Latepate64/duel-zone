using Abilities.Static;
using CardFilters;
using ContinuousEffects.AbilityAdding;
using Interfaces;
using OneShotEffects;

namespace Cards.DM01;

sealed class AuraBlast : Spell
{
    public AuraBlast(
        PowerAttackerAbilityFactory powerAttackerAbilityFactory,
        EachOfYourCreaturesGetsAbilityUntilEndOfTurnEffectFactory effectFactory,
        ThisCreatureGetsAbilityUntilTheEndOfTheTurnEffectFactory continuousEffectFactory
    ) : base("Aura Blast", 4, Civilization.Nature)
    {
        AddSpellAbilities(
            effectFactory.Create(
                powerAttackerAbilityFactory.Create(2000),
                new CreatureFilter(),
                continuousEffectFactory
        ));
    }
}