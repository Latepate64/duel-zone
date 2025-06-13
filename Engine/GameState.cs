using System;
using System.Collections.Generic;
using System.Linq;
using Engine.GameEvents;

namespace Engine;

public class GameState(PlayerV2[] players)
{
    public PlayerV2[] Players { get; } = players;
    public PlayerV2 Winner { get; set; }
    public List<PlayerV2> Losers { get; init; } = [];
    readonly List<GameEventV2> _eventsThatWouldHappen = [];
    public EventStack Events { get; }

    /// <summary>
    /// An action that a player either takes or passes (eg. if a player may draw a card)
    /// </summary>
    public PlayerAction PassableAction { get; internal set; }

    public PlayerV2 ActivePlayer => Players.First();
    public IEnumerable<PlayerV2> NonActivePlayers => Players.Skip(1);
    public IEnumerable<GameEventV2> EventsThatWouldHappen => _eventsThatWouldHappen;

    internal void ClearEventsThatWouldHappen()
    {
        _eventsThatWouldHappen.Clear();
    }

    internal void AddEventThatWouldHappen(GameEventV2 gameEvent)
    {
        PassableAction = null;
        _eventsThatWouldHappen.Add(gameEvent);
    }

    internal void RemovePassableAction()
    {
        PassableAction = null;
    }

    public override bool Equals(object obj)
    {
        return obj is GameState state
            && Players.SequenceEqual(state.Players)
            && Winner == state.Winner
            && Losers.SequenceEqual(state.Losers)
            && Events == state.Events
            && _eventsThatWouldHappen.SequenceEqual(state._eventsThatWouldHappen)
            && PassableAction == state.PassableAction;
    }
}
