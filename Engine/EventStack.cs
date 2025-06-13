using System;
using System.Collections.Generic;
using System.Linq;
using Engine.GameEvents;

namespace Engine;

public class EventStack
{
    readonly Stack<GameEventV2> events = new();

    public void Push(GameEventV2 gameEvent)
    {
        events.Push(gameEvent);
    }

    internal void Pop()
    {
        events.Pop();
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