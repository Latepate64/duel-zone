using Abilities;
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
                new RaceAffectingContinuousEffectAddingEffect(
                new SilvermoonTrailblazerContinuousEffectFactory(),
                new UntilEndOfThisTurnDuration()
            )));
    }
}
