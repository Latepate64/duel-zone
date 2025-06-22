using System;
using System.Collections.Generic;
using System.Linq;
using Engine.GameEvents;

namespace Engine;

public sealed class EventStack(params GameEventV2[] events)
{
    readonly Stack<GameEventV2[]> events = new([events]);

    internal void Push(params GameEventV2[] gameEvents)
    {
        events.Push(gameEvents);
    }

    internal GameEventV2[] Pop()
    {
        return events.Pop();
    }

    internal bool IsEmpty => events.Count == 0;

    public override bool Equals(object obj)
    {
        return obj is EventStack stack
            && events.SequenceEqual(stack.events);
    }

    internal IEnumerable<GameEventV2> Happen(GameState state)
    {
        return [.. events.Peek().SelectMany(x => x.Happen(state))];
    }
}