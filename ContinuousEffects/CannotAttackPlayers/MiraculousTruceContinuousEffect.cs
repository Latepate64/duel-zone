using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.CannotAttackPlayers;

public sealed class MiraculousTruceContinuousEffect : ContinuousEffect, ICannotAttackPlayersEffect, IExpirable
{
    private readonly Civilization _civilization;

    public MiraculousTruceContinuousEffect()
    {
    }

    public MiraculousTruceContinuousEffect(Civilization civilization)
    {
        _civilization = civilization;
    }

    public MiraculousTruceContinuousEffect(MiraculousTruceContinuousEffect effect) : base(effect)
    {
        _civilization = effect._civilization;
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
        throw new NotImplementedException();
        // return gameEvent is PhaseBegunEvent phase && phase.Phase.Type == PhaseOrStep.StartOfTurn
        //     && phase.Turn.ActivePlayer == _player;
    }

    public override string ToString()
    {
        return $"Until the start of your next turn, {_civilization} creatures can't attack you.";
    }
}
