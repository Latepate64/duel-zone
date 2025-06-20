using Abilities.Static;
using Engine.Abilities;

namespace Cards.OneShotEffects;

public class OneOfYourCreaturesGetsSlayerUntilTheEndOfTheTurnEffect :
    OneOfYourCreaturesGetsAbilityUntilTheEndOfTheTurnEffect
{
    public OneOfYourCreaturesGetsSlayerUntilTheEndOfTheTurnEffect() : base(new SlayerAbility())
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
