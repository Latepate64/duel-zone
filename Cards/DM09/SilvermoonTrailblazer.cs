using Abilities;
using CardFilters;
using ContinuousEffects;
using Interfaces;
using OneShotEffects;

namespace Cards.DM09;

public sealed class SilvermoonTrailblazer : Creature
{
    public SilvermoonTrailblazer() : base("Silvermoon Trailblazer", 4, 3000,
        Race.BeastFolk, Civilization.Nature)
    {
        AddAbilities(
            new TapAbility(
                new AddContinuousEffectWithRaceAndFilterEffect(
                    new RaceCreaturesCannotBeBlockedEffectFactory(),
                    new UntilEndOfThisTurnDuration(),
                    new MaxPowerFilter(3000)
            )));
    }
}
