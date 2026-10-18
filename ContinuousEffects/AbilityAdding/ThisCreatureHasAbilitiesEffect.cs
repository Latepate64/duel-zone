using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAdding;

public sealed class ThisCreatureHasAbilitiesEffect : ContinuousEffect, IAbilityAddingEffect
{
    private readonly IAbility[] abilities;
    private readonly ICondition condition;

    public ThisCreatureHasAbilitiesEffect(ICondition condition, params IAbility[] abilities)
    {
        this.condition = condition;
        this.abilities = abilities;
    }

    public ThisCreatureHasAbilitiesEffect(ThisCreatureHasAbilitiesEffect effect) : base(effect)
    {
        condition = effect.condition;
        abilities = [..effect.abilities.Select(x => x.Copy())];
    }

    public void AddAbility(IGame game)
    {
        var creature = (ICreature)Source!;
        if (condition.IsMet(creature))
        {
            creature.AddGrantedAbility(abilities);
        }
    }

    public override IContinuousEffect Copy()
    {
        return new ThisCreatureHasAbilitiesEffect(this);
    }
}
