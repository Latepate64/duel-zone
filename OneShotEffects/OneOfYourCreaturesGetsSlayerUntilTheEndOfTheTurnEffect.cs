using Abilities.Static;
using Interfaces;

namespace OneShotEffects;

public sealed class OneOfYourCreaturesGetsSlayerUntilTheEndOfTheTurnEffect :
    OneOfYourCreaturesGetsAbilityUntilTheEndOfTheTurnEffect
{
    public OneOfYourCreaturesGetsSlayerUntilTheEndOfTheTurnEffect() : base(
        new SlayerAbility())
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
