using Interfaces;

namespace GameEvents;

public sealed class PassAction : GameEventV2, IPassAction
{
    public PassAction(IPlayerV2 player)
    {
        Player = player;
    }

    PassAction(IPassAction passAction)
    {
        Player = passAction.Player.Copy();
    }

    public IPlayerV2 Player { get; }

    public override IGameEventV2 Copy()
    {
        return new PassAction(this);
    }

    public override IEnumerable<GameEventV2> Happen(IGameState state)
    {
        return [];
    }

    public void Validate(IPassableGameEvent gameEvent)
    {
    }

    public override bool Equals(object? obj)
    {
        if (obj is not PassAction passable) return false;
        if (!Player.Equals(passable.Player)) return false;
        return true;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Player);
    }
}
