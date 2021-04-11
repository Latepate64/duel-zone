using DuelMastersModels.Choices;

namespace DuelMastersModels.Steps
{
    public abstract class Step : IStep
    {
        /// <summary>
        /// The player whose turn it is.
        /// </summary>
        public IPlayer ActivePlayer { get; }

        protected Step(IPlayer activePlayer)
        {
            ActivePlayer = activePlayer;
        }

        /// <summary>
        /// 702.2. Whenever a step begins, if it’s a step that has any turn-based action associated with it, those turn-based actions are automatically dealt with first. This happens before state-based actions are checked, and before trigger abilities are resolved.
        /// </summary>
        public virtual IChoice ProcessTurnBasedActions(IDuel duel) { return null; }

        /// <summary>
        /// Checks if the step needs a player action to be performed. Returns null if no action needs to be performed.
        /// </summary>
        public abstract IChoice PlayerActionRequired(IDuel duel);
    }
}
