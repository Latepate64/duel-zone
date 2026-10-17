using Abilities;
using Abilities.Static;
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
        ThisCreatureGetsAbilityUntilTheEndOfTheTurnEffectFactory continuousEffectFactory,
        TapAbilityFactory tapAbilityFactory,
        ThisCreatureCanAttackUntappedCreaturesEffectFactory untappedFactory
    ) : base("Armored Transport Galiacruse", 6, 5000, Race.Armorloid, Civilization.Fire)
    {
        AddAbilities(
            tapAbilityFactory.Create(
                oneShotEffectFactory.Create(
                    abilityFactory.Create(untappedFactory.Create()),
                    creatureFilterFactory.Create(Civilization.Fire),
                    continuousEffectFactory
                )));
    }
}
