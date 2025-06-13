using System;
using System.Linq;
using Engine.GameEvents;

namespace Engine;

public class Game(IRandomizer randomizer)
{
    readonly IRandomizer randomizer = randomizer;

    public GameState State { get; private set; }

    public Game(IRandomizer randomizer, GameState state) : this(randomizer)
    {
        State = state;
    }

    public void Start(PlayerV2 startingPlayer, PlayerV2 otherPlayer)
    {
        if (State != null)
        {
            throw new InvalidOperationException();
        }
        State = new GameState([startingPlayer, otherPlayer]);
        new ShuffleDeckEvent(startingPlayer, randomizer).Happen(State);
        new ShuffleDeckEvent(otherPlayer, randomizer).Happen(State);
        for (int i = 0; i < 5; ++i)
        {
            new MoveTopCardOfDeckEvent(startingPlayer, ZoneType.ShieldZone).Happen(State);
            new MoveTopCardOfDeckEvent(otherPlayer, ZoneType.ShieldZone).Happen(State);
        }
        for (int i = 0; i < 5; ++i)
        {
            new MoveTopCardOfDeckEvent(startingPlayer, ZoneType.Hand).Happen(State);
            new MoveTopCardOfDeckEvent(otherPlayer, ZoneType.Hand).Happen(State);
        }
        State.EventsThatWouldHappen.Add(new PlayGameEvent());
        Continue();
    }

    public void Play(PlayerAction action)
    {
        ArgumentNullException.ThrowIfNull(action);
        if (State.Winner != null || State.Losers.Count == State.Players.Length)
        {
            throw new InvalidOperationException();
        }
        if (action is ConcedeEvent concede)
        {
            concede.Happen(State);
            return;
        }
        if (State.PassableAction == null)
        {
            throw new InvalidOperationException();
        }
        if (action.Player != State.PassableAction.Player)
        {
            throw new IllegalActionException(action);
        }
        if (action is PassAction)
        {
            // TODO: Throw if there was no action to be passed
            State.RemovePassableAction();
            Continue();
            return;
        }
        if (action.GetType() != State.PassableAction.GetType())
        {
            throw new IllegalActionException(action);
        }
        State.RemovePassableAction();
        State.EventsThatWouldHappen.Add(action);
        Continue();  
    }

    void Continue()
    {
        if (State.EventsThatWouldHappen.Get().Any())
        {
            // TODO: Check if any event could be replaced
            // TODO: Consider multiple events happening simultaneously
            var happeningEvent = State.EventsThatWouldHappen.Get().First();
            State.EventsThatWouldHappen.Clear();
            State.EventsHappening.Push(happeningEvent);
        }
        if (State.EventsHappening.Peek().Happen(State))
        {
            State.EventsHappening.Pop();
        }
        if (State.PassableAction == null)
        {
            Continue();
        }
    }
}
