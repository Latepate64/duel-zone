using Abilities.Static;
using Engine.Abilities;

namespace Cards.OneShotEffects;

public class OneOfYourCreaturesGetsSpeedAttackerUntilTheEndOfTheTurnEffect :
    OneOfYourCreaturesGetsAbilityUntilTheEndOfTheTurnEffect
{
    public OneOfYourCreaturesGetsSpeedAttackerUntilTheEndOfTheTurnEffect() : base(new SpeedAttackerAbility())
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
