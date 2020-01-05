using DuelMastersModels.PlayerActions;

namespace DuelMastersModels.Steps
{
    internal abstract class Step
    {
        /// <summary>
        /// The player whose turn it is.
        /// </summary>
        public Player ActivePlayer { get; }

        protected Step(Player activePlayer)
        {
            ActivePlayer = activePlayer;
        }

        /// <summary>
        /// 702.2. Whenever a step begins, if it’s a step that has any turn-based action associated with it, those turn-based actions are automatically dealt with first. This happens before state-based actions are checked, and before trigger abilities are resolved.
        /// </summary>
        internal virtual PlayerAction ProcessTurnBasedActions(Duel duel) { return null; }

        /// <summary>
        /// Checks if the step needs a player action to be performed. Returns null if no action needs to be performed.
        /// </summary>
        internal abstract PlayerAction PlayerActionRequired(Duel duel);
    }
}
