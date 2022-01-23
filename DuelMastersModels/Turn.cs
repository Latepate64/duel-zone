using DuelMastersModels.Steps;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels
{
    public class Turn : IDisposable
    {
        #region Properties
        public Guid Id { get; }

        /// <summary>
        /// 102.1. The active player is the player whose turn it is.
        /// </summary>
        public Guid ActivePlayer { get; set; }

        /// <summary>
        /// 102.1. The other players are nonactive players.
        /// </summary>
        public Guid NonActivePlayer { get; set; }

        /// <summary>
        /// The phase that is currently being processed.
        /// </summary>
        public Phase CurrentPhase => Phases.Last();

        /// <summary>
        /// All the phases in the turn that have been or are processed, in order.
        /// </summary>
        public IList<Phase> Phases { get; private set; } = new Collection<Phase>();

        /// <summary>
        /// The number of the turn.
        /// </summary>
        internal int Number { get; private set; }
        #endregion Properties

        public Turn()
        {
            Id = Guid.NewGuid();
        }

        public void Play(Game game, int number)
        {
            Number = number;
            if (!Phases.Any())
            {
                Phases.Add(new StartOfTurnPhase(Number == 1));
                StartCurrentStep(game);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        private void StartCurrentStep(Game game)
        {
            CurrentPhase.Play(game);
            if (game.Players.Count > 1)
            {
                Phase nextStep = CurrentPhase.GetNextPhase(game);
                if (nextStep != null)
                {
                    Phases.Add(nextStep);
                    StartCurrentStep(game);
                }
            }
        }

        public Turn(Turn turn)
        {
            ActivePlayer = turn.ActivePlayer;
            Id = turn.Id;
            NonActivePlayer = turn.NonActivePlayer;
            Number = turn.Number;
            Phases = turn.Phases.Select(x => x.Copy()).ToList();
        }

        public override string ToString()
        {
            return $"Turn {Number}";
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Phases = null;
            }
        }
    }
}
