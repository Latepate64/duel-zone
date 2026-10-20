using Interfaces;
using Interfaces.ContinuousEffects;

namespace OneShotEffects;

public class EachOfYourOpponentsCreaturesGetsAbilityEffectFactory
{
    public IOneShotEffect Create(
        ICardFilter filter,
        IContinuousEffectWithAbilitiesAndCreaturesFactory effectFactory,
        IDuration duration,
        params IAbility[] abilities)
    {
        return new EachOfYourCreaturesGetsAbilityEffect(filter, effectFactory, duration, abilities);
    }
}