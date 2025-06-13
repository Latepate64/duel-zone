using System;
using System.Collections.Generic;
using System.Linq;
using Engine.GameEvents;

namespace Engine;

public class EventStack(params GameEventV2[] events)
{
    readonly Stack<GameEventV2> events = new(events);

    internal void Push(GameEventV2 gameEvent)
    {
        events.Push(gameEvent);
    }

    internal GameEventV2 Pop()
    {
        return events.Pop();
    }

    internal GameEventV2 Peek()
    {
        return events.Peek();
    }

    public override bool Equals(object obj)
    {
        return obj is EventStack stack
            && events.SequenceEqual(stack.events);
    }
}