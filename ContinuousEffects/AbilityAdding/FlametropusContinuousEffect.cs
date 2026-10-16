using Abilities.Static;
using ContinuousEffects.PowerModifying;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAdding;

/// <summary>
/// This creature gets "power attacker +x" and "double breaker" until the end of
/// the turn.
/// </summary>
public sealed class FlametropusContinuousEffect : AddAbilitiesUntilEndOfTurnEffect
{
    public FlametropusContinuousEffect(FlametropusContinuousEffect effect) : base(effect)
    {
    }

    public FlametropusContinuousEffect(ICard card, int power) : base(
        card, new StaticAbility(new PowerAttackerEffect(power)),
        new DoubleBreakerAbility())
    {
    }

    public override IContinuousEffect Copy()
    {
        return new FlametropusContinuousEffect(this);
    }
}
