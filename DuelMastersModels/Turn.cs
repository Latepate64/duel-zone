using DuelMastersModels.Choices;
using DuelMastersModels.Steps;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels
{
    public class Turn : ICopyable<Turn>
    {
        #region Properties
        /// <summary>
        /// The player whose turn it is.
        /// </summary>
        public Player ActivePlayer { get; }

        /// <summary>
        /// The opponent of the active player.
        /// </summary>
        public Player NonActivePlayer { get; private set; }

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

        public Turn(Player activePlayer, Player nonActivePlayer)
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
                throw new System.InvalidOperationException();
            }
        }

        public Choice ChangeAndStartStep(Duel duel)
        {
            Step nextStep = CurrentStep.GetNextStep();
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

        internal Choice Continue(Choice choiceArg, Duel duel)
        {
            var choice = CurrentStep.Proceed(choiceArg, duel);
            if (choice == null)
            {
                return ChangeAndStartStep(duel);
            }
            else
            {
                return choice;
            }
        }

        public Turn Copy()
        {
            return new Turn(ActivePlayer.Copy(), NonActivePlayer.Copy())
            {
                Number = Number,
                Steps = Steps.Select(x => x.Copy()).ToList(),
            };
        }
    }
}
