using Interfaces;
using Interfaces.ContinuousEffects;

namespace OneShotEffects;

public class EachOfYourCreaturesGetsAbilityUntilEndOfTurnEffectFactory
{
    public IOneShotEffect Create(
        ICardFilter filter,
        IContinuousEffectWithAbilitiesAndCreaturesFactory effectFactory,
        params IAbility[] abilities)
    {
        return new EachOfYourCreaturesGetsAbilityUntilEndOfTurnEffect(
            filter, effectFactory, abilities);
    }
}