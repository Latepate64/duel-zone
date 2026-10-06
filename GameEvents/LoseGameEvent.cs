using Interfaces;

namespace GameEvents;

public class LoseGameEvent : GameEventV2
{
    public LoseGameEvent(IPlayerV2 player)
    {
        Player = player;
    }

    LoseGameEvent(LoseGameEvent gameEvent)
    {
        Player = gameEvent.Player.Copy();
    }

    public IPlayerV2 Player { get; }

    public override IGameEventV2 Copy()
    {
        return new LoseGameEvent(this);
    }

    public override IEnumerable<GameEventV2> Happen(IGameState state)
    {
        state.Losers.Add(Player);
        var remainingPlayers = state.NonActivePlayers.Append(
            state.ActivePlayer).Where(x => x != Player);
        if (remainingPlayers.Count() == 1)
        {
            state.Winner = remainingPlayers.Single();
        }
        return [];
    }

    public override bool Equals(object? obj)
    {
        if (obj is not LoseGameEvent passable) return false;
        if (!Player.Equals(passable.Player)) return false;
        return true;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Player);
    }
}