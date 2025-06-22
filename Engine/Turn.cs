using Engine.Steps;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Engine
{
    public sealed class Turn
    {
        public Turn() : base()
        {
            Id = Guid.NewGuid();
        }

        public Turn(Turn turn)
        {
            Phases = [.. turn.Phases.Select(x => x.Copy())];
            ActivePlayer = turn.ActivePlayer;
            NonActivePlayer = turn.NonActivePlayer;
            Number = turn.Number;
            Id = turn.Id;
        }

        /// <summary>
        /// 102.1. The active player is the player whose turn it is.
        /// </summary>
        public IPlayer ActivePlayer { get; set; }

        /// <summary>
        /// The phase that is currently being processed.
        /// </summary>
        public Phase CurrentPhase => Phases.Last();

        public IEnumerable<IGameEvent> GameEvents => Phases.SelectMany(x => x.GameEvents);

        public Guid Id { get; set; }

        /// <summary>
        /// 102.1. The other players are nonactive players.
        /// </summary>
        public IPlayer NonActivePlayer { get; set; }

        public int Number { get; set; }

        /// <summary>
        /// All the phases in the turn that have been or are processed, in order.
        /// </summary>
        public IList<Phase> Phases { get; private set; } = [];

        public void Play(IGame game, int number)
        {
            Number = number;
            if (!Phases.Any())
            {
                // game.ProcessEvents(new PhaseBegunEvent(new StartOfTurnPhase(Number == 1), game.CurrentTurn));
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
                Phase nextPhase = CurrentPhase.GetNextPhase(game);
                if (nextPhase != null)
                {
                    // game.ProcessEvents(new PhaseBegunEvent(nextPhase, game.CurrentTurn));
                }
            }
        }

        public override string ToString()
        {
            return $"Turn {Number}";
        }
    }
}