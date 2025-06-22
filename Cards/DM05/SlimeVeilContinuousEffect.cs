using ContinuousEffects;
using Engine;
using Engine.GameEvents;
using Engine.Steps;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace Cards.DM05;

public sealed class SlimeVeilContinuousEffect : ContinuousEffect, IAttacksIfAbleEffect, IExpirable
{
    private readonly IPlayer _player;

    public SlimeVeilContinuousEffect(IPlayer player)
    {
        _player = player;
    }

    public SlimeVeilContinuousEffect(SlimeVeilContinuousEffect effect) : base(effect)
    {
        _player = effect._player;
    }

    public bool AttacksIfAble(ICreature creature, IGame game)
    {
        return creature.Owner == _player;
    }

    public override IContinuousEffect Copy()
    {
        return new SlimeVeilContinuousEffect(this);
    }

    public bool ShouldExpire(IGameEvent gameEvent, IGame game)
    {
        return gameEvent is PhaseBegunEvent phase && phase.Phase.Type == PhaseOrStep.EndOfTurn
            && phase.Turn.ActivePlayer == _player;
    }

    public override string ToString()
    {
        return $"During {_player}'s next turn, each of his creatures attacks if able.";
    }
}
