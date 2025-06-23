using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class ChaosStrikeContinousEffect : UntilEndOfTurnEffect, ICanBeAttackedAsThoughTappedEffect
{
    private readonly Guid _targetOfAttack;

    public ChaosStrikeContinousEffect(Guid targetOfAttack) : base()
    {
        _targetOfAttack = targetOfAttack;
    }

    public ChaosStrikeContinousEffect(ChaosStrikeContinousEffect effect) : base(effect)
    {
        _targetOfAttack = effect._targetOfAttack;
    }

    public bool Applies(ICard targetOfAttack)
    {
        return targetOfAttack.Id == _targetOfAttack;
    }

    public override IContinuousEffect Copy()
    {
        return new ChaosStrikeContinousEffect(this);
    }

    public override string ToString()
    {
        return "Your opponent's creatures can attack this creature as though this creature was tapped.";
    }
}
