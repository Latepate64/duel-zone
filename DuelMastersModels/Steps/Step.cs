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
    }
}
