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
        EachOfYourCreaturesGetsAbilityEffectFactory oneShotEffectFactory,
        StaticAbilityFactory abilityFactory,
        CivilizationCreatureFilterFactory creatureFilterFactory,
        CreaturesGetAbilitiesEffectFactory continuousEffectFactory,
        TapAbilityFactory tapAbilityFactory
    ) : base("Armored Transport Galiacruse", 6, 5000, Race.Armorloid, Civilization.Fire)
    {
        AddAbilities(
            tapAbilityFactory.Create(
                oneShotEffectFactory.Create(
                    creatureFilterFactory.Create(Civilization.Fire),
                    continuousEffectFactory,
                    new UntilEndOfThisTurnDuration(),
                    abilityFactory.Create(
                        new ThisCreatureCanAttackUntappedCreaturesEffect(new CreatureFilter()))
                )));
    }
}
