using Interfaces;

namespace GameEvents;

public abstract class GameEventV2 : IGameEventV2
{
    public GameEventV2(IPlayerV2 player)
    {
        Player = player;
    }

    protected GameEventV2(IGameEventV2 gameEvent)
    {
        Player = gameEvent.Player.Copy();
    }
    
    public IPlayerV2 Player { get; }

    /// <param name="state">The current state of the game.</param>
    /// <returns>Events that would happen during the event.
    /// If none, the event has completely happened.</returns>
    public abstract IEnumerable<IGameEventV2> Happen(IGameState state);

    public override bool Equals(object? obj)
    {
        if (obj is not GameEventV2 e) return false;
        if (Player != e.Player) return false;
        return true;
    }

    public abstract IGameEventV2 Copy();

    public override int GetHashCode()
    {
        return HashCode.Combine(Player);
    }
}