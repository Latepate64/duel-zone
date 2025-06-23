using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class DiamondCutterContinuousEffect : UntilEndOfTurnEffect, IIgnoreCannotAttackPlayersEffects
{
    private readonly Guid _controller;

    public DiamondCutterContinuousEffect(Guid controller) : base()
    {
        _controller = controller;
    }

    public DiamondCutterContinuousEffect(DiamondCutterContinuousEffect effect) : base(effect)
    {
        _controller = effect._controller;
    }

    public bool IgnoreCannotAttackPlayersEffects(ICreature attacker, IGame game)
    {
        return attacker.Owner.Id == _controller;
    }

    public override IContinuousEffect Copy()
    {
        return new DiamondCutterContinuousEffect(this);
    }

    public override string ToString()
    {
        return "This turn, ignore any effects that would prevent your creatures from attacking your opponent.";
    }
}
