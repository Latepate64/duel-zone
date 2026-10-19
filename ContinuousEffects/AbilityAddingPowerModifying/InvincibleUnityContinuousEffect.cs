using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAddingPowerModifying;

public sealed class InvincibleUnityContinuousEffect : UntilEndOfTurnEffect, IAbilityAddingEffect,
    IPowerModifyingEffect
{
    private readonly ICreature[] creatures;
    private readonly int power;
    private readonly IAbility ability;

    public InvincibleUnityContinuousEffect(
        int power, IAbility ability, params ICreature[] creatures)
    {
        this.power = power;
        this.ability = ability;
        this.creatures = creatures;
    }

    private InvincibleUnityContinuousEffect(InvincibleUnityContinuousEffect effect) : base(effect)
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
        return new InvincibleUnityContinuousEffect(this);
    }

    public void ModifyPower(IGame game)
    {
        foreach (var creature in creatures)
        {
            creature.IncreasePower(power);
        }
    }
}
