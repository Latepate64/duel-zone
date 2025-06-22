using ContinuousEffects;
using Engine;
using Engine.Abilities;
using Engine.GameEvents;
using Engine.Steps;
using Interfaces;
using Interfaces.ContinuousEffects;
using System;
using System.Collections.Generic;

namespace Cards.DM09;

public class UnifiedResistanceContinuousEffect : AbilityAddingEffect, IExpirable
{
    private readonly Guid _player;
    private readonly ICard[] _cards;

    public UnifiedResistanceContinuousEffect(UnifiedResistanceContinuousEffect effect) : base(effect)
    {
        _player = effect._player;
        _cards = effect._cards;
    }

    public UnifiedResistanceContinuousEffect(Guid player, params ICard[] cards) : base(
        new StaticAbility(new ThisCreatureHasBlockerEffect()))
    {
        _player = player;
        _cards = cards;
    }

    public override IContinuousEffect Copy()
    {
        return new UnifiedResistanceContinuousEffect(this);
    }

    public bool ShouldExpire(IGameEvent gameEvent, IGame game)
    {
        return gameEvent is PhaseBegunEvent phase && phase.Phase.Type == PhaseOrStep.StartOfTurn
            && phase.Turn.ActivePlayer.Id == _player;
    }

    public override string ToString()
    {
        return $"Until the start of your next turn, {_cards} have \"Blocker\".";
    }

    protected override IEnumerable<ICard> GetAffectedCards(IGame game)
    {
        return _cards;
    }
}
