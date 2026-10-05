using Interfaces;

namespace GameEvents;

public sealed class StartGameEvent : GameEventV2, IStartGameEvent
{
    public IPlayerV2 OtherPlayer { get; }
    readonly IRandomizer randomizer;

    public StartGameEvent(
        IPlayerV2 startingPlayer, IPlayerV2 otherPlayer, IRandomizer randomizer)
        : base(startingPlayer)
    {
        OtherPlayer = otherPlayer;
        this.randomizer = randomizer;
    }

    public StartGameEvent(StartGameEvent gameEvent) : base(gameEvent)
    {
        OtherPlayer = gameEvent.OtherPlayer.Copy();
        randomizer = gameEvent.randomizer;
    }

    public override IGameEventV2 Copy()
    {
        return new StartGameEvent(this);
    }

    public override IEnumerable<IGameEventV2> Happen(IGameState state)
    {
        new ShuffleDeckEvent(Player, randomizer).Happen(state);
        new ShuffleDeckEvent(OtherPlayer, randomizer).Happen(state);
        for (int i = 0; i < 5; ++i)
        {
            new MoveTopCardOfDeckEvent(
                Player, ZoneType.ShieldZone).Happen(state);
            new MoveTopCardOfDeckEvent(
                OtherPlayer, ZoneType.ShieldZone).Happen(state);
        }
        for (int i = 0; i < 5; ++i)
        {
            new MoveTopCardOfDeckEvent(
                Player, ZoneType.Hand).Happen(state);
            new MoveTopCardOfDeckEvent(
                OtherPlayer, ZoneType.Hand).Happen(state);
        }
        return [];
    }
}