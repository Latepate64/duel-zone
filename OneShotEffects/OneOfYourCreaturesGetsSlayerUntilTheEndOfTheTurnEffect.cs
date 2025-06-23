using ContinuousEffects;
using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class OneOfYourCreaturesGetsSlayerUntilTheEndOfTheTurnEffect :
    OneOfYourCreaturesGetsAbilityUntilTheEndOfTheTurnEffect
{
    public OneOfYourCreaturesGetsSlayerUntilTheEndOfTheTurnEffect() : base(new StaticAbility(
        new ThisCreatureHasSlayerEffect()))
    {
    }

    public OneOfYourCreaturesGetsSlayerUntilTheEndOfTheTurnEffect(
        OneOfYourCreaturesGetsAbilityUntilTheEndOfTheTurnEffect effect) : base(effect)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new OneOfYourCreaturesGetsSlayerUntilTheEndOfTheTurnEffect(this);
    }
}
