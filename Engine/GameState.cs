using System.Collections.Generic;
using System.Linq;
using Engine.GameEvents;

namespace Engine;

public class GameState(PlayerV2[] players)
{
    public PlayerV2[] Players { get; } = players;
    public GameEventV2 HappeningEvent { get; set; }
    public PlayerV2 Winner { get; set; }
    public List<PlayerV2> Losers { get; init; } = [];

    public PlayerV2 ActivePlayer => Players.First();
    public IEnumerable<PlayerV2> NonActivePlayers => Players.Skip(1);
    public GameEventV2 LeafHappeningEvent
    {
        get
        {
            var e = HappeningEvent;
            while (e.HappeningEvent != null)
            {
                e = e.HappeningEvent;
            }
            return e;
        }
    }

    public void RemoveLeafHappeningEvent()
    {
        var e = HappeningEvent;
        var events = new List<GameEventV2> { e };
        while (e.HappeningEvent != null)
        {
            e = e.HappeningEvent;
            events.Add(e);
        }
        if (events.Count == 1)
        {
            HappeningEvent = null;
        }
        if (events.Count > 1)
        {
            events[^2].HappeningEvent = null;
        }
    }

    public override bool Equals(object obj)
    {
        return obj is GameState state
            && Players.SequenceEqual(state.Players)
            && HappeningEvent == state.HappeningEvent;
    }
}