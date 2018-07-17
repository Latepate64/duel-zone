using DuelMastersModels.Steps;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels
{
    public class Turn
    {
        #region Properties
        /// <summary>
        /// The player whose turn it is.
        /// </summary>
        public Player ActivePlayer { get; }

        /// <summary>
        /// The opponent of the active player.
        /// </summary>
        public Player NonActivePlayer { get; }

        /// <summary>
        /// All the steps in the turn that have been or are processed, in order.
        /// </summary>
        public Collection<Step> Steps { get; } = new Collection<Step>();

        /// <summary>
        /// The step that is currently being processed.
        /// </summary>
        public Step CurrentStep
        {
            get
            {
                return Steps.Last();
            }
        }

        /// <summary>
        /// The number of the turn.
        /// </summary>
        public int Number { get; private set; }
        #endregion Properties

        public Turn(Player activePlayer, Player nonActivePlayer, int number)
        {
            ActivePlayer = activePlayer;
            NonActivePlayer = nonActivePlayer;
            Number = number;
        }

        #region Methods
        /// <summary>
        /// Starts the turn.
        /// </summary>
        public void Start()
        {
            Steps.Add(new StartOfTurnStep(ActivePlayer));
        }

        /// <summary>
        /// Adds a new step in order which becomes the current step.
        /// </summary>
        /// <returns>true if steps are no longer added to the turn as it ends, false otherwise</returns>
        public bool ChangeStep()
        {
            if (CurrentStep is StartOfTurnStep)
            {
                // 500.6. The player who plays first skips the draw step of their first turn.
                if (Number == 1)
                {
                    Steps.Add(new ChargeStep(ActivePlayer));
                }
                else
                {
                    Steps.Add(new DrawStep(ActivePlayer));
                }
            }
            else if (CurrentStep is DrawStep)
            {
                Steps.Add(new ChargeStep(ActivePlayer));
            }
            else if (CurrentStep is ChargeStep)
            {
                Steps.Add(new MainStep(ActivePlayer));
            }
            else if (CurrentStep is MainStep)
            {
                Steps.Add(new AttackStep(ActivePlayer));
            }
            else if (CurrentStep is AttackStep)
            {
                Steps.Add(new EndOfTurnStep(ActivePlayer));
            }
            else if (CurrentStep is EndOfTurnStep)
            {
                return true;
            }
            return false;
        }
        #endregion Methods
    }
}
