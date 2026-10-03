using System;
using System.Collections.Generic;
using System.Linq;
using Interfaces;

namespace Engine;

public sealed class EventStack : IEventStack
{
    readonly Stack<IGameEventV2[]> events = new();

    public EventStack()
    {
    }

    EventStack(EventStack eventStack)
    {
        events = new Stack<IGameEventV2[]>(eventStack.events);
    }

    public IEventStack Copy()
    {
        return new EventStack(this);
    }

    public void Push(params IGameEventV2[] gameEvents)
    {
        events.Push(gameEvents);
    }

    public IGameEventV2[] Pop()
    {
        return events.Pop();
    }

    public bool IsEmpty => events.Count == 0;

    public override bool Equals(object obj)
    {
        if (obj is not EventStack stack) return false;
        if (!events.SequenceEqual(stack.events)) return false;
        return true;
    }

    public IEnumerable<IGameEventV2> Happen(IGameState state)
    {
        return [.. events.Peek().SelectMany(x => x.Happen(state))];
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