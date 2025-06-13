using System;
using System.Linq;
using Engine.GameEvents;

namespace Engine;

public class Game(IRandomizer randomizer, int maxLoopCount = 5)
{
    readonly IRandomizer randomizer = randomizer;
    readonly int maxLoopCount = maxLoopCount;

    public GameState State { get; private set; }

    GameState _originalState;

    public Game(IRandomizer randomizer, GameState state, int maxLoopCount = 5) : this(randomizer, maxLoopCount)
    {
        State = state;
        _originalState = state;
    }

    public void Start(PlayerV2 startingPlayer, PlayerV2 otherPlayer)
    {
        if (State != null)
        {
            throw new InvalidOperationException("Game has started already");
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
        Continue();
    }

    public void Play(GameEventV2 action)
    {
        ArgumentNullException.ThrowIfNull(action);
        if (State.Winner != null || State.Losers.Count == State.Players.Length)
        {
            throw new InvalidOperationException("Game has ended already");
        }
        try
        {
            Continue(action);
        }
        catch
        {
            State = _originalState;
            throw;
        }
        _originalState = State;
    }

    void Continue(GameEventV2 action)
    {
        if (action is ConcedeEvent concede)
        {
            concede.Happen(State);
            return;
        }
        if (State.PassableAction == null)
        {
            throw new InvalidOperationException("No passable action found");
        }
        if (action.Player != State.PassableAction.Player)
        {
            throw new IllegalActionException(action, "Unexpected player");
        }
        if (action is PassAction)
        {
            // TODO: Throw if there was no action to be passed
            State.RemovePassableAction();
            Continue();
            return;
        }
        if (!State.PassableAction.IsLegal(action))
        {
            throw new IllegalActionException(action, "Unexpected type of action");
        }
        State.RemovePassableAction();
        State.EventsThatWouldHappen.Add(action);
        Continue();
    }

    void Continue(int loopCounter = 0)
    {
        if (loopCounter++ > maxLoopCount)
        {
            throw new InvalidOperationException("Looped too many times");
        }
        if (State.EventsThatWouldHappen.Get().Any())
        {
            // TODO: Check if any event could be replaced
            // TODO: Consider multiple events happening simultaneously
            var happeningEvent = State.EventsThatWouldHappen.Get().First();
            State.EventsThatWouldHappen.Clear();
            State.EventsHappening.Push(happeningEvent);
        }
        if (State.EventsHappening.IsEmpty)
        {
            if (State.TurnNumber > 0)
            {
                State.UpdatePlayerOrder();
            }
            State.EventsThatWouldHappen.Add(new TakeTurnEvent(State.ActivePlayer, ++State.TurnNumber));
            Continue(loopCounter);
            return;
        }
        var events = State.EventsHappening.Peek().Happen(State);
        if (!events.Any())
        {
            _ = State.EventsHappening.Pop();
            // TODO: Broadcast happened event to clients, triggers and watchers
            Continue(loopCounter);
            return;
        }
        var gameEvent = events.Single(); // TODO: May include multiple events
        if (gameEvent.Passable)
        {
            State.PassableAction = gameEvent;
            return;
        }
        State.EventsThatWouldHappen.Add([.. events]);
        Continue(loopCounter);
    }
}
