using System;
using System.Collections.Generic;
using System.Linq;
using Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Engine;

public sealed class Game(IServiceProvider provider, int maxLoopCount = 5)
{
    private readonly IServiceProvider provider = provider;
    readonly int maxLoopCount = maxLoopCount;

    public IGameState State { get; private set; }

    IGameState _originalState;

    public Game(IServiceProvider provider, IGameState state, int maxLoopCount = 5) : this(
        provider, maxLoopCount)
    {
        State = state;
        _originalState = state;
    }

    public void Play(IGameEvent action)
    {
        ArgumentNullException.ThrowIfNull(action);
        if (action is IStartGameEvent start)
        {
            if (State != null)
            {
                throw new InvalidOperationException("Game has started already");
            }
            State = new GameState(start.StartingPlayer, start.OtherPlayer, provider);
            var resolver = provider.GetRequiredService<IEventResolver<IStartGameEvent, IGameEvent>>();
            _ = resolver.Resolve(State, start.StartingPlayer, start);
            Continue();
            return;
        }
        if (State == null)
        {
            throw new InvalidOperationException("Game has not yet started");
        }
        if (State.GameOver)
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

    void Continue(IGameEvent gameEvent)
    {
        if (gameEvent is IConcedeEvent concede)
        {
            throw new NotImplementedException("figure out player");
            // var resolver = provider.GetRequiredService<IEventResolver<IConcedeEvent>>();
            // IPlayer player = null;
            // resolver.Resolve(State, player, concede);
            // return;
        }
        if (State.PassableAction == null)
        {
            throw new InvalidOperationException("No passable action found");
        }
        if (gameEvent is not IPassableGameEvent passable)
        {
            throw new InvalidOperationException("No passable action given");
        }
        if (passable.Player != State.PassableAction.Player)
        {
            throw new InvalidOperationException(
                "Unexpected player tried to take action");
        }
        if (passable is IPassAction)
        {
            // TODO: Throw if there was no action to be passed
            State.PassableAction = null;
            Continue();
            return;
        }
        State.PassableAction.Validate(passable);
        State.PassableAction = null;
        State.EventsThatWouldHappen.Add(gameEvent);
        Continue();
        return;
    }

    void Continue(int loopCounter = 0)
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
            return;
        }
        var events = State.EventsHappening.Happen(State);
        CheckEmptyDecks();
        if (State.GameOver)
        {
            return;
        }
        if (!events.Any())
        {
            _ = State.EventsHappening.Pop();
            // TODO: Broadcast events that happened to
            // clients, triggers and watchers
            Continue(loopCounter);
            return;
        }
        var passables = events.OfType<IPassableGameEvent>();
        if (passables.Count() == 1)
        {
            State.PassableAction = passables.Single();
            return;
        }
        if (passables.Count() > 1)
        {
            throw new NotImplementedException();
        }
        State.EventsThatWouldHappen.Add([.. events]);
        Continue(loopCounter);
    }

    void CheckEmptyDecks()
    {
        var players = new List<IPlayer> { State.ActivePlayer };
        players.AddRange(State.NonActivePlayer);
        var losers = players.Where(x => !x.Deck.HasCards);
        if (losers.Any())
        {
            State.Losers = [.. losers];
            State.Winner = players.SingleOrDefault(x => !losers.Contains(x));
        }
    }
}
