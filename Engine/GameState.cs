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
    public IPlayerV2 ActivePlayer { get; set; }
    public IPlayerV2 NonActivePlayer { get; set; }
    public IPlayerV2 Winner { get; set; }
    public IList<IPlayerV2> Losers { get; set; } = [];
    public IEventStack EventsHappening { get; } = new EventStack();

    /// <summary>
    /// An action that a player either takes or passes
    /// (eg. player may draw a card)
    /// </summary>
    public IPassableGameEvent PassableAction { get; set; }
    public IEventsThatWouldHappen EventsThatWouldHappen { get; } =
        new EventsThatWouldHappen();
    public int TurnNumber { get; set; }
    public IBattleZone BattleZone { get; init; } = new BattleZone();
    public IContinuousEffects ContinuousEffects { get; } =
        new ContinuousEffects.ContinuousEffects(game: null);

    public bool GameOver
    {
        get
        {
            if (Winner != null) return true;
            if (ActivePlayer == null && NonActivePlayer == null) return true;
            return false;
        }
    }

    public GameState(IPlayerV2 activePlayer, IPlayerV2 nonActivePlayer)
    {
        ActivePlayer = activePlayer;
        NonActivePlayer = nonActivePlayer;
    }

    GameState(GameState state)
    {
        ActivePlayer = state.ActivePlayer.Copy();
        NonActivePlayer = state.NonActivePlayer.Copy();
        Winner = state.Winner?.Copy();
        Losers = [.. state.Losers.Select(x => x.Copy())];
        EventsHappening = state.EventsHappening.Copy();
        PassableAction = state.PassableAction?.Copy() as IPassableGameEvent;
        EventsThatWouldHappen = state.EventsThatWouldHappen.Copy();
        TurnNumber = state.TurnNumber;
        BattleZone = state.BattleZone.Copy() as IBattleZone;
        ContinuousEffects = state.ContinuousEffects.Copy();
    }

    public IGameState Copy()
    {
        return new GameState(this);
    }

    public override bool Equals(object obj)
    {
        if (obj is not GameState state) return false;
        if (!ActivePlayer.Equals(state.ActivePlayer)) return false;
        if (!NonActivePlayer.Equals(state.NonActivePlayer)) return false;
        if (Winner == null && state.Winner != null) return false;
        if (Winner != null && !Winner.Equals(state.Winner)) return false;
        if (!Losers.SequenceEqual(state.Losers)) return false;
        if (!EventsHappening.Equals(state.EventsHappening)) return false;
        if (PassableAction == null &&
            state.PassableAction != null) return false;
        if (PassableAction != null && !PassableAction.Equals(
            state.PassableAction)) return false;
        if (!EventsThatWouldHappen.Equals(
            state.EventsThatWouldHappen)) return false;
        if (!TurnNumber.Equals(state.TurnNumber)) return false;
        if (!BattleZone.Equals(state.BattleZone)) return false;
        if (!ContinuousEffects.Equals(state.ContinuousEffects)) return false;
        return true;
    }

    public override int GetHashCode()
    {
        var hash = new HashCode();
        hash.Add(ActivePlayer);
        hash.Add(NonActivePlayer);
        hash.Add(Winner);
        foreach (var x in Losers)
        {
            hash.Add(x);
        }
        hash.Add(EventsHappening);
        hash.Add(PassableAction);
        hash.Add(EventsThatWouldHappen);
        hash.Add(TurnNumber);
        hash.Add(BattleZone);
        hash.Add(ContinuousEffects);
        return hash.ToHashCode();
    }
}
