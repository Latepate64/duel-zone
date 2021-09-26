using DuelMastersModels.Choices;
using DuelMastersModels.Steps;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels
{
    public class Turn : DuelObject
    {
        #region Properties
        /// <summary>
        /// The player whose turn it is.
        /// </summary>
        public Guid ActivePlayer { get; }

        /// <summary>
        /// The opponent of the active player.
        /// </summary>
        public Guid NonActivePlayer { get; private set; }

        /// <summary>
        /// The step that is currently being processed.
        /// </summary>
        public Step CurrentStep => Steps.Last();

        /// <summary>
        /// All the steps in the turn that have been or are processed, in order.
        /// </summary>
        internal IList<Step> Steps { get; private set; } = new Collection<Step>();

        /// <summary>
        /// The number of the turn.
        /// </summary>
        internal int Number { get; private set; }
        #endregion Properties

        public Turn(Guid activePlayer, Guid nonActivePlayer)
        {
            ActivePlayer = activePlayer;
            NonActivePlayer = nonActivePlayer;
        }

        public Choice Start(Duel duel, int number)
        {
            Number = number;
            if (!Steps.Any())
            {
                Steps.Add(new StartOfTurnStep(Number == 1));
                return StartCurrentStep(duel);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public Choice ChangeAndStartStep(Duel duel)
        {
            Step nextStep = CurrentStep.GetNextStep(duel);
            if (nextStep != null)
            {
                Steps.Add(nextStep);
                return StartCurrentStep(duel);
            }
            else
            {
                return null; // Turn is over
            }
        }

        private Choice StartCurrentStep(Duel duel)
        {
            Choice choice = CurrentStep.Proceed(null, duel);
            if (choice != null)
            {
                return choice;
            }
            else
            {
                return ChangeAndStartStep(duel);
            }
        }

        internal Choice Continue(Decision decision, Duel duel)
        {
            var choice = CurrentStep.Proceed(decision, duel);
            if (choice == null)
            {
                return ChangeAndStartStep(duel);
            }
            else
            {
                return choice;
            }
        }

        public Turn(Turn turn)
        {
            ActivePlayer = turn.ActivePlayer;
            NonActivePlayer = turn.NonActivePlayer;
            Number = turn.Number;
            Steps = turn.Steps.Select(x => x.Copy()).ToList();
        }

        public override string ToString()
        {
            return $"Turn {Number}";
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Steps = null;
            }
        }
    }
}
