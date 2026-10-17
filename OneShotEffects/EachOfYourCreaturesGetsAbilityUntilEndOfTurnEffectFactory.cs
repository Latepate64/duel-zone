using Interfaces;

namespace OneShotEffects;

public class EachOfYourCreaturesGetsAbilityUntilEndOfTurnEffectFactory
{
    public IOneShotEffect Create(
        IAbility ability,
        ICardFilter filter,
        IAbilityAddingContinuousEffectFactory effectFactory)
    {
        return new EachOfYourCreaturesGetsAbilityUntilEndOfTurnEffect(
            ability, filter, effectFactory);
    }
}