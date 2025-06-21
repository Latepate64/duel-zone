using System;
using System.Collections.Generic;
using System.Linq;
using Engine.GameEvents;
using Engine.Zones;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace Engine;

public class GameState(IPlayerV2[] players)
{
    /// <summary>
    /// People in the game in an APNAP order.
    /// </summary>
    public IPlayerV2[] Players { get; private set; } = players;
    public IPlayerV2 Winner { get; set; }
    public List<IPlayerV2> Losers { get; init; } = [];
    public EventStack EventsHappening { get; init; } = new();

    /// <summary>
    /// An action that a player either takes or passes (eg. if a player may draw a card)
    /// </summary>
    public GameEventV2 PassableAction { get; set; }
    public EventsThatWouldHappen EventsThatWouldHappen { get; } = new();
    public int TurnNumber { get; internal set; }
    public BattleZone BattleZone { get; init; } = new BattleZone();
    public IContinuousEffects ContinuousEffects { get; internal set; } = new ContinuousEffects.ContinuousEffects(
        game: null);

    public IPlayerV2 ActivePlayer => Players.First();
    public IEnumerable<IPlayerV2> NonActivePlayers => Players.Skip(1);
    public bool GameOver => Winner != null || Losers.Count == Players.Length;

    internal void RemovePassableAction()
    {
        PassableAction = null;
    }

    internal void UpdatePlayerOrder()
    {
        // TODO: This doesn't work correctly with over two players
        Players = [.. Players.Reverse()];
    }

    public override bool Equals(object obj)
    {
        return obj is GameState state
            && Players.SequenceEqual(state.Players)
            && Winner == state.Winner
            && Losers.SequenceEqual(state.Losers)
            && EventsHappening == state.EventsHappening
            && PassableAction == state.PassableAction
            && EventsThatWouldHappen == state.EventsThatWouldHappen
            && TurnNumber == state.TurnNumber
            && BattleZone == state.BattleZone
            && ContinuousEffects == state.ContinuousEffects;
    }
}
