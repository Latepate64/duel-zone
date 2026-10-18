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
        ThisCreatureGetsAbilitiesUntilTheEndOfTheTurnEffectFactory continuousEffectFactory
    ) : base("Aura Blast", 4, Civilization.Nature)
    {
        AddSpellAbilities(
            effectFactory.Create(
                new CreatureFilter(),
                continuousEffectFactory,
                powerAttackerAbilityFactory.Create(2000)
        ));
    }
}