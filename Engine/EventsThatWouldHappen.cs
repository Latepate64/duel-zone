using System.Collections.Generic;
using Engine.GameEvents;

namespace Engine;

public class EventsThatWouldHappen
{
    readonly List<GameEventV2> _eventsThatWouldHappen = [];

    internal void Add(params GameEventV2[] events)
    {
        _eventsThatWouldHappen.AddRange(events);
    }

    internal IEnumerable<GameEventV2> Get()
    {
        return [.. _eventsThatWouldHappen];
    }

    internal void Clear()
    {
        _eventsThatWouldHappen.Clear();
    }
}