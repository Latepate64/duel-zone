using Engine;
using Engine.GameEvents;
using Engine.Steps;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class MiraculousTruceContinuousEffect : ContinuousEffect, ICannotAttackPlayersEffect, IExpirable
{
    private readonly Civilization _civilization;
    private readonly IPlayer _player;

    public MiraculousTruceContinuousEffect()
    {
    }

    public MiraculousTruceContinuousEffect(Civilization civilization, IPlayer player)
    {
        _civilization = civilization;
        _player = player;
    }

    public MiraculousTruceContinuousEffect(MiraculousTruceContinuousEffect effect) : base(effect)
    {
        _civilization = effect._civilization;
        _player = effect._player;
    }

    public bool CannotAttackPlayers(ICreature attacker, IGame game)
    {
        return attacker.HasCivilization(_civilization);
    }

    public override IContinuousEffect Copy()
    {
        return new MiraculousTruceContinuousEffect(this);
    }

    public bool ShouldExpire(IGameEvent gameEvent, IGame game)
    {
        return gameEvent is PhaseBegunEvent phase && phase.Phase.Type == PhaseOrStep.StartOfTurn
            && phase.Turn.ActivePlayer == _player;
    }

    public override string ToString()
    {
        return $"Until the start of your next turn, {_civilization} creatures can't attack you.";
    }
}
