using System;
using System.Collections.Generic;
using System.Linq;
using Interfaces;

namespace Engine;

public sealed class EventStack(params IGameEventV2[] events) : IEventStack
{
    readonly Stack<IGameEventV2[]> events = new([events]);

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
        return obj is EventStack stack
            && events.SequenceEqual(stack.events);
    }

    public IEnumerable<IGameEventV2> Happen(IGameState state)
    {
        return [.. events.Peek().SelectMany(x => x.Happen(state))];
    }
}