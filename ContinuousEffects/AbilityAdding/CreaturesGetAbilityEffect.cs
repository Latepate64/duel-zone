using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAdding;

public sealed class CreaturesGetAbilityEffect : AddAbilitiesUntilEndOfTurnEffect
{
    internal CreaturesGetAbilityEffect(
        IAbility ability, params ICreature[] creatures) : base(ability, creatures)
    {
    }

    private CreaturesGetAbilityEffect(CreaturesGetAbilityEffect effect) : base(effect)
    {
    }

    public override IContinuousEffect Copy()
    {
        return new CreaturesGetAbilityEffect(this);
    }
}
