using ContinuousEffects;
using Engine.Abilities;

namespace OneShotEffects;

public class OneOfYourCreaturesGetsSpeedAttackerUntilTheEndOfTheTurnEffect :
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
