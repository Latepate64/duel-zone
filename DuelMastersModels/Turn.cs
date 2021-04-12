using DuelMastersModels.Steps;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels
{
    public class Turn : ITurn
    {
        #region Properties
        /// <summary>
        /// The player whose turn it is.
        /// </summary>
        public IPlayer ActivePlayer { get; }

        /// <summary>
        /// The opponent of the active player.
        /// </summary>
        public IPlayer NonActivePlayer { get; }

        /// <summary>
        /// All the steps in the turn that have been or are processed, in order.
        /// </summary>
        internal ICollection<IStep> Steps { get; } = new Collection<IStep>();

        /// <summary>
        /// The step that is currently being processed.
        /// </summary>
        public IStep CurrentStep => Steps.Last();

        /// <summary>
        /// The number of the turn.
        /// </summary>
        internal int Number { get; private set; }
        #endregion Properties

        public Turn(IPlayer activePlayer, int number)
        {
            ActivePlayer = activePlayer;
            NonActivePlayer = activePlayer.Opponent;
            Number = number;
        }

        /// <summary>
        /// Adds a new step in order which becomes the current step.
        /// </summary>
        /// <returns>null if turn is over, choice otherwise</returns>
        public void ChangeStep()
        {
            if (!Steps.Any())
            {
                Steps.Add(new StartOfTurnStep(ActivePlayer, Number == 1));
            }
            else
            {
                Steps.Add(CurrentStep.GetNextStep());
            }
        }
    }
}
