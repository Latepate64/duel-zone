namespace DuelMastersModels.GameActions
{
    internal abstract class GameAction
    {
        /// <summary>
        /// Performs the game action.
        /// </summary>
        internal abstract void Perform(IDuel duel);
    }
}
