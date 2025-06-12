using System.Linq;
using Engine.GameEvents;

namespace Engine;

public class Game(IRandomizer randomizer)
{
    readonly IRandomizer randomizer = randomizer;

    public GameState State { get; private set; }

    public void Start(PlayerV2 startingPlayer, PlayerV2 otherPlayer)
    {
        State = new GameState([startingPlayer, otherPlayer]);
        new ShuffleDeckEvent(startingPlayer, randomizer).Happen(State, null);
        new ShuffleDeckEvent(otherPlayer, randomizer).Happen(State, null);
        for (int i = 0; i < 5; ++i)
        {
            new MoveTopCardOfDeckEvent(startingPlayer, ZoneType.ShieldZone).Happen(State, null);
            new MoveTopCardOfDeckEvent(otherPlayer, ZoneType.ShieldZone).Happen(State, null);
        }
        for (int i = 0; i < 5; ++i)
        {
            new MoveTopCardOfDeckEvent(startingPlayer, ZoneType.Hand).Happen(State, null);
            new MoveTopCardOfDeckEvent(otherPlayer, ZoneType.Hand).Happen(State, null);
        }
        State.HappeningEvent = new PlayGameEvent();
        Play(playerAction: null);
    }

    public void Play(PlayerAction playerAction)
    {
        if (State.LeafHappeningEvent.EventsThatWouldHappen.Any())
        {
            // TODO: Check if any event could be replaced
            // TODO: Consider multiple events happening simultaneously
            var happeningEvent = State.LeafHappeningEvent.EventsThatWouldHappen.First();
            State.LeafHappeningEvent.ClearEventsThatWouldHappen();
            State.LeafHappeningEvent.HappeningEvent = happeningEvent;
        }
        var happenedCompletely = State.LeafHappeningEvent.Happen(State, playerAction);
        if (happenedCompletely)
        {
            State.RemoveLeafHappeningEvent();
        }
        if (State.LeafHappeningEvent.PromptedAction == null)
        {
            Play(null);
        }
    }
}
