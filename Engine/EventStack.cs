using System;
using System.Collections.Generic;
using System.Linq;
using Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Engine;

public sealed class EventStack<T, U> : IEventStack<T, U> where T : IGameEvent where U : IGameEvent
{
    readonly Stack<T[]> events = new();
    private readonly IServiceProvider provider;

    public EventStack(IServiceProvider provider)
    {
        this.provider = provider;
    }

    private EventStack(EventStack<T, U> eventStack)
    {
        events = new Stack<T[]>(eventStack.events);
        provider = eventStack.provider;
    }

    public IEventStack<T, U> Copy()
    {
        return new EventStack<T, U>(this);
    }

    public void Push(params T[] gameEvents)
    {
        events.Push(gameEvents);
    }

    public T[] Pop()
    {
        return events.Pop();
    }

    public bool IsEmpty => events.Count == 0;

    public override bool Equals(object obj)
    {
        if (obj is not EventStack<T, U> stack) return false;
        if (!events.SequenceEqual(stack.events)) return false;
        return true;
    }

    public IEnumerable<U> Happen(IGameState state)
    {
        var output = new List<U>();
        var eventsToHappen = events.Peek();
        foreach (var eventToHappen in eventsToHappen)
        {
            var resolver = provider.GetRequiredService<IEventResolver<T, U>>();
            var player = state.ActivePlayer; //TODO IS NOT ALWAYS ACTIVE PLAYER!
            output.AddRange(resolver.Resolve(state, player, eventToHappen));
        }
        return output;
    }

    public override int GetHashCode()
    {
        var hash = new HashCode();
        foreach (var e in events)
        {
            hash.Add(e);
        }
        return hash.ToHashCode();
    }
}