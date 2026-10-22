using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAdding;

public sealed class CreaturesGetAbilitiesEffect : AddAbilitiesUntilEndOfTurnEffect
{
    internal CreaturesGetAbilitiesEffect(
        IAbility[] abilities, params ICreature[] creatures) : base(abilities, creatures)
    {
    }

    private CreaturesGetAbilitiesEffect(CreaturesGetAbilitiesEffect effect) : base(effect)
    {
    }

    public override IContinuousEffect Copy()
    {
        return new CreaturesGetAbilitiesEffect(this);
    }
}
