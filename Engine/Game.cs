using System;
using System.Collections.Generic;
using System.Linq;
using Interfaces;

namespace Engine;

public sealed class Game(int maxLoopCount = 5)
{
    readonly int maxLoopCount = maxLoopCount;

    public IGameState State { get; private set; }

    IGameState _originalState;

    public Game(IGameState state, int maxLoopCount = 5)
        : this(maxLoopCount)
    {
        State = state;
        _originalState = state;
    }

    public PlayState Play(IGameEventV2 action)
    {
        ArgumentNullException.ThrowIfNull(action);
        if (action is IStartGameEvent start)
        {
            if (State != null)
            {
                throw new InvalidOperationException("Game has started already");
            }
            State = new GameState([start.Player, start.OtherPlayer]);
            start.Happen(State);
            return Continue();
        }
        if (State.GameOver)
        {
            throw new InvalidOperationException("Game has ended already");
        }
        try
        {
            var playState = Continue(action);
            _originalState = State;
            return playState;
        }
        catch
        {
            State = _originalState;
            throw;
        }
    }

    PlayState Continue(IGameEventV2 action)
    {
        if (action is IConcedeEvent concede)
        {
            concede.Happen(State);
            return PlayState.GameOver;
        }
        if (State.PassableAction == null)
        {
            throw new InvalidOperationException("No passable action found");
        }
        if (action.Player != State.PassableAction.Player)
        {
            throw new InvalidOperationException(
                "Unexpected player tried to take action");
        }
        if (action is IPassAction)
        {
            // TODO: Throw if there was no action to be passed
            State.PassableAction = null;
            return Continue();
        }
        if (action is IPassableGameEvent passable)
        {
            State.PassableAction.Validate(passable);
        }
        State.PassableAction = null;
        State.EventsThatWouldHappen.Add(action);
        return Continue();
    }

    PlayState Continue(int loopCounter = 0)
    {
        if (loopCounter++ > maxLoopCount)
        {
            throw new InvalidOperationException("Looped too many times");
        }
        var eventsThatWouldHappen = State.EventsThatWouldHappen.Get();
        if (eventsThatWouldHappen.Any())
        {
            // TODO: Check if any event could be replaced
            State.EventsThatWouldHappen.Clear();
            State.EventsHappening.Push([.. eventsThatWouldHappen]);
        }
        if (State.EventsHappening.IsEmpty)
        {
            return PlayState.ChangeTurn;
        }
        var events = State.EventsHappening.Happen(State);
        CheckEmptyDecks();
        if (State.GameOver) return PlayState.GameOver;
        if (!events.Any())
        {
            _ = State.EventsHappening.Pop();
            // TODO: Broadcast events that happened to
            // clients, triggers and watchers
            return Continue(loopCounter);
        }
        var passables = events.OfType<IPassableGameEvent>();
        if (passables.Count() == 1)
        {
            State.PassableAction = passables.Single();
            return PlayState.Action;
        }
        if (passables.Count() > 1)
        {
            throw new NotImplementedException();
        }
        State.EventsThatWouldHappen.Add([.. events]);
        return Continue(loopCounter);
    }

    void CheckEmptyDecks()
    {
        var players = new List<IPlayerV2> { State.ActivePlayer };
        players.AddRange(State.NonActivePlayers);
        var losers = players.Where(x => !x.Deck.HasCards);
        if (losers.Any())
        {
            State.Losers = [.. losers];
            State.Winner = players.SingleOrDefault(x => !losers.Contains(x));
        }
    }
}
