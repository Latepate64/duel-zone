using Interfaces;

namespace ContinuousEffects.AbilityAdding;

public class EachCreatureHasAbilityEffectFactory
{
    public EachCreatureHasAbilityEffect Create(ICardFilter filter, IAbility ability)
    {
        return new EachCreatureHasAbilityEffect(filter, ability);
    }
}