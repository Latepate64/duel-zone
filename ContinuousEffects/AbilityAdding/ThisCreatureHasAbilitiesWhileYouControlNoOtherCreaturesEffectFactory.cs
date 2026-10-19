using Interfaces;

namespace ContinuousEffects.AbilityAdding;

public class ThisCreatureHasAbilitiesWhileYouControlNoOtherCreaturesEffectFactory
{
    public ThisCreatureHasAbilitiesWhileYouControlNoOtherCreaturesEffect Create(
        IStaticAbilityWithIntegerFactory abilityWithIntegerFactory,
        IStaticAbilityFactory abilityFactory,
        int power)
    {
        return new ThisCreatureHasAbilitiesWhileYouControlNoOtherCreaturesEffect(
            abilityWithIntegerFactory,
            abilityFactory,
            power
        );
    }
}