using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAdding;

public class ThatCreatureHasAbilityEffectFactory : IContinuousEffectWithAbilityFactory
{
    public IContinuousEffect Create(IAbility ability, params ICreature[] creatures)
    {
        return new ThatCreatureHasAbilityEffect(creatures.Single(), ability);
    }
}