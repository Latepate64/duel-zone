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
    public EventStack EventsHappening { get; init; } = new();

    /// <summary>
    /// An action that a player either takes or passes (eg. if a player may draw a card)
    /// </summary>
    public PlayerAction PassableAction { get; set; }

    public PlayerV2 ActivePlayer => Players.First();
    public IEnumerable<PlayerV2> NonActivePlayers => Players.Skip(1);
    public EventsThatWouldHappen EventsThatWouldHappen { get; } = new();

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
            && EventsHappening == state.EventsHappening
            && EventsThatWouldHappen == state.EventsThatWouldHappen
            && PassableAction == state.PassableAction;
    }
}
