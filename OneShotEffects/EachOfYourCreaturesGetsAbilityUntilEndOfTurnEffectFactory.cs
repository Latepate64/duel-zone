using Interfaces;
using Interfaces.ContinuousEffects;

namespace OneShotEffects;

public class EachOfYourCreaturesGetsAbilityUntilEndOfTurnEffectFactory
{
    public IOneShotEffect Create(
        ICardFilter filter,
        IContinuousEffectWithAbilitiesAndCreaturesFactory effectFactory,
        IDuration duration,
        params IAbility[] abilities)
    {
        return new EachOfYourCreaturesGetsAbilityUntilEndOfTurnEffect(
            filter, effectFactory, duration, abilities);
    }
}