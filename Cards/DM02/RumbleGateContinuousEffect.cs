using ContinuousEffects;
using System;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace Cards.DM02;

public sealed class RumbleGateContinuousEffect : UntilEndOfTurnEffect, ICanAttackUntappedCreaturesEffect
{
    private readonly Guid _controller;

    public RumbleGateContinuousEffect(Guid controller) : base()
    {
        _controller = controller;
    }

    public RumbleGateContinuousEffect(RumbleGateContinuousEffect effect) : base(effect)
    {
        _controller = effect._controller;
    }

    public bool CanAttackUntappedCreature(ICreature attacker, ICreature targetOfAttack, IGame game)
    {
        return attacker.Owner.Id == _controller && game.CanAttackAtLeastOneCreature(attacker);
    }

    public override IContinuousEffect Copy()
    {
        return new RumbleGateContinuousEffect(this);
    }

    public override string ToString()
    {
        return "Each of your creatures in the battle zone that can attack creatures can attack untapped creatures this turn.";
    }
}
