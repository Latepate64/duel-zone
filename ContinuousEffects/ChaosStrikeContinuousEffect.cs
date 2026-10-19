using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

/// <summary>
/// Your opponent's creatures can attack this creature as though this creature
/// was tapped.
/// </summary>
public sealed class ChaosStrikeContinuousEffect : UntilEndOfTurnEffect,
    ICanBeAttackedAsThoughTappedEffect
{
    private readonly ICreature targetOfAttack;

    public ChaosStrikeContinuousEffect(ICreature targetOfAttack) : base()
    {
        this.targetOfAttack = targetOfAttack;
    }

    public ChaosStrikeContinuousEffect(
        ChaosStrikeContinuousEffect effect) : base(effect)
    {
        targetOfAttack = effect.targetOfAttack;
    }

    public bool Applies(ICreature targetOfAttack)
    {
        return this.targetOfAttack.Equals(targetOfAttack);
    }

    public override IContinuousEffect Copy()
    {
        return new ChaosStrikeContinuousEffect(this);
    }
}
