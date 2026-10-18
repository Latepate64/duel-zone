using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAddingPowerModifying;

public sealed class ThisCreatureGetsPowerAndAbilityEffect : ContinuousEffect,
    IPowerModifyingEffect, IAbilityAddingEffect
{
    private readonly int power;
    private readonly IAbility ability;
    private readonly ICondition? condition;

    public ThisCreatureGetsPowerAndAbilityEffect(
        int power, IAbility ability, ICondition? condition = null)
    {
        this.power = power;
        this.ability = ability;
        this.condition = condition;
    }

    private ThisCreatureGetsPowerAndAbilityEffect(
        ThisCreatureGetsPowerAndAbilityEffect effect) : base(effect)
    {
        power = effect.power;
        ability = effect.ability.Copy();
        condition = effect.condition;
    }

    public void AddAbility(IGame game)
    {
        if (condition == null || condition.IsMet(Applier))
        {
            Source.AddGrantedAbility(ability);
        }
    }

    public override IContinuousEffect Copy()
    {
        return new ThisCreatureGetsPowerAndAbilityEffect(this);
    }

    public void ModifyPower(IGame game)
    {
        if (condition == null || condition.IsMet(Applier))
        {
            ((ICreature)Source!).IncreasePower(power);
        }
    }
}
