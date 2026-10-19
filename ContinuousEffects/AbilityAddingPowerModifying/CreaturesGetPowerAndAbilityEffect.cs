using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAddingPowerModifying;

public sealed class CreaturesGetPowerAndAbilityEffect : UntilEndOfTurnEffect, IAbilityAddingEffect,
    IPowerModifyingEffect
{
    private readonly ICreature[] creatures;
    private readonly int power;
    private readonly IAbility ability;

    public CreaturesGetPowerAndAbilityEffect(
        int power, IAbility ability, params ICreature[] creatures)
    {
        this.power = power;
        this.ability = ability;
        this.creatures = creatures;
    }

    private CreaturesGetPowerAndAbilityEffect(
        CreaturesGetPowerAndAbilityEffect effect) : base(effect)
    {
        power = effect.power;
        ability = effect.ability.Copy();
        creatures = [.. effect.creatures.Select(x => x.Copy()).OfType<ICreature>()];
    }

    public void AddAbility(IGame game)
    {
        foreach (var creature in creatures)
        {
            creature.AddGrantedAbility(ability);
        }
    }

    public override IContinuousEffect Copy()
    {
        return new CreaturesGetPowerAndAbilityEffect(this);
    }

    public void ModifyPower(IGame game)
    {
        foreach (var creature in creatures)
        {
            creature.IncreasePower(power);
        }
    }
}
