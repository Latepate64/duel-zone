using Interfaces;

namespace ContinuousEffects.AbilityAdding;

public class EachCreatureHasAbilitiesEffectFactory
{
    public EachCreatureHasAbilitiesEffect Create(ICardFilter filter, params IAbility[] abilities)
    {
        return new EachCreatureHasAbilitiesEffect(filter, abilities);
    }
}