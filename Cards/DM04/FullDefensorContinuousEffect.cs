using ContinuousEffects;
using Engine;
using Engine.Abilities;
using Engine.GameEvents;
using Engine.Steps;
using Interfaces;
using Interfaces.ContinuousEffects;
using System;
using System.Collections.Generic;

namespace Cards.DM04;

public sealed class FullDefensorContinuousEffect : AbilityAddingEffect, IExpirable
{
    private readonly Guid _player;
    private readonly ICard[] _cards;

    public FullDefensorContinuousEffect(FullDefensorContinuousEffect effect) : base(effect)
    {
        _player = effect._player;
        _cards = effect._cards;
    }

    public FullDefensorContinuousEffect(Guid player, params ICard[] cards) : base(
        new StaticAbility(new ThisCreatureHasBlockerEffect()))
    {
        _player = player;
        _cards = cards;
    }

    public override IContinuousEffect Copy()
    {
        return new FullDefensorContinuousEffect(this);
    }

    public bool ShouldExpire(IGameEvent gameEvent, IGame game)
    {
        return gameEvent is PhaseBegunEvent phase && phase.Phase.Type == PhaseOrStep.StartOfTurn
            && phase.Turn.ActivePlayer.Id == _player;
    }

    public override string ToString()
    {
        return "Until the start of your next turn, each of your creatures in the battle zone has \"Blocker\".";
    }

    protected override IEnumerable<ICard> GetAffectedCards(IGame game)
    {
        return _cards;
    }
}
