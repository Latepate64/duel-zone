using Engine.GameEvents;

namespace Engine;

public class Game(IRandomizer randomizer)
{
    readonly IRandomizer randomizer = randomizer;

    public GameState State { get; private set; }

    public void Start(PlayerV2 startingPlayer, PlayerV2 otherPlayer)
    {
        State = new GameState([startingPlayer, otherPlayer]);
        State = new ShuffleDeckEvent(startingPlayer, randomizer).Happen(State, 
            action: null);
        State = new ShuffleDeckEvent(otherPlayer, randomizer).Happen(State,
            action: null);
    }
}
