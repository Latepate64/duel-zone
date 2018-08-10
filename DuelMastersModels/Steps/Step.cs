using DuelMastersModels.PlayerActions;

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
        /// Name of the step.
        /// </summary>
        public string Name { get; set; }
        #endregion Properties

        protected Step(Player activePlayer, string name)
        {
            ActivePlayer = activePlayer;
            Name = name;
        }

        /// <summary>
        /// 702.2. Whenever a step begins, if it’s a step that has any turn-based action associated with it, those turn-based actions are automatically dealt with first. This happens before state-based actions are checked, and before trigger abilities are resolved.
        /// </summary>
        public virtual void ProcessTurnBasedActions(Duel duel) { }

        /// <summary>
        /// Checks if the step needs a player action to be performed. Returns null if no action needs to be performed.
        /// </summary>
        public abstract PlayerAction PlayerActionRequired();
    }
}
