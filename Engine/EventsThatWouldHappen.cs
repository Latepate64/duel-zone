using System.Collections.Generic;
using Interfaces;

namespace Engine;

public sealed class EventsThatWouldHappen : IEventsThatWouldHappen
{
    readonly List<IGameEventV2> _eventsThatWouldHappen = [];

    public void Add(params IGameEventV2[] events)
    {
        _eventsThatWouldHappen.AddRange(events);
    }

    public IEnumerable<IGameEventV2> Get()
    {
        return [.. _eventsThatWouldHappen];
    }

    public void Clear()
    {
        _eventsThatWouldHappen.Clear();
    }
}