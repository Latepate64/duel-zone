using Interfaces;

namespace GameEvents;

public sealed class StartGameEvent : GameEventV2, IStartGameEvent
{
    public IPlayerV2 StartingPlayer { get; }
    public IPlayerV2 OtherPlayer { get; }
    readonly IRandomizer randomizer;

    public StartGameEvent(
        IPlayerV2 startingPlayer, IPlayerV2 otherPlayer, IRandomizer randomizer)
    {
        StartingPlayer = startingPlayer;
        OtherPlayer = otherPlayer;
        this.randomizer = randomizer;
    }

    public StartGameEvent(StartGameEvent gameEvent)
    {
        StartingPlayer = gameEvent.StartingPlayer.Copy();
        OtherPlayer = gameEvent.OtherPlayer.Copy();
        randomizer = gameEvent.randomizer;
    }

    public override IGameEventV2 Copy()
    {
        return new StartGameEvent(this);
    }

    public override IEnumerable<IGameEventV2> Happen(IGameState state)
    {
        new ShuffleDeckEvent(StartingPlayer, randomizer).Happen(state);
        new ShuffleDeckEvent(OtherPlayer, randomizer).Happen(state);
        for (int i = 0; i < 5; ++i)
        {
            new MoveTopCardOfDeckEvent(
                StartingPlayer, ZoneType.ShieldZone).Happen(state);
            new MoveTopCardOfDeckEvent(
                OtherPlayer, ZoneType.ShieldZone).Happen(state);
        }
        for (int i = 0; i < 5; ++i)
        {
            new MoveTopCardOfDeckEvent(
                StartingPlayer, ZoneType.Hand).Happen(state);
            new MoveTopCardOfDeckEvent(
                OtherPlayer, ZoneType.Hand).Happen(state);
        }
        return [];
    }

    public override bool Equals(object? obj)
    {
        if (obj is not StartGameEvent passable) return false;
        if (!StartingPlayer.Equals(passable.StartingPlayer)) return false;
        if (!OtherPlayer.Equals(passable.OtherPlayer)) return false;
        return true;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(StartingPlayer, OtherPlayer);
    }
}