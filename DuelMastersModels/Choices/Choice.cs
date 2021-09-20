namespace DuelMastersModels.Choices
{
    /// <summary>
    /// Represents a choice a player can make.
    /// </summary>
    public abstract class Choice
    {
        /// <summary>
        /// Player who makes the choice.
        /// </summary>
        public Player Player { get; private set; }

        protected Choice(Player player)
        {
            Player = player;
        }
    }
}