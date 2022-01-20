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
        /// The step that is currently being processed.
        /// </summary>
        public Step CurrentStep => Steps.Last();

        /// <summary>
        /// All the steps in the turn that have been or are processed, in order.
        /// </summary>
        public IList<Step> Steps { get; private set; } = new Collection<Step>();

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
            if (!Steps.Any())
            {
                Steps.Add(new StartOfTurnStep(Number == 1));
                StartCurrentStep(game);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        private void StartCurrentStep(Game game)
        {
            CurrentStep.Play(game);
            if (game.Players.Count > 1)
            {
                Step nextStep = CurrentStep.GetNextStep(game);
                if (nextStep != null)
                {
                    Steps.Add(nextStep);
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
            Steps = turn.Steps.Select(x => x.Copy()).ToList();
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
                Steps = null;
            }
        }
    }
}
