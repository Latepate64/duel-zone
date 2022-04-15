using Engine.GameEvents;
using Engine.Steps;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Engine
{
    public class Turn : ITurn, IDisposable
    {
        #region Properties
        /// <summary>
        /// The phase that is currently being processed.
        /// </summary>
        public IPhase CurrentPhase => Phases.Last();

        /// <summary>
        /// All the phases in the turn that have been or are processed, in order.
        /// </summary>
        public IList<IPhase> Phases { get; private set; } = new Collection<IPhase>();

        /// <summary>
        /// 102.1. The active player is the player whose turn it is.
        /// </summary>
        public IPlayer ActivePlayer { get; set; }

        /// <summary>
        /// 102.1. The other players are nonactive players.
        /// </summary>
        public IPlayer NonActivePlayer { get; set; }

        public int Number { get; set; }

        public Guid Id { get; set; }
        #endregion Properties

        public Turn() : base()
        {
            Id = Guid.NewGuid();
        }

        public Turn(ITurn turn)
        {
            Phases = turn.Phases.Select(x => x.Copy()).ToList();
            ActivePlayer = turn.ActivePlayer;
            NonActivePlayer = turn.NonActivePlayer;
            Number = turn.Number;
            Id = turn.Id;
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
