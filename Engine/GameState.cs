using System;
using System.Collections.Generic;
using System.Linq;
using Engine.Zones;
using Interfaces;
using Interfaces.ContinuousEffects;
using Interfaces.Zones;

namespace Engine;

public sealed class GameState : IGameState
{
    public IPlayerV2 Winner { get; set; }
    public IList<IPlayerV2> Losers { get; set; } = [];
    public IPlayerV2 ActivePlayer { get; set; }
    public IEnumerable<IPlayerV2> NonActivePlayers { get; set; }
    public IEventStack EventsHappening { get; init; } = new EventStack();

    /// <summary>
    /// An action that a player either takes or passes
    /// (eg. if a player may draw a card)
    /// </summary>
    public IPassableGameEvent PassableAction { get; set; }
    public IEventsThatWouldHappen EventsThatWouldHappen { get; } =
        new EventsThatWouldHappen();
    public int TurnNumber { get; set; }
    public IBattleZone BattleZone { get; init; } = new BattleZone();
    public IContinuousEffects ContinuousEffects { get; internal set; } =
        new ContinuousEffects.ContinuousEffects(game: null);

    public bool GameOver => Winner != null ||
        (ActivePlayer == null && !NonActivePlayers.Any());

    public GameState(IPlayerV2[] players)
    {
        ActivePlayer = players.First();
        NonActivePlayers = players.Skip(1);
    }

    GameState(GameState state)
    {
        Winner = state.Winner.Copy();
        Losers = [.. state.Losers.Select(x => x.Copy())];
        ActivePlayer = state.ActivePlayer.Copy();
        NonActivePlayers = [.. state.NonActivePlayers.Select(x => x.Copy())];
        EventsHappening = state.EventsHappening.Copy();
        PassableAction = state.PassableAction.Copy() as IPassableGameEvent;
        EventsThatWouldHappen = state.EventsThatWouldHappen.Copy();
        TurnNumber = state.TurnNumber;
        BattleZone = state.BattleZone.Copy();
        ContinuousEffects = state.ContinuousEffects.Copy();
    }

    public IGameState Copy()
    {
        return new GameState(this);
    }

    public override bool Equals(object obj)
    {
        if (obj is not GameState state) return false;
        if (Winner != state.Winner) return false;
        if (!Losers.SequenceEqual(state.Losers)) return false;
        if (!NonActivePlayers.SequenceEqual(
            state.NonActivePlayers)) return false;
        if (EventsHappening != state.EventsHappening) return false;
        if (PassableAction != state.PassableAction) return false;
        if (EventsThatWouldHappen != state.EventsThatWouldHappen) return false;
        if (TurnNumber != state.TurnNumber) return false;
        if (BattleZone != state.BattleZone) return false;
        if (ContinuousEffects != state.ContinuousEffects) return false;
        if (ActivePlayer != state.ActivePlayer) return false;
        return true;
    }

    public override int GetHashCode()
    {
        var hash = HashCode.Combine(
            Winner.GetHashCode(),
            Losers.Select(x => x.GetHashCode()),
            ActivePlayer.GetHashCode(),
            NonActivePlayers.Select(x => x.GetHashCode())
        );
        return HashCode.Combine(
            hash,
            EventsHappening.GetHashCode(),
            PassableAction.GetHashCode(),
            EventsThatWouldHappen.GetHashCode(),
            TurnNumber.GetHashCode(),
            BattleZone.GetHashCode(),
            ContinuousEffects.GetHashCode()
        );
    }
}
