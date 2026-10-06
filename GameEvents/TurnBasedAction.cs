using Interfaces;

namespace GameEvents;

public abstract class TurnBasedAction : GameEventV2, ITurnBasedAction
{
    protected TurnBasedAction(IPlayerV2 player)
    {
        Player = player;
    }

    protected TurnBasedAction(ITurnBasedAction gameEvent)
    {
        Player = gameEvent.Player.Copy();
    }

    public IPlayerV2 Player { get; }

    public override bool Equals(object? obj)
    {
        if (obj is not TurnBasedAction e) return false;
        if (Player != e.Player) return false;
        return true;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Player);
    }
}
