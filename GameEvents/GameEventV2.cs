using Interfaces;

namespace GameEvents;

public abstract class GameEventV2 : IGameEventV2
{
    public GameEventV2(IPlayerV2 player, bool passable)
    {
        Player = player;
        Passable = passable;
    }

    protected GameEventV2(IGameEventV2 gameEvent)
    {
        Player = gameEvent.Player.Copy();
        Passable = gameEvent.Passable;
    }
    
    public IPlayerV2 Player { get; }
    public bool Passable { get; }

    /// <param name="state">The current state of the game.</param>
    /// <returns>Events that would happen during the event.
    /// If none, the event has completely happened.</returns>
    public abstract IEnumerable<IGameEventV2> Happen(IGameState state);

    public virtual void Validate(IGameEventV2 gameEvent)
    {
        throw new IllegalActionException(gameEvent, IllegalActionType.Unknown);
    }

    public override bool Equals(object? obj)
    {
        if (obj is not GameEventV2 e) return false;
        if (Player != e.Player) return false;
        if (Passable != e.Passable) return false;
        return true;
    }

    public abstract IGameEventV2 Copy();

    public override int GetHashCode()
    {
        return HashCode.Combine(Player, Passable);
    }
}