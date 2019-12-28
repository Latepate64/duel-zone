using DuelMastersModels.Cards;
using DuelMastersModels.PlayerActions;
using System.Collections.ObjectModel;

namespace DuelMastersModels.Steps
{
    public abstract class Step
    {
        #region Properties
        /// <summary>
        /// The player whose turn it is.
        /// </summary>
        public Player ActivePlayer { get; }

        /// <summary>
        /// All the player actions performed during the step.
        /// </summary>
        public ObservableCollection<PlayerAction> PlayerActions { get; } = new ObservableCollection<PlayerAction>();
        public ObservableCollection<Card> DrawnCards { get; } = new ObservableCollection<Card>();
        #endregion Properties

        protected Step(Player activePlayer)
        {
            ActivePlayer = activePlayer;
        }

        /// <summary>
        /// 702.2. Whenever a step begins, if it’s a step that has any turn-based action associated with it, those turn-based actions are automatically dealt with first. This happens before state-based actions are checked, and before trigger abilities are resolved.
        /// </summary>
        public virtual PlayerAction ProcessTurnBasedActions(Duel duel) { return null; }

        /// <summary>
        /// Checks if the step needs a player action to be performed. Returns null if no action needs to be performed.
        /// </summary>
        public abstract PlayerAction PlayerActionRequired(Duel duel);
    }
}
