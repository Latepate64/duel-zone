using Common.GameEvents;
using Engine.Steps;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Engine
{
    public class Turn : Common.Turn, IDisposable, ITurn
    {
        #region Properties
        /// <summary>
        /// The phase that is currently being processed.
        /// </summary>
        public Phase CurrentPhase => Phases.Last();

        /// <summary>
        /// All the phases in the turn that have been or are processed, in order.
        /// </summary>
        public IList<Phase> Phases { get; private set; } = new Collection<Phase>();

        /// <summary>
        /// 102.1. The active player is the player whose turn it is.
        /// </summary>
        public IPlayer ActivePlayer { get; set; }

        /// <summary>
        /// 102.1. The other players are nonactive players.
        /// </summary>
        public IPlayer NonActivePlayer { get; set; }
        #endregion Properties

        public Turn() : base()
        {
        }

        public Turn(ITurn turn) : base(turn)
        {
            Phases = turn.Phases.Select(x => x.Copy()).ToList();
            ActivePlayer = turn.ActivePlayer;
            NonActivePlayer = turn.NonActivePlayer;
        }

        public void Play(IGame game, int number)
        {
            Number = number;
            if (!Phases.Any())
            {
                Phases.Add(new StartOfTurnPhase(Number == 1));
                StartCurrentPhase(game);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        private void StartCurrentPhase(IGame game)
        {
            CurrentPhase.Play(game);
            if (!game.Ended)
            {
                Phase nextPhase = CurrentPhase.GetNextPhase(game);
                if (nextPhase != null)
                {
                    Phases.Add(nextPhase);
                    game.Process(new PhaseBegunEvent(nextPhase.Type, game.CurrentTurn.Convert()));
                    StartCurrentPhase(game);
                }
            }
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

        public Common.ITurn Convert()
        {
            return new Common.Turn(this);
        }
    }
}
