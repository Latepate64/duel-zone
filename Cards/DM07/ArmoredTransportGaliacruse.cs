using Abilities;
using StaticAbilities;
using CardFilters;
using ContinuousEffects.AbilityAdding;
using ContinuousEffects.CanAttackUntappedCreatures;
using Interfaces;
using OneShotEffects;

namespace Cards.DM07;

public sealed class ArmoredTransportGaliacruse : Creature
{
    public ArmoredTransportGaliacruse(
        EachOfYourCreaturesGetsAbilityUntilEndOfTurnEffectFactory oneShotEffectFactory,
        StaticAbilityFactory abilityFactory,
        CivilizationCreatureFilterFactory creatureFilterFactory,
        ThisCreatureGetsAbilitiesUntilTheEndOfTheTurnEffectFactory continuousEffectFactory,
        TapAbilityFactory tapAbilityFactory,
        ThisCreatureCanAttackUntappedCreaturesEffectFactory untappedFactory
    ) : base("Armored Transport Galiacruse", 6, 5000, Race.Armorloid, Civilization.Fire)
    {
        AddAbilities(
            tapAbilityFactory.Create(
                oneShotEffectFactory.Create(
                    creatureFilterFactory.Create(Civilization.Fire),
                    continuousEffectFactory,
                    new UntilEndOfThisTurnDuration(),
                    abilityFactory.Create(untappedFactory.Create())
                )));
    }
}
