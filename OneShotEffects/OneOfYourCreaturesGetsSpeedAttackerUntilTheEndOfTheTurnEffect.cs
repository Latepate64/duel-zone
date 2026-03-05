using ContinuousEffects;
using Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class OneOfYourCreaturesGetsSpeedAttackerUntilTheEndOfTheTurnEffect :
    OneOfYourCreaturesGetsAbilityUntilTheEndOfTheTurnEffect
{
    public OneOfYourCreaturesGetsSpeedAttackerUntilTheEndOfTheTurnEffect() : base(new StaticAbility(
        new ThisCreatureHasSpeedAttackerEffect()))
    {
    }

    public OneOfYourCreaturesGetsSpeedAttackerUntilTheEndOfTheTurnEffect(
        OneOfYourCreaturesGetsAbilityUntilTheEndOfTheTurnEffect effect) : base(effect)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new OneOfYourCreaturesGetsSpeedAttackerUntilTheEndOfTheTurnEffect(this);
    }
}
