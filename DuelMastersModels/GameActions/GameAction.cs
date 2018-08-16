namespace DuelMastersModels.GameActions
{
    public abstract class GameAction
    {
        /// <summary>
        /// Performs the game action.
        /// </summary>
        public abstract void Perform(Duel duel);

        public abstract string Message(Duel duel);
    }
}
