using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.CannotBeAttacked;

/// <summary>
/// This creature can't be attacked by civilization creatures.
/// </summary>
public sealed class ThisCreatureCannotBeAttackedByCivilizationCreaturesEffect
    : ContinuousEffect, ICannotBeAttackedEffect, IMultiCivilizationable
{
    public ThisCreatureCannotBeAttackedByCivilizationCreaturesEffect(
        ThisCreatureCannotBeAttackedByCivilizationCreaturesEffect effect)
            : base(effect)
    {
        Civilizations = [.. effect.Civilizations];
    }

    public ThisCreatureCannotBeAttackedByCivilizationCreaturesEffect(
        params Civilization[] civilizations) : base()
    {
        Civilizations = civilizations;
    }

    public Civilization[] Civilizations { get; }

    public bool Applies(ICreature attacker, ICreature targetOfAttack)
    {
        if (!IsSourceOfAbility(targetOfAttack)) return false;
        if (!attacker.HasCivilization(Civilizations)) return false;
        return true;
    }

    public override IContinuousEffect Copy()
    {
        return new ThisCreatureCannotBeAttackedByCivilizationCreaturesEffect(
            this);
    }
}
