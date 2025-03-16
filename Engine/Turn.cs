using Engine.GameEvents;
using Engine.Steps;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Engine;

public class Turn : ITurn, IDisposable
{
    public Turn(IPlayer activePlayer, IPlayer nonActivePlayer)
    {
        Id = Guid.NewGuid();
        ActivePlayer = activePlayer;
        NonActivePlayer = nonActivePlayer;
    }

    Turn(ITurn turn)
    {
        Phases = [.. turn.Phases.Select(x => x.Copy())];
        ActivePlayer = turn.ActivePlayer;
        NonActivePlayer = turn.NonActivePlayer;
        Number = turn.Number;
        Id = turn.Id;
    }

    public ITurn Copy()
    {
        return new Turn(this);
    }

    /// <summary>
    /// 102.1. The active player is the player whose turn it is.
    /// </summary>
    public IPlayer ActivePlayer { get; }

    /// <summary>
    /// The phase that is currently being processed.
    /// </summary>
    public IPhase CurrentPhase => Phases.Last();

    public IEnumerable<IGameEvent> GameEvents => Phases.SelectMany(x => x.GameEvents);

    public Guid Id { get; set; }

    /// <summary>
    /// 102.1. The other players are nonactive players.
    /// </summary>
    public IPlayer NonActivePlayer { get; }

    public int Number { get; set; }

    /// <summary>
    /// All the phases in the turn that have been or are processed, in order.
    /// </summary>
    public IList<IPhase> Phases { get; private set; } = [];

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public void Play(IGame game, int number)
    {
        Number = number;
        if (!Phases.Any())
        {
            game.ProcessEvents(new PhaseBegunEvent(new StartOfTurnPhase(Number == 1), game.CurrentTurn));
        }
        else
        {
            throw new InvalidOperationException();
        }
    }

    public void StartCurrentPhase(IGame game)
    {
        CurrentPhase.Play(game);
        if (!game.Ended)
        {
            IPhase nextPhase = CurrentPhase.GetNextPhase(game);
            if (nextPhase != null)
            {
                game.ProcessEvents(new PhaseBegunEvent(nextPhase, game.CurrentTurn));
            }
        }
    }

    public override string ToString()
    {
        return $"Turn {Number}";
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            Phases = null;
        }
    }

    public override bool Equals(object obj)
    {
        return obj is Turn turn
            && ActivePlayer.Equals(turn.ActivePlayer)
            && Id.Equals(turn.Id)
            && NonActivePlayer.Equals(turn.NonActivePlayer)
            && Number.Equals(turn.Number)
            && Phases.SequenceEqual(turn.Phases);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(ActivePlayer, Id, NonActivePlayer, Number,
            Phases);
    }
}