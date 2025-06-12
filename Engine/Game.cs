using Engine.GameEvents;

namespace Engine;

public class Game(IRandomizer randomizer)
{
    readonly IRandomizer randomizer = randomizer;

    public GameState State { get; private set; }

    public void Start(PlayerV2 startingPlayer, PlayerV2 otherPlayer)
    {
        State = new GameState([startingPlayer, otherPlayer]);
        new ShuffleDeckEvent(startingPlayer, randomizer).Happen(State);
        new ShuffleDeckEvent(otherPlayer, randomizer).Happen(State);
        for (int i = 0; i < 5; ++i)
        {
            new TopCardOfDeckIntoShieldZoneEvent(startingPlayer).Happen(State);
            new TopCardOfDeckIntoShieldZoneEvent(otherPlayer).Happen(State);
        }
    }
}
