using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAdding;

public sealed class ThisCreatureHasEitherAbilityWhilePowerAtLeastEitherEffect : ContinuousEffect,
    IAbilityAddingEffect
{
    private readonly int lowerGap;
    private readonly IAbility lowerAbility;
    private readonly int higherGap;
    private readonly IAbility higherAbility;

    internal ThisCreatureHasEitherAbilityWhilePowerAtLeastEitherEffect(
        int lowerGap, IAbility lowerAbility, int higherGap, IAbility higherAbility) : base()
    {
        this.lowerGap = lowerGap;
        this.lowerAbility = lowerAbility;
        this.higherGap = higherGap;
        this.higherAbility = higherAbility;
    }

    private ThisCreatureHasEitherAbilityWhilePowerAtLeastEitherEffect(
        ThisCreatureHasEitherAbilityWhilePowerAtLeastEitherEffect effect) : base(effect)
    {
        lowerGap = effect.lowerGap;
        lowerAbility = effect.lowerAbility.Copy();
        higherGap = effect.higherGap;
        higherAbility = effect.higherAbility.Copy();
    }

    public void AddAbility(IGame game)
    {
        var creature = (ICreature)Source!;
        if (creature.Power >= higherGap)
        {
            game.AddAbility(creature, higherAbility);
        }
        else if (creature.Power >= lowerGap)
        {
            game.AddAbility(creature, lowerAbility);
        }
    }

    public override IContinuousEffect Copy()
    {
        return new ThisCreatureHasEitherAbilityWhilePowerAtLeastEitherEffect(this);
    }
}
