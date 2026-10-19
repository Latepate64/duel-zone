using Abilities;
using CardFilters;
using ContinuousEffects.Unblockable;
using Interfaces;
using OneShotEffects;

namespace Cards.DM09;

public sealed class SilvermoonTrailblazer : Creature
{
    public SilvermoonTrailblazer(RaceCreatureFilterFactory raceCreatureFilterFactory) : base(
        "Silvermoon Trailblazer", 4, 3000,
        Race.BeastFolk, Civilization.Nature)
    {
        AddAbilities(
            new TapAbility(
                new AddContinuousEffectWithRaceAndFilterEffect(
                    new CreaturesCannotBeBlockedEffectFactory(),
                    new UntilEndOfThisTurnDuration(),
                    new MaxPowerFilter(3000),
                    raceCreatureFilterFactory
            )));
    }
}
