using Abilities;
using StaticAbilities;
using CardFilters;
using ContinuousEffects.AbilityAdding;
using ContinuousEffects.Unblockable;
using Interfaces;
using OneShotEffects;

namespace Cards.DM07;

public sealed class KingBenthos : Creature
{
    public KingBenthos(
        EachOfYourCreaturesGetsAbilityEffectFactory oneShotEffectFactory,
        StaticAbilityFactory abilityFactory,
        CivilizationCreatureFilterFactory creatureFilterFactory,
        ThisCreatureGetsAbilitiesUntilTheEndOfTheTurnEffectFactory continuousEffectFactory,
        TapAbilityFactory tapAbilityFactory,
        ThisCreatureCannotBeBlockedEffectFactory cannotBeBlockedEffectFactory,
        DoubleBreakerAbilityFactory doubleBreakerAbilityFactory
    ) : base("King Benthos", 8, 6000, Race.Leviathan, Civilization.Water)
    {
        AddAbilities(doubleBreakerAbilityFactory.Create());
        AddAbilities(
            tapAbilityFactory.Create(
                oneShotEffectFactory.Create(
                    creatureFilterFactory.Create(Civilization.Water),
                    continuousEffectFactory,
                    new UntilEndOfThisTurnDuration(),
                    abilityFactory.Create(cannotBeBlockedEffectFactory.Create())
        )));
    }
}
