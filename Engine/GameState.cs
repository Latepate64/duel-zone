using System;
using System.Collections.Generic;
using System.Linq;
using Engine.Zones;
using Interfaces;
using Interfaces.ContinuousEffects;
using Interfaces.Zones;

namespace Engine;

public sealed class GameState(IPlayerV2[] players) : IGameState
{
    public IPlayerV2 Winner { get; set; }
    public IList<IPlayerV2> Losers { get; init; } = [];
    public IEventStack EventsHappening { get; init; } = new EventStack();

    /// <summary>
    /// An action that a player either takes or passes (eg. if a player may draw a card)
    /// </summary>
    public IPassableGameEvent PassableAction { get; set; }
    public IEventsThatWouldHappen EventsThatWouldHappen { get; } = new EventsThatWouldHappen();
    public int TurnNumber { get; set; }
    public IBattleZone BattleZone { get; init; } = new BattleZone();
    public IContinuousEffects ContinuousEffects { get; internal set; } = new ContinuousEffects.ContinuousEffects(
        game: null);

    public IPlayerV2 ActivePlayer { get; set; }
    public IEnumerable<IPlayerV2> NonActivePlayers { get; set; } = [];
    public bool GameOver => Winner != null ||
        (ActivePlayer == null && !NonActivePlayers.Any());

    public override bool Equals(object obj)
    {
        return obj is GameState state
            && Winner == state.Winner
            && Losers.SequenceEqual(state.Losers)
            && EventsHappening == state.EventsHappening
            && PassableAction == state.PassableAction
            && EventsThatWouldHappen == state.EventsThatWouldHappen
            && TurnNumber == state.TurnNumber
            && BattleZone == state.BattleZone
            && ContinuousEffects == state.ContinuousEffects;
    }

    public void SwapActivePlayer()
    {
        // TODO: This doesn't work correctly with over two players
        var nonActive = NonActivePlayers.Single();
        var active = ActivePlayer;
        ActivePlayer = nonActive;
        NonActivePlayers = [active];
    }
}
