using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAddingPowerModifying;

public sealed class ThisCreatureGetsPowerAndAbilityWhileYouHaveNoShieldsEffect : ContinuousEffect,
    IPowerModifyingEffect, IAbilityAddingEffect
{
    private readonly int power;
    private readonly IAbility ability;

    public ThisCreatureGetsPowerAndAbilityWhileYouHaveNoShieldsEffect(int power, IAbility ability)
    {
        this.power = power;
        this.ability = ability;
    }

    private ThisCreatureGetsPowerAndAbilityWhileYouHaveNoShieldsEffect(
        ThisCreatureGetsPowerAndAbilityWhileYouHaveNoShieldsEffect effect) : base(effect)
    {
        power = effect.power;
        ability = effect.ability.Copy();
    }

    public void AddAbility(IGame game)
    {
        if (!Controller.ShieldZone.HasCards)
        {
            Source.AddGrantedAbility(ability);
        }
    }

    public override IContinuousEffect Copy()
    {
        return new ThisCreatureGetsPowerAndAbilityWhileYouHaveNoShieldsEffect(this);
    }

    public void ModifyPower(IGame game)
    {
        if (!Controller.ShieldZone.HasCards)
        {
            ((ICreature)Source!).IncreasePower(power);
        }
    }
}
