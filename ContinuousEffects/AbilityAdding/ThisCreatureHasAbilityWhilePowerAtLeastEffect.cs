using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAdding;

public sealed class ThisCreatureHasAbilityWhilePowerAtLeastEffect : ContinuousEffect,
    IAbilityAddingEffect
{
    private readonly int power;
    private readonly IAbility ability;

    internal ThisCreatureHasAbilityWhilePowerAtLeastEffect(int power, IAbility ability) : base()
    {
        this.power = power;
        this.ability = ability;
    }

    private ThisCreatureHasAbilityWhilePowerAtLeastEffect(
        ThisCreatureHasAbilityWhilePowerAtLeastEffect effect) : base(effect)
    {
        power = effect.power;
        ability = effect.ability.Copy();
    }

    public void AddAbility(IGame game)
    {
        var creature = (ICreature)Source!;
        if (creature.Power >= power)
        {
            creature.AddGrantedAbility(ability);
        }
    }

    public override IContinuousEffect Copy()
    {
        return new ThisCreatureHasAbilityWhilePowerAtLeastEffect(this);
    }
}
