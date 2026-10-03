using System;
using System.Collections.Generic;
using System.Linq;
using Interfaces;

namespace Engine;

public sealed class EventsThatWouldHappen : IEventsThatWouldHappen
{
    readonly List<IGameEventV2> _eventsThatWouldHappen = [];

    public EventsThatWouldHappen()
    {
    }

    EventsThatWouldHappen(EventsThatWouldHappen events)
    {
        _eventsThatWouldHappen = [.. events._eventsThatWouldHappen];
    }

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

    public IEventsThatWouldHappen Copy()
    {
        return new EventsThatWouldHappen(this);
    }

    public override bool Equals(object obj)
    {
        if (obj is not EventsThatWouldHappen events) return false;
        if (!_eventsThatWouldHappen.SequenceEqual(
            events._eventsThatWouldHappen)) return false;
        return true;
    }

    public override int GetHashCode()
    {
        var hash = new HashCode();
        foreach (var e in _eventsThatWouldHappen)
        {
            hash.Add(e);
        }
        return hash.ToHashCode();
    }
}